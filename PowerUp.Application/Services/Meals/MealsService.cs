using PowerUp.Application.Services.Meals.DTOs.Requests;
using PowerUp.Application.Services.Meals.DTOs.Responses;
using PowerUp.Application.Services.Trainings;
using PowerUp.Domain.Abstarctions.Repositories;

namespace PowerUp.Application.Services.Meals
{
    public class MealsService
    {
        private readonly IMealRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TrainingsService> _logger;

        public MealsService(IMealRepository repository, IUnitOfWork unitOfWork, ILogger logger)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<NutritionResult> CalculateConsumedMealAsync(IReadOnlyCollection<ConsumedMealDto> meals, CancellationToken ct)
        {
            if (meals.Count == 0)
                return new NutritionResult(0, 0, 0, 0);

            var mealIds = meals
                .Select(m => m.MealId)
                .Distinct()
                .ToList();

            var dbMeals = await _mealRepository.GetAllAsync(mealIds, ct);

            var mealMap = dbMeals.ToDictionary(m => m.Id);

            double calories = 0;
            double proteins = 0;
            double fats = 0;
            double carbs = 0;

            foreach (var consumed in meals)
            {
                if (!mealMap.TryGetValue(consumed.MealId, out var meal))
                    continue;

                var factor = consumed.ConsumedGrams / 100.0;

                calories += meal.CaloriesPer100g * factor;
                proteins += meal.ProteinsPer100g * factor;
                fats += meal.FatsPer100g * factor;
                carbs += meal.CarbsPer100g * factor;
            }

            return new NutritionResult(
                Calories: Math.Round(calories, 2),
                Proteins: Math.Round(proteins, 2),
                Fats: Math.Round(fats, 2),
                Carbs: Math.Round(carbs, 2)
            );
        }

        public DailyNutritionNorm CalculateDailyNorm(DailyNormRequest request)
        {
            double bmr = request.Gender == Gender.Male
                ? 10 * request.WeightKg + 6.25 * request.HeightCm - 5 * request.Age + 5
                : 10 * request.WeightKg + 6.25 * request.HeightCm - 5 * request.Age - 161;

            double activityFactor = request.ActivityLevel switch
            {
                ActivityLevel.Low => 1.2,
                ActivityLevel.Moderate => 1.55,
                ActivityLevel.High => 1.75,
                _ => 1.2
            };

            double calories = bmr * activityFactor;

            double proteinsCalories = calories * 0.30;
            double fatsCalories = calories * 0.25;
            double carbsCalories = calories * 0.45;

            return new DailyNutritionNorm(
                Calories: Math.Round(calories, 0),
                Proteins: Math.Round(proteinsCalories / 4, 1), 
                Fats: Math.Round(fatsCalories / 9, 1),        
                Carbs: Math.Round(carbsCalories / 4, 1)       
            );
        }
    }
}

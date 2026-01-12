using AutoMapper;
using PowerUp.Application.Abstarctions;
using PowerUp.Application.Abstarctions.Repositories;
using PowerUp.Application.Abstarctions.Services;
using PowerUp.Application.Requests.Base;
using PowerUp.Application.Requests.Meals;
using PowerUp.Application.Requests.Subscriptions;
using PowerUp.Application.Responses.Base;
using PowerUp.Application.Responses.Meals;
using PowerUp.Domain.Models.Meals;


namespace PowerUp.Application.Services.Meals
{
    public sealed class MealService : IMealService
    {
        private readonly IMealRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private const int MAX_LIMIT = 100;

        public MealService(IMealRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<ResponseList<MealResponse>> GetAllAsync(Request request, CancellationToken ct = default)
        {
            try
            {
                var limit = request.Limit <= 0 ? MAX_LIMIT : Math.Min(request.Limit, MAX_LIMIT);
                var offset = request.Offset < 0 ? 0 : request.Offset;

                var (meals, totalCount) = await _repository.GetAllAsync(request, ct);

                var data = meals.Select(m => _mapper.Map<MealResponse>(m)).ToList();
                var totalPages = totalCount == 0 ? 0 : (int)Math.Ceiling(totalCount / (double)limit);

                return new ResponseList<MealResponse>(
                    Error: null,
                    Limit: limit,
                    Offset: offset,
                    Items: totalCount,
                    Pages: totalPages,
                    Data: data
                );
            }
            catch (Exception ex)
            {
                return new ResponseList<MealResponse>(Error: "Unexpected error: " + ex.Message);
            }
        }
        
        public async Task<Response<MealResponse>> GetByIdAsync(Guid id, CancellationToken ct = default)
        {
            try
            {
                var meal = await _repository.GetByIdAsync(id, ct);
                if (meal is null)
                    return new Response<MealResponse>(Error: $"Meal with id {id} not found");

                var response = _mapper.Map<MealResponse>(meal);
                return new Response<MealResponse>(Data: response);
            }
            catch (Exception ex)
            {
                return new Response<MealResponse>(Error: "Unexpected error: " + ex.Message);
            }
        }
        
        public async Task<Response> AddAsync(CreateMeal request, CancellationToken ct = default)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.Name))
                    return new Response(Error: "Meal name is required");

                var meal = _mapper.Map<Meal>(request);
                _repository.Add(meal);

                await _unitOfWork.SaveChangesAsync(ct);

                return new Response(Id: meal.Id, Message: "Meal created");
            }
            catch (Exception ex)
            {
                return new Response(Error: "Unexpected error: " + ex.Message);
            }
        }
        
        public async Task<Response> UpdateAsync(Guid id, UpdateSubscription request, CancellationToken ct = default)
        {
            try
            {
                var meal = await _repository.GetByIdAsync(id, ct);
                if (meal is null)
                    return new Response(Error: $"Meal with id {id} not found");

                _mapper.Map(request, meal);
                await _unitOfWork.SaveChangesAsync(ct);

                return new Response(Id: meal.Id, Message: "Meal updated");
            }
            catch (Exception ex)
            {
                return new Response(Error: "Unexpected error: " + ex.Message);
            }
        }
        
        public async Task<Response> DeleteAsync(Guid id, CancellationToken ct = default)
        {
            try
            {
                var meal = await _repository.GetByIdAsync(id, ct);
                if (meal is null)
                    return new Response(Error: $"Meal with id {id} not found");

                _repository.Delete(meal);
                await _unitOfWork.SaveChangesAsync(ct);

                return new Response(Id: id, Message: "Meal deleted");
            }
            catch (Exception ex)
            {
                return new Response(Error: "Unexpected error: " + ex.Message);
            }
        }
        
        public async Task<Response<NutritionResult>> CalculateConsumedMealAsync(
            IReadOnlyCollection<ConsumedMealDto> meals, CancellationToken ct = default)
        {
            try
            {
                if (meals == null || meals.Count == 0)
                    return new Response<NutritionResult>(Data: new NutritionResult(0, 0, 0, 0));
                
                var mealIds = meals.Select(m => m.Id).ToList();
                
                var allMeals = await _repository.GetByIdsAsync(mealIds, ct);
                
                var mealDict = allMeals.ToDictionary(m => m.Id, m => m);

                double calories = 0, proteins = 0, fats = 0, carbs = 0;

                foreach (var consumed in meals)
                {
                    if (!mealDict.TryGetValue(consumed.Id, out var meal))
                        continue;

                    calories += meal.Calories * consumed.ConsumedGrams;
                    proteins += meal.Proteins * consumed.ConsumedGrams;
                    fats += meal.Fats * consumed.ConsumedGrams;
                    carbs += meal.Carbs * consumed.ConsumedGrams;
                }

                var result = new NutritionResult(calories, proteins, fats, carbs);
                return new Response<NutritionResult>(Data: result);
            }
            catch (Exception ex)
            {
                return new Response<NutritionResult>(Error: "Unexpected error: " + ex.Message);
            }
        }
        
        public Response<NutritionResult> CalculateDailyNorm(DailyNormRequest request)
        {
            try
            {
                double bmr = request.Gender switch
                {
                    Gender.Male => 10 * request.WeightKg + 6.25 * request.HeightCm - 5 * request.Age + 5,
                    Gender.Female => 10 * request.WeightKg + 6.25 * request.HeightCm - 5 * request.Age - 161,
                    _ => throw new ArgumentException("Invalid gender")
                };
                
                double activityFactor = request.ActivityLevel switch
                {
                    ActivityLevel.Low => 1.2,
                    ActivityLevel.Moderate => 1.55,
                    ActivityLevel.High => 1.9,
                    _ => 1.0
                };

                double calories = bmr * activityFactor;

                double proteins = request.WeightKg * 1.5; 
                double fats = request.WeightKg * 0.8;  
                double carbs = (calories - (proteins * 4 + fats * 9)) / 4;
                
                var result = new NutritionResult(calories, proteins, fats, carbs);

                return new Response<NutritionResult>(Data: result);
            }
            catch (Exception ex)
            {
                return new Response<NutritionResult>(Error: "Unexpected error: " + ex.Message);
            }
        }
    }
}
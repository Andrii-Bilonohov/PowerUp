namespace PowerUp.Domain.Abstarctions.Services
{
    public interface IMealsService
    {
        Task<NutritionResult> CalculateConsumedMealAsync(IReadOnlyCollection<ConsumedMealDto> meals, CancellationToken ct = default);
        DailyNutritionNorm CalculateDailyNorm(DailyNormRequest request);
    }
}

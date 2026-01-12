using PowerUp.Application.Requests.Base;
using PowerUp.Application.Requests.Meals;
using PowerUp.Application.Requests.Subscriptions;
using PowerUp.Application.Responses.Base;
using PowerUp.Application.Responses.Meals;

namespace PowerUp.Application.Abstarctions.Services
{
    public interface IMealService
    {
        Task<ResponseList<MealResponse>> GetAllAsync(Request request, CancellationToken ct = default);
        Task<Response<MealResponse>> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<Response> DeleteAsync(Guid id, CancellationToken ct = default);
        Task<Response> UpdateAsync(Guid id, UpdateSubscription request, CancellationToken ct = default);
        Task<Response> AddAsync(CreateMeal request, CancellationToken ct = default);
        Task<Response<NutritionResult>> CalculateConsumedMealAsync(IReadOnlyCollection<ConsumedMealDto> meals, CancellationToken ct = default);
        Response<NutritionResult> CalculateDailyNorm(DailyNormRequest request);
    }
}

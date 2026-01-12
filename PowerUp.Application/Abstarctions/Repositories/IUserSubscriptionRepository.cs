using PowerUp.Application.Requests.Base;
using PowerUp.Domain.Models.Subscriptions;

namespace PowerUp.Application.Abstarctions.Repositories;

public interface IUserSubscriptionRepository
{
    Task<(IReadOnlyList<UserSubscription> Subscriptions, int TotalCount)> GetAllAsync(Request request, CancellationToken cancellationToken);
    ValueTask<UserSubscription?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Add(UserSubscription subscription);
    void Update(UserSubscription subscription);
    void Delete(UserSubscription subscription);
}
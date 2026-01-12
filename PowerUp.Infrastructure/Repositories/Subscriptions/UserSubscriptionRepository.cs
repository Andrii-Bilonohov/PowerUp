using Microsoft.EntityFrameworkCore;
using PowerUp.Application.Abstarctions.Repositories;
using PowerUp.Application.Requests.Base;
using PowerUp.Domain.Models.Subscriptions;
using PowerUp.Infrastructure.Data;
using PowerUp.Infrastructure.Repositories.Base;

namespace PowerUp.Infrastructure.Repositories.Subscriptions;

public class UserSubscriptionRepository : RepositoryBase<UserSubscription>, IUserSubscriptionRepository
{
    public UserSubscriptionRepository(PowerUpContext context) : base(context) { }

    public async Task<(IReadOnlyList<UserSubscription> Subscriptions, int TotalCount)> GetAllAsync(Request request, CancellationToken ct)
    {
        IQueryable<UserSubscription> query = DbSet.AsNoTracking();

        var totalCount = await query.CountAsync(ct);

        var userSubscriptions = await query
            .OrderBy(u => u.Id)
            .Skip(request.Offset)
            .Take(request.Limit)
            .ToListAsync(ct);

        return (userSubscriptions, totalCount);
    }
}

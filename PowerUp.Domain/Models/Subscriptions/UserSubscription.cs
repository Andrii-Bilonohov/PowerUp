using PowerUp.Domain.Models.Base;

namespace PowerUp.Domain.Models.Subscriptions;

public class UserSubscription : BaseEntity
{
    public Guid UserId { get; set; }
    public Guid SubscriptionId { get; set; }
    public DateTime StartAt { get; set; }
    public DateTime EndAt { get; set; }
    public bool IsActive => StartAt <= DateTime.UtcNow &&
                            EndAt >= DateTime.UtcNow;

}
namespace PowerUp.Application.Requests.Subscriptions;

public record BuySubscription
(
    Guid UserId,
    DateTime StartAt,
    DateTime EndAt,
    bool IsActive
);
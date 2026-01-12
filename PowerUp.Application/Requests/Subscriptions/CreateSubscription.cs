using PowerUp.Domain.Models.Subscriptions.Enums;

namespace PowerUp.Application.Requests.Subscriptions;

public record CreateSubscription
    ( 
        string Title,
        string Description,
        SubscriptionType Type,
        decimal Price
    );
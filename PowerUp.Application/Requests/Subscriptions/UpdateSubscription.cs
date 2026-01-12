using PowerUp.Domain.Models.Subscriptions.Enums;

namespace PowerUp.Application.Requests.Subscriptions;

public record UpdateSubscription
    ( 
        string Title,
        string Description,
        SubscriptionType Type,
        decimal Price,
        decimal Discount
    );
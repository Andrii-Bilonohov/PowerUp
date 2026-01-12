using PowerUp.Domain.Models.Subscriptions.Enums;

namespace PowerUp.Application.Responses.Subscriptions;

public record SubscriptionResponse
    ( 
        Guid Id,
        Guid UserId,
        string Title,
        string Description,
        SubscriptionType Type,
        decimal Price,
        double Discount,
        DateTime StartAt,
        DateTime EndAt
    );
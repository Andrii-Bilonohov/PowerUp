using PowerUp.Domain.Models.Meals.Enums;

namespace PowerUp.Application.Responses.Meals;

public record MealResponse
(
    Guid Id,
    string Name,
    string? ImageUrl,
    MealTimeType MealTimeType,
    double PortionInGrams,
    double Calories,
    double Fats,
    double Carbs,
    double Proteins
);
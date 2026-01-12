using PowerUp.Domain.Models.Meals.Enums;

namespace PowerUp.Application.Requests.Meals;

public record UpdateMeal 
(
    string Name,
    string? ImageUrl,
    MealTimeType MealTimeType,
    int PortionInGrams,
    int Calories,
    double Fats,
    double Carbs,
    double Proteins
    );
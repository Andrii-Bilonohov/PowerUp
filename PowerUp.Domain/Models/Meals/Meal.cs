using PowerUp.Domain.Models.Base;
using PowerUp.Domain.Models.Meals.Enums;

namespace PowerUp.Domain.Models.Meals;

public class Meal : BaseEntity
{
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
    public MealTimeType MealTimeType { get; set; }

    public double PortionInGrams { get; set; }
    public double Calories { get; set; }
    public double Fats { get; set; }
    public double Carbs { get; set; }
    public double Proteins { get; set; }
}
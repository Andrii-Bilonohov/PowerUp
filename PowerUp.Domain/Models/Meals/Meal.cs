using PowerUp.Domain.Enums;

namespace PowerUp.Domain.Models.Meals;

public class Meal
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? ImageUrl { get; set; }
    public MealTimeType MealTimeType { get; set; }

    public int PortionInGrams { get; set; }
    public int Calories { get; set; }
    public double Fats { get; set; }
    public double Carbs { get; set; }
    public double Proteins { get; set; }
}
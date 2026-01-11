namespace PowerUp.Application.Services.Meals.DTOs.Requests
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum ActivityLevel
    {
        Low,        
        Moderate,   
        High        
    }

    public record DailyNormRequest
    (
        Gender Gender,
        int Age,
        double HeightCm,
        double WeightKg,
        ActivityLevel ActivityLevel
    );

}

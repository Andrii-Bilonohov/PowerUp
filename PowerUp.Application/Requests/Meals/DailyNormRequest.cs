namespace PowerUp.Application.Requests.Meals
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

using PowerUp.Domain.Enums;

namespace PowerUp.Application.Services.Trainings;

public class TrainingResponse
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public int Rating { get; set; }
    
    public DifficultyLevel DifficultyLevel { get; set; }
    public TrainingType TrainingType { get; set; }
    public TrainingStructure TrainingStructure { get; set; }
    public TrainingFormat TrainingFormat { get; set; }
    public TrainingGoal TrainingGoal { get; set; }
    public TrainingIntensity TrainingIntensity { get; set; }
    public int IntervalTime { get; set; }
}
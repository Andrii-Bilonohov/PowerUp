using PowerUp.Domain.Models.Base;
using PowerUp.Domain.Models.Trainings.Enums;

namespace PowerUp.Domain.Models.Trainings;

public class Training : BaseEntity
{
    public required string Name { get; set; }
    public int Rating { get; set; }
    
    public DifficultyLevel DifficultyLevel { get; set; }
    public TrainingType TrainingType { get; set; }
    public TrainingStructure TrainingStructure { get; set; }
    public TrainingFormat TrainingFormat { get; set; }
    public TrainingGoal TrainingGoal { get; set; }
    public TrainingIntensity TrainingIntensity { get; set; }
    public int IntervalTime { get; set; }

    public ICollection<Exercise> Exercises { get; set; } = new List<Exercise>();
}
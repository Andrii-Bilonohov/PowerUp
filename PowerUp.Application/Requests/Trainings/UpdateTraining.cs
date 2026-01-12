using PowerUp.Domain.Models.Trainings.Enums;

namespace PowerUp.Application.Requests.Trainings;

public record UpdateTraining
(
    string Name,
    DifficultyLevel DifficultyLevel,
    TrainingType TrainingType,
    TrainingStructure TrainingStructure,
    TrainingFormat TrainingFormat,
    TrainingGoal TrainingGoal,
    TrainingIntensity TrainingIntensity,
    int IntervalTime
);
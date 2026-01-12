using PowerUp.Domain.Models.Trainings.Enums;

namespace PowerUp.Application.Responses.Trainings;

public record TrainingResponse
    (
    Guid Id,
    string Name,
    int Rating,
    DifficultyLevel DifficultyLevel,
    TrainingType TrainingType,
    TrainingStructure TrainingStructure,
    TrainingFormat TrainingFormat,
    TrainingGoal TrainingGoal,
    TrainingIntensity TrainingIntensity,
    int IntervalTime
    );
using System.Runtime.Serialization;

namespace PowerUp.Domain.Enums;

public enum TrainingGoal
{
    [EnumMember(Value = "muscle_gain")]
    MuscleGain = 1,
    [EnumMember(Value = "fat_loss")]
    FatLoss = 2,
    [EnumMember(Value = "strength_increase")]
    StrengthIncrease = 3,
    [EnumMember(Value = "conditioning")]
    Conditioning = 4,
    [EnumMember(Value = "rehabilitation")]
    Rehabilitation = 5,
    [EnumMember(Value = "injury_prevention")]
    InjuryPrevention = 6,
    [EnumMember(Value = "health_maintenance")]
    HealthMaintenance = 7
}
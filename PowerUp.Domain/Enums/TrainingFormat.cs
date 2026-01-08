using System.Runtime.Serialization;

namespace PowerUp.Domain.Enums;

public enum TrainingFormat
{
    [EnumMember(Value = "gym")]
    Gym = 1,
    [EnumMember(Value = "home")]
    Home = 2,
    [EnumMember(Value = "outdoor")]
    Outdoor = 3,
    [EnumMember(Value = "bodyweight")]
    Bodyweight = 4,
    [EnumMember(Value = "free_weights")]
    FreeWeights = 5,
    [EnumMember(Value = "machines")]
    Machines = 6
}
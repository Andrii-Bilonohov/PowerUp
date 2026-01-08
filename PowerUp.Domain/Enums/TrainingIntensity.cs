using System.Runtime.Serialization;

namespace PowerUp.Domain.Enums;

public enum TrainingIntensity
{
    [EnumMember(Value = "low")]
    Low = 1,
    [EnumMember(Value = "moderate")]
    Moderate = 2,
    [EnumMember(Value = "high")]
    High = 3,
    [EnumMember(Value = "maximal")]
    Maximal = 4
}
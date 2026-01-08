using System.Runtime.Serialization;

namespace PowerUp.Domain.Enums;

public enum DifficultyLevel
{
    [EnumMember(Value = "beginner")]
    Beginner = 1,
    [EnumMember(Value = "intermediate")]
    Intermediate = 2,
    [EnumMember(Value = "advanced")]
    Advanced = 3
}
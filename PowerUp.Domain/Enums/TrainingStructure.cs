using System.Runtime.Serialization;

namespace PowerUp.Domain.Enums;

public enum TrainingStructure
{
    [EnumMember(Value = "full_body")]
    FullBody = 1,
    [EnumMember(Value = "upper_body")]
    UpperBody = 2,
    [EnumMember(Value = "lower_body")]
    LowerBody = 3,
    [EnumMember(Value = "push")]
    Push = 4,
    [EnumMember(Value = "pull")]
    Pull = 5,
    [EnumMember(Value = "legs")]
    Legs = 6,
    [EnumMember(Value = "split")]
    Split = 7
}
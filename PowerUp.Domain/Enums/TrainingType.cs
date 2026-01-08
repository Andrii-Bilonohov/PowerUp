using System.Runtime.Serialization;

namespace PowerUp.Domain.Enums;

public enum TrainingType
{
    [EnumMember(Value = "strength")]
    Strength = 1,
    [EnumMember(Value = "cardio")]
    Cardio = 2,
    [EnumMember(Value = "functional")]
    Functional = 3,
    [EnumMember(Value = "mobility")]
    Mobility = 4,
    [EnumMember(Value = "flexibility")]
    Flexibility = 5,
    [EnumMember(Value = "endurance")]
    Endurance = 6,
    [EnumMember(Value = "power")]
    Power = 7,
    [EnumMember(Value = "balance")]
    Balance = 8
}
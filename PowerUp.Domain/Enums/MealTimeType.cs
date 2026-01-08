using System.Runtime.Serialization;

namespace PowerUp.Domain.Enums;

public enum MealTimeType
{
    [EnumMember(Value = "lunch")]
    Lunch = 1,
    [EnumMember(Value = "breakfast")]
    Breakfast = 2,
    [EnumMember(Value = "dinner")]
    Dinner = 3,
    [EnumMember(Value = "all")]
    All = 4,
}
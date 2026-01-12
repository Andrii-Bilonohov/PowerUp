using AutoMapper;
using PowerUp.Application.Requests.Meals;
using PowerUp.Application.Responses.Meals;
using PowerUp.Domain.Models.Meals;

namespace PowerUp.Application.Profiles.Meals;

public class MealProfile : Profile
{
    public MealProfile()
    {
        CreateMap<CreateMeal, Meal>()
            .ReverseMap();
        CreateMap<UpdateMeal, Meal>()
            .ReverseMap();

        CreateMap<Meal, MealResponse>();
    }
}
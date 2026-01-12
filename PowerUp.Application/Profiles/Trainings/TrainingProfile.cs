using AutoMapper;
using PowerUp.Application.Requests.Trainings;
using PowerUp.Application.Responses.Trainings;
using PowerUp.Domain.Models.Trainings;

namespace PowerUp.Application.Profiles.Trainings;

public class TrainingProfile : Profile
{
    public TrainingProfile()
    {
        CreateMap<Training, TrainingResponse>();
        
        CreateMap<CreateTraining, Training>()
            .ReverseMap();
        CreateMap<UpdateTraining, Training>()
            .ReverseMap();
    }
}
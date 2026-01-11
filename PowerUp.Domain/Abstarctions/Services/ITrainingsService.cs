using PowerUp.Domain.Requests.Trainings;
using PowerUp.Domain.Responses;

namespace PowerUp.Domain.Abstarctions.Services
{
    public interface ITrainingsService
    {
        Task<ResponseList<TrainingResponse>> GetAllAsync(TrainingsRequest request, CancellationToken cancellationToken = default);
        Task<TrainingResponse> AddAsync(CreateTrainingRequest request, CancellationToken cancellationToken = default);
    }
}

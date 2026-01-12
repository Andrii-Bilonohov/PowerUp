using PowerUp.Application.Requests.Base;
using PowerUp.Application.Requests.Trainings;
using PowerUp.Application.Responses.Base;
using PowerUp.Application.Responses.Trainings;

namespace PowerUp.Application.Abstarctions.Services
{
    public interface ITrainingService
    {
        Task<ResponseList<TrainingResponse>> GetAllAsync(Request request, CancellationToken ct = default);
        Task<Response<TrainingResponse>> GetByIdAsync(Guid id, CancellationToken ct = default);
        Task<Response> AddAsync(CreateTraining request, CancellationToken ct = default);
        Task<Response> DeleteAsync(Guid id, CancellationToken ct = default);
        Task<Response> UpdateAsync(Guid id, UpdateTraining request, CancellationToken ct = default);
    }
}

using PowerUp.Domain.Models.Trainings;
using PowerUp.Domain.Requests.Trainings;
using PowerUp.Domain.Responses;

namespace PowerUp.Domain.Abstarctions.Repositories;

public interface ITrainingRepository
{
    Task<ResponseList<Training>> GetAllAsync(TrainingsRequest request, CancellationToken cancellationToken);
    ValueTask<Training?> GetByIdAsync(int id, CancellationToken cancellationToken);
    
    void Add(Training training);
    void Update(Training training);
    void Delete(Training training);
}
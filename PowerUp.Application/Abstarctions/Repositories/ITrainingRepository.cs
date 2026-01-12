using PowerUp.Application.Requests.Base;
using PowerUp.Domain.Models.Trainings;

namespace PowerUp.Application.Abstarctions.Repositories;

public interface ITrainingRepository
{
    Task<(IReadOnlyList<Training> Trainings, int TotalCount)> GetAllAsync(Request request, CancellationToken cancellationToken);
    ValueTask<Training?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Add(Training training);
    void Update(Training training);
    void Delete(Training training);
}
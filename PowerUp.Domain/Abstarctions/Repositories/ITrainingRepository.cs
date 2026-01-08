using PowerUp.Domain.Models.Trainings;

namespace PowerUp.Domain.Abstarctions.Repositories;

public interface ITrainingRepository
{
    Task<List<Training>> GetAll();
    ValueTask<Training> GetById(int id);
    
    void Add(Training training);
    void Update(Training training);
    void Delete(Training training);
}
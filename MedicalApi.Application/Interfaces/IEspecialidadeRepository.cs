using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Interfaces
{
    public interface IEspecialidadeRepository
    {
        Task<IEnumerable<Especialidade>> GetAllAsync();
        Task<Especialidade?> GetByIdAsync(int id);
    }
}
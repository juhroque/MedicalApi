using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Interfaces
{
    public interface IMedicoRepository
    {
        Task<Medico> CreateAsync(Medico medico);
        Task<IEnumerable<Medico>> GetAllAsync();
        Task<Medico?> GetByIdAsync(int id);
        Task UpdateAsync(Medico medico);
        Task DeleteAsync(int id);
    }
}
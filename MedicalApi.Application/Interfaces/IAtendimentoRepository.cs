using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Interfaces
{
    public interface IAtendimentoRepository
    {
        Task<Atendimento> CreateAsync(Atendimento atendimento);
        Task<IEnumerable<Atendimento>> GetAllAsync();
        Task<Atendimento?> GetByIdAsync(int id);
        Task UpdateAsync(Atendimento atendimento);
        Task DeleteAsync(int id);
    }
}
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Interfaces
{
    public interface IAgendamentoRepository
    {
        Task<Agendamento> CreateAsync(Agendamento agendamento);
        Task<IEnumerable<Agendamento>> GetAllAsync();
        Task<Agendamento?> GetByIdAsync(int id);
        Task UpdateAsync(Agendamento agendamento);
        Task DeleteAsync(int id);
    }
}
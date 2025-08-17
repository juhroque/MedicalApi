using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Interfaces
{
    public interface IPacienteRepository
    {
        Task<Paciente> CreateAsync(Paciente paciente);
        Task<IEnumerable<Paciente>> GetAllAsync();
        Task<Paciente?> GetByIdAsync(int id);
        Task<Paciente?> GetByUserIdAsync(Guid id);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(int id);
    }
}
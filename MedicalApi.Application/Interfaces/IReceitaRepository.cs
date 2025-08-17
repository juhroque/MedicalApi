using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Interfaces
{
    public interface IReceitaRepository
    {
        Task<Receita> CreateAsync(Receita receita);
        Task<IEnumerable<Receita>> GetAllAsync();
        Task<Receita?> GetByIdAsync(int id);
        Task UpdateAsync(Receita receita);
        Task DeleteAsync(int id);
    }
}
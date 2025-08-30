using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> CreateAsync(Usuario usuario);
        Task<IEnumerable<Usuario>> GetAllAsync();
        Task<(IEnumerable<Usuario> Items, int TotalCount)> GetPagedAsync(int page, int pageSize);
        Task<Usuario?> GetByIdAsync(Guid id);
        Task<Usuario?> GetByEmailAsync(string email);
        Task<Usuario?> GetByCPFAsync(string cpf);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(Guid id);
    }
}
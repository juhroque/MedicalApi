using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Interfaces
{
    public interface IRoleRepository
    {
        Task<IEnumerable<Role>> GetAllAsync();
        Task<Role?> GetByIdAsync(int id);
    }
}
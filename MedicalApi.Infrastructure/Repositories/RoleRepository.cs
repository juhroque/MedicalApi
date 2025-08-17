using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Repositories
{
    public class RoleRepository(AppDbContext context) : IRoleRepository
    {
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            return await context.Roles.AsNoTracking().ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await context.Roles.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
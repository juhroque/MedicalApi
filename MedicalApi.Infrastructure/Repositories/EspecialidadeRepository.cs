using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Repositories
{
    public class EspecialidadeRepository(AppDbContext context) : IEspecialidadeRepository
    {
        public async Task<IEnumerable<Especialidade>> GetAllAsync()
        {
            return await context.Especialidades.AsNoTracking().ToListAsync();
        }

        public async Task<Especialidade?> GetByIdAsync(int id)
        {
            return await context.Especialidades.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
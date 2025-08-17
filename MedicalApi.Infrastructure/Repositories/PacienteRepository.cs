using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Repositories
{
    public class PacienteRepository(AppDbContext context) : IPacienteRepository
    {
        public async Task<Paciente> CreateAsync(Paciente paciente)
        {
            await context.Pacientes.AddAsync(paciente);
            await context.SaveChangesAsync();
            return paciente;
        }

        public async Task<IEnumerable<Paciente>> GetAllAsync()
        {
            return await context.Pacientes.AsNoTracking().ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(int id)
        {
            return await context.Pacientes.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            context.Pacientes.Update(paciente);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Pacientes.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            context.Pacientes.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<Paciente?> GetByUserIdAsync(Guid id)
        {
           return await context.Pacientes.AsNoTracking().FirstOrDefaultAsync(x => x.UsuarioId == id);
        }
    }
}
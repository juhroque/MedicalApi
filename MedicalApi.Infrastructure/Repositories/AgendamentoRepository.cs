using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Repositories
{
    public class AgendamentoRepository(AppDbContext context) : IAgendamentoRepository
    {
        public async Task<Agendamento> CreateAsync(Agendamento agendamento)
        {
            await context.Agendamentos.AddAsync(agendamento);
            await context.SaveChangesAsync();
            return agendamento;
        }

        public async Task<IEnumerable<Agendamento>> GetAllAsync()
        {
            return await context.Agendamentos.AsNoTracking().ToListAsync();
        }

        public async Task<Agendamento?> GetByIdAsync(int id)
        {
            return await context.Agendamentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Agendamento agendamento)
        {
            context.Agendamentos.Update(agendamento);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Agendamentos.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            context.Agendamentos.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
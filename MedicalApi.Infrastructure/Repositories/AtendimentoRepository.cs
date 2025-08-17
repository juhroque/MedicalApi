using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Repositories
{
    public class AtendimentoRepository(AppDbContext context) : IAtendimentoRepository
    {
        public async Task<Atendimento> CreateAsync(Atendimento atendimento)
        {
            await context.Atendimentos.AddAsync(atendimento);
            await context.SaveChangesAsync();
            return atendimento;
        }

        public async Task<IEnumerable<Atendimento>> GetAllAsync()
        {
            return await context.Atendimentos.AsNoTracking().ToListAsync();
        }

        public async Task<Atendimento?> GetByIdAsync(int id)
        {
            return await context.Atendimentos.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Atendimento atendimento)
        {
            context.Atendimentos.Update(atendimento);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Atendimentos.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            context.Atendimentos.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
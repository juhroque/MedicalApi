using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Repositories
{
    public class ReceitaRepository(AppDbContext context) : IReceitaRepository
    {
        public async Task<Receita> CreateAsync(Receita receita)
        {
            await context.Receitas.AddAsync(receita);
            await context.SaveChangesAsync();
            return receita;
        }

        public async Task<IEnumerable<Receita>> GetAllAsync()
        {
            return await context.Receitas.AsNoTracking().ToListAsync();
        }

        public async Task<Receita?> GetByIdAsync(int id)
        {
            return await context.Receitas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Receita receita)
        {
            context.Receitas.Update(receita);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Receitas.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            context.Receitas.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
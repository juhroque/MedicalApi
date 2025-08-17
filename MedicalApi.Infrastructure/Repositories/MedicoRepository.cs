using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Repositories
{
    public class MedicoRepository(AppDbContext context) : IMedicoRepository
    {
        public async Task<Medico> CreateAsync(Medico medico){
            await context.Medicos.AddAsync(medico);
            await context.SaveChangesAsync();
            return medico;
        }

        public async Task<IEnumerable<Medico>> GetAllAsync(){
            return await context.Medicos.AsNoTracking().ToListAsync();
        }

        public async Task<Medico?> GetByIdAsync(int id){
            return await context.Medicos.AsNoTracking().FirstOrDefaultAsync(x=>x.Id == id);
        }

        public async Task UpdateAsync(Medico medico){
            context.Medicos.Update(medico);
            await context.SaveChangesAsync();
        } 
        public async Task DeleteAsync(int id){
            var entity = await context.Medicos.FirstOrDefaultAsync(x => x.Id == id);
            if(entity is null) return;
            context.Medicos.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
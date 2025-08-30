using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Repositories
{
    public class UsuarioRepository(AppDbContext context) : IUsuarioRepository
    {
        public async Task<Usuario> CreateAsync(Usuario usuario)
        {
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            return await context.Usuarios.AsNoTracking().ToListAsync();
        }

        public async Task<(IEnumerable<Usuario> Items, int TotalCount)> GetPagedAsync(int page, int pageSize){
            
            var skip = page * pageSize;
            var usuarios = await context.Usuarios.Skip(skip).Take(pageSize)
                                .AsNoTracking().ToListAsync();

            return (usuarios, usuarios.Count);
        }

        public async Task<Usuario?> GetByIdAsync(Guid id)
        {
            return await context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Usuario?> GetByEmailAsync(string email)
        {
            return await context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.Email == email);
        }
        public async Task<Usuario?> GetByCPFAsync(string cpf)
        {
            return await context.Usuarios.AsNoTracking().FirstOrDefaultAsync(x => x.CPF == cpf);
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            context.Usuarios.Update(usuario);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null) return;
            context.Usuarios.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
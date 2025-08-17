using MedicalApi.Domain.Entities;
using MedicalApi.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace MedicalApi.Infrastructure.Data {
    

    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options) {

        public DbSet<Agendamento> Agendamentos {get; set;}
        public DbSet<Atendimento> Atendimentos {get; set;}
        public DbSet<Paciente> Pacientes {get; set;}
        public DbSet<Medico> Medicos {get; set;}
        public DbSet<Receita> Receitas {get; set;}
        public DbSet<Usuario> Usuarios {get; set;}
        public DbSet<Especialidade> Especialidades {get; set;}
        public DbSet<ReceitaItem> ReceitaItems {get; set;}
        public DbSet<Role> Roles {get; set;}           

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AgendamentoMapping());
            modelBuilder.ApplyConfiguration(new AtendimentoMapping());
            modelBuilder.ApplyConfiguration(new PacienteMapping());
            modelBuilder.ApplyConfiguration(new MedicoMapping());
            modelBuilder.ApplyConfiguration(new ReceitaMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());
            modelBuilder.ApplyConfiguration(new ReceitaItemMapping());
        }
    }
}
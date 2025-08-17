using System.Security.Cryptography.X509Certificates;
using MedicalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalApi.Infrastructure.Mappings
{
    public class AgendamentoMapping : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();


            builder.Property(x => x.DataHoraInicio)
                .IsRequired()
                .HasColumnName("DataHoraInicio")
                .HasColumnType("DATETIME");

            builder.Property(x => x.DuracaoMinutos)
                .IsRequired()
                .HasColumnName("DuracaoMinutos")
                .HasColumnType("INT");

            builder.Property(x => x.TipoConsulta)
                .IsRequired()
                .HasColumnName("TipoConsulta")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(x => x.Observacoes)
                .IsRequired(false)
                .HasColumnName("Observacoes")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            //1 agendamento = 1 atendimento

            builder
                .HasOne(x => x.Atendimento)
                .WithOne(x => x.Agendamento);

            // 1 agendamento = 1 medico (mas 1 medico tem N atendimentos)

            builder.HasOne(x => x.Paciente)
                .WithMany()
                .HasForeignKey(x => x.PacienteId);

            builder
                .HasOne<Usuario>() // Sem propriedade de navegação
                .WithMany()
                .HasForeignKey(x => x.CriadoPorUsuarioId);

            builder.HasOne(x => x.Medico)
                .WithMany()
                .HasForeignKey(x => x.MedicoId);

        }
    }
}
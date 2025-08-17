using MedicalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalApi.Infrastructure.Mappings {
    public class AtendimentoMapping : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            builder.ToTable("Atendimentos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.DataHoraInicio)
                .IsRequired()
                .HasColumnType("DATETIME");

            builder.Property(x => x.DataHoraFim)
                .HasColumnType("DATETIME");

            builder.Property(x => x.QueixaPrincipal)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.Property(x => x.Diagnostico)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000);

            builder.Property(x => x.ProcedimentosRealizados)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1000);

            builder.Property(x => x.Observacoes)
                .IsRequired(false)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            // Relacionamentos
            builder.HasOne(x => x.Agendamento)
                .WithOne(x => x.Atendimento)
                .HasForeignKey<Atendimento>(x => x.AgendamentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Receitas)
                .WithOne(x => x.Atendimento)
                .HasForeignKey(x => x.AtendimentoId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
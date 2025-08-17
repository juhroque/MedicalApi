using MedicalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalApi.Infrastructure.Mappings
{
    public class PacienteMapping : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> builder)
        {
            builder.ToTable("Pacientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Convenio)
            .IsRequired(false)
                .HasColumnName("Convenio")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Altura)
            .IsRequired(false)
                .HasColumnName("Altura")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.Peso)
            .IsRequired(false)
                .HasColumnName("Peso")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.TipoSanguineo)
            .IsRequired(false)
                .HasColumnName("TipoSanguineo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(x => x.IsDoadorDeOrgaos)
            .IsRequired()
            .HasColumnName("IsDoadorDeOrgaos")
            .HasColumnType("bit")
            .HasDefaultValue(false);

            builder
                .HasOne(x => x.Usuario)
                .WithMany().HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}
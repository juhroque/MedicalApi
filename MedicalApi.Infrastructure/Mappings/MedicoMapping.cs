using MedicalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalApi.Infrastructure.Mappings
{
    public class MedicoMapping : IEntityTypeConfiguration<Medico>
    {
        public void Configure(EntityTypeBuilder<Medico> builder)
        {
            builder.ToTable("Medicos");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .IsRequired()
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.CRM)
                .IsRequired()
                .HasColumnName("CRM")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(20);



            builder
              .HasOne(x => x.Usuario)
                .WithMany().HasForeignKey(x => x.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(x => x.Especialidades)
                .WithMany(x => x.Medicos)
                .UsingEntity(j => j.ToTable("MedicosEspecialidades"));
        }
    }
}
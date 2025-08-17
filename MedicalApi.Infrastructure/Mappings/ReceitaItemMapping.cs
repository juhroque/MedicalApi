using MedicalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalApi.Infrastructure.Mappings
{
    public class ReceitaItemMapping : IEntityTypeConfiguration<ReceitaItem>
    {
        public void Configure(EntityTypeBuilder<ReceitaItem> builder)
        {
            builder.ToTable("ReceitaItens");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Medicamento)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(200);

            builder.Property(x => x.Dosagem)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Instrucoes)
                .IsRequired()
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            // Relacionamento já configurado no ReceitaMapping
            // Mas isso é só um reforço
            builder.HasOne(x => x.Receita)
                .WithMany(x => x.Itens)
                .HasForeignKey(x => x.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
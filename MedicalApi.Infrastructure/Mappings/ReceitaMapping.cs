using MedicalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalApi.Infrastructure.Mappings
{
    public class ReceitaMapping : IEntityTypeConfiguration<Receita>
    {
        public void Configure(EntityTypeBuilder<Receita> builder)
        {
            builder.ToTable("Receitas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.DataEmissao)
                .IsRequired()
                .HasColumnType("DATETIME");

            // Relacionamentos
            builder.HasOne(x => x.Atendimento)
                .WithMany(x => x.Receitas)
                .HasForeignKey(x => x.AtendimentoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(x => x.Itens)
                .WithOne(x => x.Receita)
                .HasForeignKey(x => x.ReceitaId)
                .OnDelete(DeleteBehavior.Cascade); // Se deleta receita, deleta itens
        }
    }
}

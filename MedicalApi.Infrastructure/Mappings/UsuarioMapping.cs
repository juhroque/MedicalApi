using MedicalApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MedicalApi.Infrastructure.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired()
                .HasColumnName("Id")
                .HasColumnType("UNIQUEIDENTIFIER")
                .HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd(); // sem UseIdentityColumn()
            
            builder.Property(u => u.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(u => u.Sobrenome)
                .IsRequired()
                .HasColumnName("Sobrenome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(80);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasColumnName("Email")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(u => u.CPF)
                .IsRequired()
                .HasColumnName("CPF")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(11);


            builder.Property(u => u.SenhaHash)
                .IsRequired()
                .HasColumnName("SenhaHash")
                .HasColumnType("VARCHAR")
                .HasMaxLength(255);

            builder.Property(u => u.DataCriacao)
                .IsRequired()
                .HasColumnName("DataCriacao")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()");

            builder.Property(u => u.Status)
                .IsRequired()
                .HasColumnName("Status")
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(u => u.Telefone)
                .IsRequired(false)
                .HasColumnName("Telefone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(15);

            builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Usuarios)
            .UsingEntity(j => j.ToTable("UsuarioRoles"));
        }
    }
}
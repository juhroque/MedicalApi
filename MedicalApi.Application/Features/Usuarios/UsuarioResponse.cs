using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Features.Usuarios
{
    public class UsuarioResponse(Usuario usuario)
    {
        public Guid Id { get; set; } = usuario.Id;
        public string Nome { get; set; } = usuario.Nome;
        public string Sobrenome { get; set; } = usuario.Sobrenome;
        public string Email { get; set; } = usuario.Email;
        public string CPF { get; set; } = usuario.CPF;
        public DateTime DataCriacao { get; set; } = usuario.DataCriacao;
        public string? Telefone { get; set; } = usuario.Telefone;
        public string Status { get; set; } = usuario.Status;

    }
}

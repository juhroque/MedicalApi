using MediatR;
using MedicalApi.Application.Features.Usuarios.Update;

namespace MedicalApi.Application.Features.Usuarios.Create
{
    public class CreateUsuarioCommand : IRequest<UsuarioResponse>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string? Telefone { get; set; }
    }
}

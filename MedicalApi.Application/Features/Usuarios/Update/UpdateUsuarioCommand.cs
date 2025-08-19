using MediatR;

namespace MedicalApi.Application.Features.Usuarios.Update
{
    public class UpdateUsuarioCommand : IRequest<UsuarioResponse>
    {
        public Guid Id {get; set;}
        public string? Nome { get; set; }
        public string? Sobrenome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public string? Status { get; set; } 
        public string? Telefone { get; set; } 
    }
}

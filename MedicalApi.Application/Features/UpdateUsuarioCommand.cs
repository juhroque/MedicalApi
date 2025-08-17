using MediatR;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Features
{
    public class UpdateUsuarioCommand : IRequest<Usuario>
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
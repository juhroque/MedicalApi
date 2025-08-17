using MediatR;

namespace MedicalApi.Application.Features
{
    public class CreateUsuarioCommand : IRequest<Guid>
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }
        public string? Telefone { get; set; }
    }


    
}
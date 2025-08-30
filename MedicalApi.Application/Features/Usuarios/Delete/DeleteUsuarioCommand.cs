using MediatR;

namespace MedicalApi.Application.Features.Usuarios.Delete
{
    public class DeleteUsuarioCommand : IRequest<bool> 
    {
        public Guid Id { get; set; } //se é igual aquela query compensa fazer assim?
    }
}
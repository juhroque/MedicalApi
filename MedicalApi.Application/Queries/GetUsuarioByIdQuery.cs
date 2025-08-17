using MediatR;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Queries
{
    public class GetUsuarioByIdQuery : IRequest<Usuario?>
    {
        public Guid Id { get; set; }
    }
}
using MediatR;
using MedicalApi.Application.Features.Usuarios;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Queries
{
    public class GetUsuarioByIdQuery : IRequest<GetUsuarioByIdResponse?>
    {
        public Guid Id { get; set; }
    }
}
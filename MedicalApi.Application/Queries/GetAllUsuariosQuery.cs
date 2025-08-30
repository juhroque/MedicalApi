using MediatR;
using MedicalApi.Application.Features.Usuarios;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Queries
{
    public class GetAllUsuariosQuery : IRequest<IList<UsuarioResponse>>
    {
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
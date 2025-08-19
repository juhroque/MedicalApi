using MediatR;
using MedicalApi.Application.Features.Usuarios;
using MedicalApi.Application.Interfaces;
using MedicalApi.Application.Queries;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Handlers
{
    public class GetUsuarioByIdHandler(
        IUsuarioRepository usuarioRepository
    ) : IRequestHandler<GetUsuarioByIdQuery, GetUsuarioByIdResponse?>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<GetUsuarioByIdResponse?> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
            var response = new GetUsuarioByIdResponse(usuario);
            return response;
        }
    }
}
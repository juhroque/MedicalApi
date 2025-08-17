using MediatR;
using MedicalApi.Application.Interfaces;
using MedicalApi.Application.Queries;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Handlers
{
    public class GetUsuarioByIdHandler(
        IUsuarioRepository usuarioRepository
    ) : IRequestHandler<GetUsuarioByIdQuery, Usuario?>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<Usuario?> Handle(GetUsuarioByIdQuery request, CancellationToken cancellationToken)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(request.Id);
            return usuario;
        }
    }
}
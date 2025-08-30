using MediatR;
using MedicalApi.Application.Features.Usuarios;
using MedicalApi.Application.Interfaces;
using MedicalApi.Application.Queries;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Handlers
{
    public class GetAllUsuariosHandler(IUsuarioRepository usuarioRepository
    ) : IRequestHandler<GetAllUsuariosQuery, IList<UsuarioResponse>>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        public async Task<IList<UsuarioResponse>> Handle(GetAllUsuariosQuery request, CancellationToken cancellationToken)
        {
            var usuarios = await _usuarioRepository.GetAllAsync();
            var response = usuarios.Select(usuario => new UsuarioResponse(usuario)).ToList();
            return response;
        }
    }
}
using MediatR;
using MedicalApi.Application.Features.Usuarios.Delete;
using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Exceptions;

namespace MedicalApi.Application.Handlers
{
    public class DeleteUsuarioHandler( IUsuarioRepository usuarioRepository
    ) : IRequestHandler<DeleteUsuarioCommand, bool>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<bool> Handle(DeleteUsuarioCommand request, CancellationToken cancellationToken)
        {
            // Verifica se o usuário existe antes de tentar deletar
            var usuarioExiste = await _usuarioRepository.GetByIdAsync(request.Id) ?? throw new UsuarioNaoEncontradoException(request.Id);
            await _usuarioRepository.DeleteAsync(request.Id);
            return true;
        }
    }
}
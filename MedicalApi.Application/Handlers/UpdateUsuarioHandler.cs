using MediatR;
using MedicalApi.Application.Features.Usuarios;
using MedicalApi.Application.Features.Usuarios.Update;
using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Handlers
{
    public class UpdateUsuarioHandler(
        IUsuarioRepository usuarioRepository,
        IPasswordHasherService passwordHasherService
    ) : IRequestHandler<UpdateUsuarioCommand, UsuarioResponse>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IPasswordHasherService _passwordHasherService = passwordHasherService;

        public async Task<UsuarioResponse> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var id = request.Id;
            var usuario = await _usuarioRepository.GetByIdAsync(id);

            if(usuario is null)
                throw new Exception("Usuario nao existe"); // editar um usuario que nao existe deve ser um problema
            

            usuario.Email = request.Email ?? usuario.Email;
            usuario.Nome = request.Nome ?? usuario.Nome;
            usuario.Sobrenome = request.Sobrenome ?? usuario.Sobrenome;
            usuario.SenhaHash = request.Senha != null ?_passwordHasherService.Hash(request.Senha) : usuario.SenhaHash;
            usuario.Telefone = request.Telefone;
            usuario.Status = request.Status ?? usuario.Status;

            await _usuarioRepository.UpdateAsync(usuario);
            return new UsuarioResponse(usuario);
        }
    }
}
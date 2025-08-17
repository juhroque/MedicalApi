using MediatR;
using MedicalApi.Application.Features;
using MedicalApi.Application.Interfaces;
using MedicalApi.Application.Queries;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Handlers
{
    public class UpdateUsuarioHandler(
        IUsuarioRepository usuarioRepository,
        IPasswordHasherService passwordHasherService
    ) : IRequestHandler<UpdateUsuarioCommand, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IPasswordHasherService _passwordHasherService = passwordHasherService;

        public async Task<Usuario> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
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
            return usuario;
        }
    }
}
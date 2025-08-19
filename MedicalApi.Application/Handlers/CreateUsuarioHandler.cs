using MedicalApi.Application.Features.Usuarios.Create;
using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;
using MediatR;
using MedicalApi.Application.Features.Usuarios.Update;
using MedicalApi.Application.Features.Usuarios;

namespace MedicalApi.Application.Handlers
{
    public class CreateUsuarioHandler(
        IUsuarioRepository usuarioRepository,
        IPasswordHasherService passwordHasherService) : IRequestHandler<CreateUsuarioCommand, UsuarioResponse>
    {

        // Dependências
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        private readonly IPasswordHasherService _passwordHasherService = passwordHasherService;

        //cancellantion token é tipo um botao de panico pra cancelar 
        public async Task<UsuarioResponse> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            if(await VerifyExistingEmailOrCPF(request.Email, request.CPF)){
                throw new Exception("Email ou CPF já existem");
            }

            var hashPassword = _passwordHasherService.Hash(request.Senha);

            var usuario = new Usuario{
                Nome = request.Nome,
                Sobrenome = request.Sobrenome,
                Email = request.Email,
                CPF = request.CPF,
                SenhaHash = hashPassword,
                Telefone = request.Telefone,
                DataCriacao = DateTime.Now,
                Status = "Ativo",
            };
            await _usuarioRepository.CreateAsync(usuario);

            var response = new UsuarioResponse(usuario);
            return response;
        }

        public async Task<bool> VerifyExistingEmailOrCPF(string email, string cpf){
            var userByCpf = await _usuarioRepository.GetByCPFAsync(cpf);
            if (userByCpf != null) return true; // Se encontrou por CPF, já retorna true

            var userByEmail = await _usuarioRepository.GetByEmailAsync(email);
            if (userByEmail != null) return true; // Se encontrou por Email, retorna true

            return false;
        }
    }
}



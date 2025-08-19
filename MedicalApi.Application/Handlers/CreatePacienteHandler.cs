using System.Text.RegularExpressions;
using MediatR;
using MedicalApi.Application.Features.Pacientes.Create;
using MedicalApi.Application.Interfaces;
using MedicalApi.Domain.Entities;

namespace MedicalApi.Application.Handlers
{
    public class CreatePacienteHandler(IPacienteRepository pacienteRepository, IUsuarioRepository usuarioRepository) : IRequestHandler<CreatePacienteCommand, int>
    {
        private readonly IPacienteRepository _pacienteRepository = pacienteRepository;
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;

        public async Task<int> Handle(CreatePacienteCommand request, CancellationToken cancellationToken)
        {
            if (!IsValidBloodType(request.TipoSanguineo))
                throw new Exception("Tipo sanguíneo inválido");

            var usuario = await _usuarioRepository.GetByCPFAsync(request.CPF);

            if (usuario is null)
                throw new Exception("CPF ainda não associado a um usuário. Criar um usuário primeiro.");

            var pacienteExiste = await _pacienteRepository.GetByUserIdAsync(usuario.Id);
            if (pacienteExiste is not null)
                throw new Exception("Já existe um registro de paciente com esse CPF");


            var paciente = new Paciente
            {
                UsuarioId = usuario.Id,
                Altura = request.Altura,
                Convenio = request.Convenio,
                TipoSanguineo = request.TipoSanguineo,
                IsDoadorDeOrgaos = request.IsDoadorDeOrgaos,
                Peso = request.Peso
            };


            await _pacienteRepository.CreateAsync(paciente);
            return paciente.Id;
        }

        public static bool IsValidBloodType(string bloodType)
        {
            // Regex for common blood types (A, B, AB, O) with optional Rh factor (+ or -)
            string pattern = @"^(A|B|AB|O)[+-]$";
            return Regex.IsMatch(bloodType, pattern, RegexOptions.IgnoreCase);
        }
    }
}
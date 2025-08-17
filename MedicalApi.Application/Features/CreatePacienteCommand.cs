using MediatR;

namespace MedicalApi.Application.Features
{
    public class CreatePacienteCommand : IRequest<int>
    {
        public string CPF { get; set; }
        public string? Convenio { get; set; }
        public string? Altura { get; set; }
        public string? Peso { get; set; }
        public string TipoSanguineo { get; set; }
        public bool IsDoadorDeOrgaos { get; set; }
    }
}
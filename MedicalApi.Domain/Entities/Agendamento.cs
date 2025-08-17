namespace MedicalApi.Domain.Entities
{
    public class Agendamento
    {
        public int Id { get; set; }
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }
        public int MedicoId { get; set; }
        public Medico Medico { get; set; }
        public Guid CriadoPorUsuarioId { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public Atendimento Atendimento {get; set; }
        public int DuracaoMinutos { get; set; }
        public string TipoConsulta { get; set; }
        public string Status { get; set; }
        public string? Observacoes { get; set; }
    }
}
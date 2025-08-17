namespace MedicalApi.Domain.Entities
{
    public class Atendimento
    {
        public int Id { get; set; }
        public DateTime DataHoraInicio { get; set; }
        public DateTime DataHoraFim { get; set; }

        public string? QueixaPrincipal { get; set; }
        public string? Diagnostico { get; set; }
        public Agendamento Agendamento { get; set; }
        public int AgendamentoId { get; set; }
        public string? ProcedimentosRealizados { get; set; }
        public string? Observacoes { get; set; }
        public IList<Receita> Receitas { get; set; } = new List<Receita>();
    }
}
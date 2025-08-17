namespace MedicalApi.Domain.Entities{
    public class Receita{
        public int Id { get; set; }
        public DateTime DataEmissao { get; set; }
        public int AtendimentoId { get; set; }
        public Atendimento Atendimento { get; set; }
        public IList<ReceitaItem> Itens { get; set; } = new List<ReceitaItem>();

    }
}
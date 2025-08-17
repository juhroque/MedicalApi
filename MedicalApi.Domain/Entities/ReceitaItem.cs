namespace MedicalApi.Domain.Entities{
    public class ReceitaItem{
        public int Id { get; set; }
        public string Medicamento { get; set; }
        public string Dosagem { get; set; }
        public string Instrucoes { get; set; }
        public Receita Receita { get; set; }
        public int ReceitaId { get; set; }
    }
}
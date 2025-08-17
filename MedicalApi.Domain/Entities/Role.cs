namespace MedicalApi.Domain.Entities
{
    public class Role
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }
}
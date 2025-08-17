using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MedicalApi.Domain.Entities
{
    public class Medico
    {
        public int Id { get; set; }
        public string CRM { get; set; }
        public Usuario Usuario { get; set; }
        public Guid UsuarioId { get; set; }
        public IList<Especialidade> Especialidades { get; set; } = new List<Especialidade>();

    }
}

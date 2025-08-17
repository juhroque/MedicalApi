using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApi.Domain.Entities
{
    public class Especialidade
    {
        public int Id { get; set; }
        public string Nome { get; set; } 
        public string Descricao { get; set; } 
        public IList<Medico> Medicos { get; set; } = new List<Medico>();

    }
}

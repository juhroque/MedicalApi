using System;
using System.Runtime;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApi.Domain.Entities
{
    public class Paciente 
    {
        public int Id { get; set; }
        public Usuario Usuario { get; set; } 
        public Guid UsuarioId { get; set; }
        public string? Convenio { get; set; }
        public string? Altura { get; set; }
        public string? Peso { get; set; }
        public string? TipoSanguineo { get; set; }
        public bool IsDoadorDeOrgaos { get; set; }

    }
}

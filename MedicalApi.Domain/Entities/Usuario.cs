using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalApi.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string CPF { get; set; }
        public string SenhaHash { get; set; }
        public DateTime DataCriacao { get; set; }
        public string Status { get; set; } 
        public string? Telefone { get; set; } 
        public IList<Role> Roles { get; set; } = new List<Role>();
    }
}

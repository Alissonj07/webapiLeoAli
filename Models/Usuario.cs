using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAliLeo.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public Permissao Permissao { get; set; } = Permissao.usuario; 

        public DateTime CriadoEm { get; set; }
    }
}
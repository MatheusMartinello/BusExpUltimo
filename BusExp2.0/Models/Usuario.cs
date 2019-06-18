using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }
        public string NomeCompleto { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Rua { get; set; }
        public string Cep { get; set; }
        public string Telefone { get; set; }
        public string Senha { get; set; }
        public string Sessao { get; set; }
    }
}
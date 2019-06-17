using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("Motorista")]
    public class Motorista
    {
        [Key]
        public int MotoristaId { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
    }
}
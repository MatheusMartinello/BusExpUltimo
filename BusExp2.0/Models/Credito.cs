using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("Credito")]
    public class Credito
    {
        [Key]
        public int CreditoId { get; set; }
        public Usuario usuario { get; set; }
        [Required(ErrorMessage = "Campo obrigatório!")]
        public FormaPagamento FormaPag { get; set; }
        public double ValorCredito { get; set; }
        public DateTime DataAdicao { get; set; }
        public Credito() {
            DataAdicao = DateTime.Now;
            ValorCredito = 0;
            }
    }
}//
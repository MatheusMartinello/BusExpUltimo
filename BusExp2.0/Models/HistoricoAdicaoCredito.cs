using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("HistoricoAdicaoCredito")]
    public class HistoricoAdicaoCredito
    {
        [Key]
        public int HistoricoAdicaoCreditoId { get; set; }
        public Credito Creditos { get; set; }
    }
}//
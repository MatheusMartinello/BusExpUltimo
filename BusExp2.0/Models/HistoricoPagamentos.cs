using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("HistoricoGasto")]
    public class HistoricoPagamentos
    {
        [Key]
        public int HistoricoPagamentosId { get; set; }
        public LiberaCatraca LiberaCatraca { get; set; }
    }
}
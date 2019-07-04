using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("FormaPagamento")]
    public class FormaPagamento
    {
        [Key]
        public int FormaPagId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
    }
}//
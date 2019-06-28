using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("LiberaCatraca")]
    public class LiberaCatraca
    {
        [Key]
        public int LiberaCatracaId { get; set; }
        
        public Credito credito { get; set; }
        public Usuario usuario { get; set; }
        public DateTime DataPagamento { get; set;}
        public string ValorPago { get; set; }
        public string RuaInicial { get; set; }
        public string RuaFinal { get; set; }
        public LiberaCatraca()
        {
            DataPagamento = DateTime.Now;
        }
    }
}
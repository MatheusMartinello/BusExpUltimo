using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("Onibus")]
    public class Onibus
    {
        [Key]
        public int OnibusId { get; set; }
        public string Nome { get; set; }
        public string Cidade { get; set; }
        public string LatRuaInicial { get; set; }
        public string LonRuaInicial { get; set; }
        public string LatRuaFinal { get; set; }
        public string LonRuaFinal { get; set; }
    }
}//
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{
    [Table("Ranking")]
    public class Ranking
    {
        [Key]
        public int RankingId { get; set; }
        public Motorista Motorista { get; set; }
        public Usuario Usuario { get; set; }
        public string ValorAtribuido { get; set; }

        [MaxLength(200, ErrorMessage = "No máximo 200 caracteres!")]
        
        public string Comentario { get; set; }
    }
}
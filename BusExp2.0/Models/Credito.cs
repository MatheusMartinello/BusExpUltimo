﻿using System;
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
        public FormaPagamento FormaPag { get; set; }
        public string ValorCredito { get; set; }
    }
}
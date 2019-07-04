using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BusExp2._0.Models
{//
    public class Context : DbContext 
    {

        public Context() : base("BusExp2._0.Models") { }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Onibus> Onibus { get; set; }
        public DbSet<Credito> Creditos { get; set; }
        public DbSet<Motorista> Motoristas { get; set; }
        public DbSet<HistoricoPagamentos> HistoricoPagamentos { get; set; }
        public DbSet<Ranking> Rankings { get; set; }
        public DbSet<FormaPagamento> FormasPagamento { get; set; }
        public DbSet<LiberaCatraca> Credito { get; set; }
        public DbSet<HistoricoAdicaoCredito> HistoricoAdicaoCreditos { get; set; }
    }
}
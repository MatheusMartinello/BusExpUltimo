using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{
    public class HistoricoGastos
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarLiberaCatraca(HistoricoPagamentos p)
        {
            ctx.HistoricoPagamentos.Add(p);
            ctx.SaveChanges();
        }
        public static List<LiberaCatraca> RetornaListaCatraca()
        {
            return ctx.LiberaCatracas.ToList();
        }
    }
}
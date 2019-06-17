using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{
    public class CreditoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarCredito(Credito p)
        {
            ctx.Creditos.Add(p);
            ctx.SaveChanges();
        }
        public static List<Credito> RetornaListaCredito()
        {
            return ctx.Creditos.ToList();
        }
    }
}
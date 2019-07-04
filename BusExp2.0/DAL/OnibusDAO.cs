using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{
    public class OnibusDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarOnibus(Onibus u)
        {
            if (BuscarOnibus(u) == null)
            {
                ctx.Onibus.Add(u);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }//

        public static List<Onibus> RetornarOnibus()
        {
            return ctx.Onibus.ToList();
        }
        public static Onibus BuscarOnibus(Onibus u)
        {
            if (ctx.Onibus.Find(u) == null)
            {
                return null;
            }
            else
            {
                u.OnibusId = ctx.Onibus.Find(u).OnibusId;
                return u;
            }

        }
    }
}
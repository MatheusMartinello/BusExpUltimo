using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{
    public class FormaPagamentoDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarFormaPag(FormaPagamento u)
        {
            if (BuscarFormaPag(u) == null)
            {
                ctx.FormasPagamento.Add(u);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public static List<FormaPagamento> RetornarFormaPag()
        {
            return ctx.FormasPagamento.ToList();
        }
        public static FormaPagamento BuscarFormaPagId(int? f) {
            return ctx.FormasPagamento.Find(f);
        }
        public static FormaPagamento BuscarFormaPag(FormaPagamento u)
        {
            if (ctx.Usuarios.Find(u) == null)
            {
                return null;
            }
            else
            {
                u.FormaPagId = ctx.FormasPagamento.Find(u).FormaPagId;
                return u;
            }

        }
    }
}
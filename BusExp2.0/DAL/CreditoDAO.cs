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
            Credito c = ctx.Creditos.Include("Usuario").FirstOrDefault(x => x.usuario.UsuarioId == p.usuario.UsuarioId);
            if (c == null) {
                ctx.Creditos.Add(p);
                ctx.SaveChanges();
             }
            else
            {
                ModificaValorCredito(p);
                ctx.Entry(c).State = System.Data.Entity.EntityState.Modified;
                ctx.SaveChanges();

            }
        }
        public static List<Credito> RetornaListaCredito()
        {
            return ctx.Creditos.ToList();
        }
        public static Credito CreditoPorUsuario(Usuario u)
        {

            return ctx.Creditos.FirstOrDefault(x => x.usuario.Cpf.Equals(u.Cpf) && x.usuario.Senha.Equals(u.Senha));
        }
        public static void ModificaValorCredito(Credito c)
        {
            Credito aux = CreditoPorUsuario(c.usuario);
            double valorCredito = Convert.ToDouble(aux.ValorCredito) + Convert.ToDouble(c.ValorCredito);
            aux.ValorCredito = Convert.ToString(valorCredito);
            ctx.Entry(aux).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();
        }

    }
}
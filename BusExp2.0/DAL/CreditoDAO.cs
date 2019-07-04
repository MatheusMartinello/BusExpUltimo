using BusExp2._0.Models;
using BusExp2._0.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{//
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
                ModificaValorCredito(Convert.ToDouble(p.ValorCredito),p);
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
            try {
                if (ctx.Creditos.FirstOrDefault(x => x.usuario.Cpf.Equals(u.Cpf) && x.usuario.Senha.Equals(u.Senha)) == null)
                    return null;
                return ctx.Creditos.FirstOrDefault(x => x.usuario.Cpf.Equals(u.Cpf) && x.usuario.Senha.Equals(u.Senha));

            }
            catch
            {
                return null;
            }
        }
        public static void ModificaValorCredito(double puts,Credito p)
        {

            Credito aux = CreditoPorUsuario(UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario()));
            double valorCredito = Convert.ToDouble(aux.ValorCredito) + puts;
            aux.ValorCredito = valorCredito;
            ctx.Entry(aux).State = System.Data.Entity.EntityState.Modified;
            ctx.SaveChanges();


        }
        public static List<Credito> Cu (int id)
        {
            Usuario u = UsuarioDAO.BuscarUsuario2(id);
            if(u != null)
            {
                return ctx.Creditos.Include("Usuario").Where(x => x.usuario.UsuarioId == id).ToList();
            } 
            return null;
        }

    }
}
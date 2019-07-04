using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{
    public class LiberaCatracaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarLiberaCatraca(LiberaCatraca p)
        {
            ctx.Credito.Add(p);
            ctx.SaveChanges();
        }//
        public static LiberaCatraca RetornaPagamentoUsuario(Usuario U) {
            return ctx.Credito.FirstOrDefault(x => x.usuario == U);
        }
        public static List<LiberaCatraca> RetornaListaCatraca()
        {
            return ctx.Credito.ToList();
        }
        public static List<LiberaCatraca> Cu2(int id)
        {
            return ctx.Credito.Include("Credito").Include("Usuario").Where(x => x.credito.usuario.UsuarioId == id && x.usuario.UsuarioId == id).ToList();
        }
    }
}
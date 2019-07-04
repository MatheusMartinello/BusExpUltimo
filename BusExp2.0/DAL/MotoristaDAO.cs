using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{
    public class MotoristaDAO
    {
        private static Context ctx = SingletonContext.GetInstance();

        public static bool CadastrarMotorista(Motorista u)
        {
            
                ctx.Motoristas.Add(u);
                ctx.SaveChanges();
                return true;
            //
        }

        public static List<Motorista> RetornarMotorista()
        {
            return ctx.Motoristas.ToList();
        }
        public static Motorista BuscarMotorista(Motorista u)
        {
            if (ctx.Usuarios.Find(u) == null)
            {
                return null;
            }
            else
            {
                u.MotoristaId = ctx.Motoristas.Find(u).MotoristaId;
                return u;
            }

        }
        public static Motorista MotoristaAleatorio()
        {
            int koko = ctx.Motoristas.Max(x => x.MotoristaId);
            int koko2 = ctx.Motoristas.Min(x => x.MotoristaId);
            int id = 0;
            Random r = new Random();
            id = r.Next(koko2 , koko);

            
            return ctx.Motoristas.FirstOrDefault(x =>x.MotoristaId == id);
        }
        
    }
}
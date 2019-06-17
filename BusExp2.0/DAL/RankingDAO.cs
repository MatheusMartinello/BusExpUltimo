using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusExp2._0.DAL
{
    public class RankingDAO
    {
        private static Context ctx = SingletonContext.GetInstance();
        public static void CadastrarRanking(Ranking p)
        {
            ctx.Rankings.Add(p);
            ctx.SaveChanges();    
        }
        public static List<Ranking> RetornaListaRankingPorMotorista(int? id)
        {
            return ctx.Rankings.Include("Motorista").Where(x =>x.Motorista.MotoristaId == id).ToList();
        }
        public static List<Ranking> RetornaListaRanking()
        {
            return ctx.Rankings.ToList();
        }
        
    }
}
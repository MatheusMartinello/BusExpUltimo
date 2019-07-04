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
        public static bool CadastrarRanking(Ranking u)
        {
                ctx.Rankings.Add(u);
                ctx.SaveChanges();
                return true;
           
        }
        public static List<Ranking> RetornaListaRankingPorMotorista(int? id)
        {
            return ctx.Rankings.Include("Motorista").Where(x =>x.Motorista.MotoristaId == id).ToList();
        }
        public static List<Ranking> RetornaListaRanking()
        {
            return ctx.Rankings.Include("Motorista").ToList();
        }
    }
}
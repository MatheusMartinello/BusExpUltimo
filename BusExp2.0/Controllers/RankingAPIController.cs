using BusExp2._0.DAL;
using BusExp2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BusExp2._0.Controllers
{
    [RoutePrefix("api/Ranking")]
    public class RankingAPIController : ApiController
    {


        [Route("RankingMotorista/{id}")]
        [HttpGet]
        public List<Ranking> RankingMotorista(int id)
        {
            return RankingDAO.RetornaListaRanking();

        }

        [Route("CreditoPorUsuario/{id}")]
        public List<Credito> GetHistoricoCreditoUsuario(int id)
        {

            return CreditoDAO.Cu(id);
        }
        [Route("HistoricoComprasUsuario/{id}")]
        [HttpGet]
        public List<LiberaCatraca> HistoricoComprasUsuario(int id)
        {
            return LiberaCatracaDAO.Cu2(id);
        }

        //
    }
}



    


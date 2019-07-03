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
       
        [Route("UsuarioPorId/{id}")]
        public dynamic GetProdutoPorId(int id)
        {
            //var objeto = ProdutoDAO.BuscarProdutoPorId(id);
            Usuario u = UsuarioDAO.BuscarUsuario2(id);
            if (u != null)
            {
                dynamic objeto = new
                {
                    NomeUsuario = u.Nome,
                    SobreNome = u.SobreNome
                };
                return objeto;
            }
            return NotFound();
        }
        [Route("CreditoPorUsuario/{id}")]
        public List<Credito> GetHistoricoCreditoUsuario(int id)
        {
            Usuario u = UsuarioDAO.BuscarUsuario2(id);
            if(u != null)
            {
                List<Credito> x = new List<Credito>();
                foreach(Credito j in CreditoDAO.RetornaListaCredito())
                {
                    if(j.usuario.UsuarioId == id)
                    {
                        x.Add(j);

                    }
                }
                return x;
            }
            return null;

        }
        [Route("HistoricoComprasUsuario/{id}")]
        [HttpGet]
        public List<LiberaCatraca> HistoricoComprasUsuario(int id)
        {
            Usuario u = UsuarioDAO.BuscarUsuario2(id);
            if (u != null)
            {
                
                List<LiberaCatraca> x = new List<LiberaCatraca>();
                foreach (LiberaCatraca j in LiberaCatracaDAO.RetornaListaCatraca())
                {
                    if (j.usuario.UsuarioId == id)
                    {
                        
                        x.Add(j);

                    }
                }
                return x;
            }
            return null;
        }


    }
}

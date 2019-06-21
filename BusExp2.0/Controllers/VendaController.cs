using BusExp2._0.DAL;
using BusExp2._0.Models;
using BusExp2._0.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusExp2._0.Controllers
{
    public class VendaController : Controller
    {
        // GET: Venda
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Pagamento()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Pagamento(Onibus o)
        {
            Usuario u = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
            Credito c = CreditoDAO.CreditoPorUsuario(u);
            c.ValorCredito = Convert.ToString(Convert.ToDouble(c.ValorCredito) - 4.20);
            LiberaCatraca lc = new LiberaCatraca();
            lc.usuario = u;
            lc.credito = c;
            lc.onibus = o;
            lc.ValorPago = "4.20";
            LiberaCatracaDAO.CadastrarLiberaCatraca(lc);
            return RedirectToAction("Index","Usuario");

        }
    }
}
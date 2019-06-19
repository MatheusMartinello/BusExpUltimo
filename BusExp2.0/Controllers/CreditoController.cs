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
    public class CreditoController : Controller
    {
        // GET: Credito
        public ActionResult Index()
        {
            
            return View(UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario()));
        }
        public ActionResult AdicionarCredito() {
            ViewBag.FormaPag = new SelectList(FormaPagamentoDAO.RetornarFormaPag(), "FormaPagId", "Descricao");
            return View();
        }
       [HttpPost]
        public ActionResult AdicionarCredito(Credito C, int? FormaPag)
        {
            Usuario u = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
            C.usuario = u;
            //C.FormaPag =  Criar metodo que busca por id
            CreditoDAO.CadastrarCredito(C);
            return RedirectToAction("Index", "Home");
            
        }
        
    }
}
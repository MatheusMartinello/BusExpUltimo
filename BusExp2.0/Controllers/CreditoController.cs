using BusExp2._0.DAL;
using BusExp2._0.Models;
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
            ViewBag.Usuario = User.Identity.Name;
            return View(UsuarioDAO.RetornarUsuarios());
        }
        public ActionResult AdicionarCredito() {
            return View();
        }
       /* [HttpPost]
        public ActionResult AdicionarCredito(int id)
        {
            Usuario u = UsuarioDAO.BuscarUsuario(id);
            return RedirectToAction("Index", "Credito");
        }*/

    }
}
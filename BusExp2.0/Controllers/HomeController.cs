using BusExp2._0.DAL;
using BusExp2._0.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusExp2._0.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            if(Sessao.RetornarUsuario() == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View(UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario()));
        }
    }
}
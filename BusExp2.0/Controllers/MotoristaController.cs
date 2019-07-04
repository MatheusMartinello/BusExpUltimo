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
    public class MotoristaController : Controller
    {
        // GET: Motorista
        public ActionResult Index()
        {
            if (Sessao.RetornarUsuario() == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }
        public ActionResult Cadastrar() {
            if (Sessao.RetornarUsuario() == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Cadastrar(Motorista M)
        {
       

            if (ModelState.IsValid)
            {
                if (MotoristaDAO.CadastrarMotorista(M))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                ModelState.AddModelError("", "Não é possível adicionar um usuário com o mesmo login!");
                return View(M);
            }
     
            return RedirectToAction("Index", "Home");
        }
    }

}
using BusExp2._0.DAL;
using BusExp2._0.Models;
using BusExp2._0.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BusExp2._0.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Login() {
            return View();
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        
        public ActionResult Cadastrar(Usuario u)
        {

            if (ModelState.IsValid)
            {
                if (UsuarioDAO.CadastrarUsuario(u))
                {
                    return RedirectToAction("Index", "Usuario");
                }
                ModelState.AddModelError("", "Não é possível adicionar um usuário com o mesmo login!");
                return View(u);
            }
            return View(u);
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
           

            if (usuario != null)
            {
                //Autenticação - FormsAuthentication
                FormsAuthentication.SetAuthCookie(usuario.Cpf, true);
                Usuario u = UsuarioDAO.BuscarUsuarioPorLoginSenha(usuario);
                Sessao.Login(u.UsuarioId);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Login ou senha incorretos!");
            return View(usuario);
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Usuario");
        }
    }
}

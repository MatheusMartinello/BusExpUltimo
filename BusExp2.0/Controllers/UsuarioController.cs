using BusExp2._0.DAL;
using BusExp2._0.Models;
using BusExp2._0.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
            if (Sessao.RetornarUsuario() == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
            ViewBag.Alerta = TempData["Alerta"];
            return View();
        }
        public ActionResult Cadastrar()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult CompraPassagem() {
            if (CreditoDAO.CreditoPorUsuario(UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario())).ValorCredito == 0 || CreditoDAO.CreditoPorUsuario(UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario())).ValorCredito < 4.20)
            {
                TempData["Alerta"]= "Recarregue seus creditos creditos!!";
                return RedirectToAction("Index", "Usuario");
            }
            return RedirectToAction("Pagamento","Venda");
        }

        // GET: Usuario/Create
        public ActionResult AdicionarCredito()
        {
            return RedirectToAction("AdicionarCredito","Credito");
        }
        //
        // POST: Usuario/Create
        [HttpPost]
        
        public ActionResult Cadastrar(Usuario u)
        {

            var apenasDigitos = new Regex(@"[^\d]");
            
            if (ModelState.IsValid)
            {
                u.Cpf = apenasDigitos.Replace(u.Cpf, "");
                u.Perfil = "Usuario";
                if (UsuarioDAO.CadastrarUsuario(u))
                {
                     return RedirectToAction("Login", "Usuario");
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
                
                Usuario u = UsuarioDAO.BuscarUsuarioPorLoginSenha(usuario);
                if (u != null)
                {
                    Sessao.Login(u.UsuarioId);
                    FormsAuthentication.SetAuthCookie(usuario.Cpf, true);
                    return RedirectToAction("Index", "Usuario");

                }
                else
                {
                    ModelState.AddModelError("", "Login ou senha incorretos!");
                    return View(usuario);
                }
            }
            ModelState.AddModelError("", "Informe Login e Senha");
            return View(usuario);
        }
        public ActionResult Logout()
            {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Usuario");
        }
        public ActionResult GoToRanking()
        {
            return RedirectToAction("Index", "Rankings");
        }
        public ActionResult GoToMotoristas()
        {
            return RedirectToAction("Create", "Motoristas");
        }
    }
}

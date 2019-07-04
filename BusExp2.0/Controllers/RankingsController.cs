using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusExp2._0.Models;
using BusExp2._0.Utils;
using BusExp2._0.DAL;

namespace BusExp2._0.Controllers
{
    public class RankingsController : Controller
    {
        private Context db = new Context();

        // GET: Rankings
        
        public ActionResult Index()
        {
            
            if (Sessao.RetornarUsuario() != null)
            {
                Usuario u = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
                if(u.Perfil.Equals("Administrador"))
                    return View(db.Rankings.ToList());
                else
                    return RedirectToAction("Index","Usuario");
            }
            return RedirectToAction("Login", "Usuario");

        }

        // GET: Rankings/Details/5
        public ActionResult Details(int? id)
        {
            if (Sessao.RetornarUsuario() != null)
            {
                Usuario u = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
                if (u.Perfil.Equals("Administrador"))
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Ranking ranking = db.Rankings.Find(id);
                    if (ranking == null)
                    {
                        return HttpNotFound();
                    }
                    return View(ranking);
                }
                    return View(db.Rankings.ToList());
                
            }
            return RedirectToAction("Login", "Usuario");

        }
        // GET: Rankings/Create
        public ActionResult Create()
        {
            if (Sessao.RetornarUsuario() == null)
            {

                return RedirectToAction("Login", "Usuario");
            }
            return View();
        }

        // POST: Rankings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RankingId,ValorAtribuido,Comentario")] Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                ranking.Motorista = MotoristaDAO.MotoristaAleatorio();
                ranking.Usuario = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
                if (RankingDAO.CadastrarRanking(ranking))
                    return RedirectToAction("Index", "Usuario");
            }

            return View(ranking);
        }
        
        // GET: Rankings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Sessao.RetornarUsuario() != null)
            {
                Usuario u = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
                if (u.Perfil.Equals("Administrador"))
                {
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    Ranking ranking = db.Rankings.Find(id);
                    if (ranking == null)
                    {
                        return HttpNotFound();
                    }
                    return View(ranking);
                }
                return View(db.Rankings.ToList());

            }
            return RedirectToAction("Login", "Usuario");
           
        }

        // POST: Rankings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RankingId,ValorAtribuido,Comentario")] Ranking ranking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ranking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ranking);
        }
        
        // GET: Rankings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ranking ranking = db.Rankings.Find(id);
            if (ranking == null)
            {
                return HttpNotFound();
            }
            return View(ranking);
        }

        // POST: Rankings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ranking ranking = db.Rankings.Find(id);
            db.Rankings.Remove(ranking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

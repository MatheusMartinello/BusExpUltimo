using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusExp2._0.Models;
using BusExp2._0.DAL;
using BusExp2._0.Utils;

namespace BusExp2._0.Controllers
{
    public class RankingsController : Controller
    {
        private Context db = new Context();

        // GET: Rankings
        public ActionResult Index()
        {
            if (Sessao.RetornarUsuario() == null)
            {
                return RedirectToAction("Login", "Usuario");
            }
           
            return View(db.Rankings.ToList());
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

            ranking.Motorista = MotoristaDAO.RetornarMotorista()[1];
            ranking.Usuario = UsuarioDAO.BuscarUsuarioPorId(Sessao.RetornarUsuario());
            if(RankingDAO.CadastrarRanking(ranking))
                 return RedirectToAction("Index", "Usuario");
            

            return View(ranking);
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


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusExp2._0.Models;

namespace BusExp2._0.Controllers
{
    public class OnibusController : Controller
    {
        private Context db = new Context();

        // GET: Onibus
        public ActionResult Index()
        {
            return View(db.Onibus.ToList());
        }

        // GET: Onibus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onibus onibus = db.Onibus.Find(id);
            if (onibus == null)
            {
                return HttpNotFound();
            }
            return View(onibus);
        }

        // GET: Onibus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Onibus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OnibusId,Nome,Cidade,RuaInicial,RuaFinal")] Onibus onibus)
        {
            if (ModelState.IsValid)
            {
                db.Onibus.Add(onibus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(onibus);
        }

        // GET: Onibus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onibus onibus = db.Onibus.Find(id);
            if (onibus == null)
            {
                return HttpNotFound();
            }
            return View(onibus);
        }

        // POST: Onibus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OnibusId,Nome,Cidade,RuaInicial,RuaFinal")] Onibus onibus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(onibus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(onibus);
        }

        // GET: Onibus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Onibus onibus = db.Onibus.Find(id);
            if (onibus == null)
            {
                return HttpNotFound();
            }
            return View(onibus);
        }

        // POST: Onibus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Onibus onibus = db.Onibus.Find(id);
            db.Onibus.Remove(onibus);
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

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebIncidencias_UF3.Models;
using WebIncidencias_UF3.Models.Mantenimientos;

namespace WebIncidencias_UF3.Controllers.Mantenimientos
{
    [Authorize]
    public class DistribuidoresController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Distribuidores
        public ActionResult Index()
        {
            return View(db.Distribuidores.ToList());
        }

        // GET: Distribuidores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidores distribuidores = db.Distribuidores.Find(id);
            if (distribuidores == null)
            {
                return HttpNotFound();
            }
            return View(distribuidores);
        }

        // GET: Distribuidores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Distribuidores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Telefono,Direccion")] Distribuidores distribuidores)
        {
            if (ModelState.IsValid)
            {
                db.Distribuidores.Add(distribuidores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(distribuidores);
        }

        // GET: Distribuidores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidores distribuidores = db.Distribuidores.Find(id);
            if (distribuidores == null)
            {
                return HttpNotFound();
            }
            return View(distribuidores);
        }

        // POST: Distribuidores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Telefono,Direccion")] Distribuidores distribuidores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(distribuidores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(distribuidores);
        }

        // GET: Distribuidores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Distribuidores distribuidores = db.Distribuidores.Find(id);
            if (distribuidores == null)
            {
                return HttpNotFound();
            }
            return View(distribuidores);
        }

        // POST: Distribuidores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Distribuidores distribuidores = db.Distribuidores.Find(id);
            db.Distribuidores.Remove(distribuidores);
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

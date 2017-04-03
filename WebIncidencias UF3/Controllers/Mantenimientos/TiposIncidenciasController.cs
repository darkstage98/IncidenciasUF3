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
    public class TiposIncidenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TiposIncidencias
        public ActionResult Index()
        {
            return View(db.TiposIncidencias.ToList());
        }

        // GET: TiposIncidencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposIncidencias tiposIncidencias = db.TiposIncidencias.Find(id);
            if (tiposIncidencias == null)
            {
                return HttpNotFound();
            }
            return View(tiposIncidencias);
        }

        // GET: TiposIncidencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TiposIncidencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] TiposIncidencias tiposIncidencias)
        {
            if (ModelState.IsValid)
            {
                db.TiposIncidencias.Add(tiposIncidencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tiposIncidencias);
        }

        // GET: TiposIncidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposIncidencias tiposIncidencias = db.TiposIncidencias.Find(id);
            if (tiposIncidencias == null)
            {
                return HttpNotFound();
            }
            return View(tiposIncidencias);
        }

        // POST: TiposIncidencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] TiposIncidencias tiposIncidencias)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tiposIncidencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tiposIncidencias);
        }

        // GET: TiposIncidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TiposIncidencias tiposIncidencias = db.TiposIncidencias.Find(id);
            if (tiposIncidencias == null)
            {
                return HttpNotFound();
            }
            return View(tiposIncidencias);
        }

        // POST: TiposIncidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TiposIncidencias tiposIncidencias = db.TiposIncidencias.Find(id);
            db.TiposIncidencias.Remove(tiposIncidencias);
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

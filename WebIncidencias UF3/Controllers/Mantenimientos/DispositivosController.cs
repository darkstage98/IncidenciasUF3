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
    public class DispositivosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dispositivos
        public ActionResult Index()
        {
            var dispositivos = db.Dispositivos.Include(d => d.Distribuidor);
            return View(dispositivos.ToList());
        }

        // GET: Dispositivos/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivos dispositivos = db.Dispositivos.Find(id);
            if (dispositivos == null)
            {
                return HttpNotFound();
            }
            return View(dispositivos);
        }

        // GET: Dispositivos/Create
        public ActionResult Create()
        {
            ViewBag.DistribuidorId = new SelectList(db.Distribuidores, "Id", "Nombre");
            return View();
        }

        // POST: Dispositivos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MAC,Nombre,DistribuidorId,FechaAdquisicion,Garantia,Averias,Reparacion")] Dispositivos dispositivos)
        {
            if (ModelState.IsValid)
            {
                db.Dispositivos.Add(dispositivos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DistribuidorId = new SelectList(db.Distribuidores, "Id", "Nombre", dispositivos.DistribuidorId);
            return View(dispositivos);
        }

        // GET: Dispositivos/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivos dispositivos = db.Dispositivos.Find(id);
            if (dispositivos == null)
            {
                return HttpNotFound();
            }
            ViewBag.DistribuidorId = new SelectList(db.Distribuidores, "Id", "Nombre", dispositivos.DistribuidorId);
            return View(dispositivos);
        }

        // POST: Dispositivos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MAC,Nombre,DistribuidorId,FechaAdquisicion,Garantia,Averias,Reparacion")] Dispositivos dispositivos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dispositivos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DistribuidorId = new SelectList(db.Distribuidores, "Id", "Nombre", dispositivos.DistribuidorId);
            return View(dispositivos);
        }

        // GET: Dispositivos/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivos dispositivos = db.Dispositivos.Find(id);
            if (dispositivos == null)
            {
                return HttpNotFound();
            }
            return View(dispositivos);
        }

        // POST: Dispositivos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Dispositivos dispositivos = db.Dispositivos.Find(id);
            db.Dispositivos.Remove(dispositivos);
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

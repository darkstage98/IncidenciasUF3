using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebIncidencias_UF3.Models;
using WebIncidencias_UF3.Models.Incidencias;

namespace WebIncidencias_UF3.Controllers.Incidencias
{
    [Authorize]
    public class IncidenciasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Incidencias
        public ActionResult Index()
        {
            var incidencias = db.Incidencias.Include(i => i.Dispositivo).Include(i => i.TipoIncidencia);
            return View(incidencias.ToList());
        }

        // GET: Incidencias/Create
        public ActionResult Create()
        {
            ViewBag.DispositivoId = new SelectList(db.Dispositivos, "MAC", "Nombre");
            ViewBag.TipoIncidenciaId = new SelectList(db.TiposIncidencias, "Id", "Nombre");
            return View();
        }

        // POST: Incidencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DispositivoId,TipoIncidenciaId,UsuarioId,Descripion")] Models.Incidencias.Incidencias incidencias)
        {
            if (ModelState.IsValid)
            {
                incidencias.UsuarioId = ClaimsPrincipal.Current.FindFirst("Id").Value;
                incidencias.FechaCreacion = DateTime.Now;
                db.Incidencias.Add(incidencias);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DispositivoId = new SelectList(db.Dispositivos, "MAC", "Nombre", incidencias.DispositivoId);
            ViewBag.TipoIncidenciaId = new SelectList(db.TiposIncidencias, "Id", "Nombre", incidencias.TipoIncidenciaId);
            return View(incidencias);
        }

        // GET: Incidencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Incidencias.Incidencias incidencias = db.Incidencias.Find(id);
            if (incidencias == null)
            {
                return HttpNotFound();
            }
            ViewBag.DispositivoId = new SelectList(db.Dispositivos, "MAC", "Nombre", incidencias.DispositivoId);
            ViewBag.TipoIncidenciaId = new SelectList(db.TiposIncidencias, "Id", "Nombre", incidencias.TipoIncidenciaId);
            return View(incidencias);
        }

        // POST: Incidencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DispositivoId,TipoIncidenciaId,UsuarioId,FechaCreacion,FechaCierre,Descripion")] Models.Incidencias.Incidencias incidencias, string submit)
        {
            if (ModelState.IsValid)
            {
                if (submit == "Cerrar")
                {
                    incidencias.FechaCierre = DateTime.Now;
                }
                db.Entry(incidencias).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DispositivoId = new SelectList(db.Dispositivos, "MAC", "Nombre", incidencias.DispositivoId);
            ViewBag.TipoIncidenciaId = new SelectList(db.TiposIncidencias, "Id", "Nombre", incidencias.TipoIncidenciaId);
            return View(incidencias);
        }

        // GET: Incidencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Models.Incidencias.Incidencias incidencias = db.Incidencias.Find(id);
            if (incidencias == null)
            {
                return HttpNotFound();
            }
            return View(incidencias);
        }

        // POST: Incidencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Models.Incidencias.Incidencias incidencias = db.Incidencias.Find(id);
            db.Incidencias.Remove(incidencias);
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

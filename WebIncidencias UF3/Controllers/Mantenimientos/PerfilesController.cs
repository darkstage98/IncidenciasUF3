using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebIncidencias_UF3.Models;

namespace WebIncidencias_UF3.Controllers.Mantenimientos
{
    public class PerfilesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        // GET: Perfiles
        public ActionResult Index()
        {
            return View(db.Roles.ToList());
        }


        // GET: Perfiles/Create
        public ActionResult Create()
        {
            return View(new IdentityRole());
        }

        // POST: Perfiles/Create
        [HttpPost]
        public ActionResult Create(IdentityRole model)
        {
            try
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Added;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Perfiles/Edit/5
        public ActionResult Edit(string id)
        {
            return View(db.Roles.Find(id));
        }

        // POST: Perfiles/Edit/5
        [HttpPost]
        public ActionResult Edit(IdentityRole model)
        {
            try
            {
                // TODO: Add update logic here
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Perfiles/Delete/5
        public ActionResult Delete(string id)
        {
            return View();
        }

        // POST: Perfiles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IdentityRole model)
        {
            try
            {
                // TODO: Add delete logic here
                db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

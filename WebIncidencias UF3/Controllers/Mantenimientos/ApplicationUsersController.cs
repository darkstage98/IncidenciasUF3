using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
    public class ApplicationUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole> roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        private UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
        // GET: ApplicationUsers
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: ApplicationUsers/Create
        public ActionResult Create()
        {
            ViewBag.Perfil = new SelectList(db.Roles.ToList(), "Id", "Name");
            return View();
        }

        // POST: ApplicationUsers/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ApplicationUser model, string Perfil)
        {
            if (ModelState.IsValid)
            {
                model.UserName = model.Email;
                userManager.Create(model);
                userManager.AddToRole(model.Id, db.Roles.Find(Perfil).Name);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: ApplicationUsers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = new UsuariosViewModel();
            model.Usuario = db.Users.Find(id);
            model.PerfilId = model.Usuario.Roles.FirstOrDefault().RoleId;
            //var roles = userManager.GetRoles(id)[0];
            ViewBag.Perfil = new SelectList(db.Roles.ToList(), "Id", "Name");
            if (model.Usuario == null)
            {
                return HttpNotFound();
            }
            return View(model);
        }

        // POST: ApplicationUsers/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuariosViewModel model, string NPassword)
        {
            if (ModelState.IsValid)
            {
                if (!string.IsNullOrEmpty(NPassword))
                {
                    model.Usuario.PasswordHash = userManager.PasswordHasher.HashPassword(NPassword);
                }

                var roles = userManager.GetRoles(model.Usuario.Id)[0];
                if (roles != roleManager.FindById(model.PerfilId).Name)
                {
                    userManager.RemoveFromRole(model.Usuario.Id, roles);
                    userManager.AddToRole(model.Usuario.Id, roleManager.FindById(model.PerfilId).Name);
                }

                db.Entry(model.Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // GET: ApplicationUsers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ApplicationUser applicationUser = db.Users.Find(id);
            if (applicationUser == null)
            {
                return HttpNotFound();
            }
            return View(applicationUser);
        }

        // POST: ApplicationUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ApplicationUser applicationUser = db.Users.Find(id);
            db.Users.Remove(applicationUser);
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

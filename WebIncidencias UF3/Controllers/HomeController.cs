using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebIncidencias_UF3.Models;
using Microsoft.AspNet.Identity;
using WebIncidencias_UF3.Models.Inicio;
using System.Security.Claims;

namespace WebIncidencias_UF3.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var model = new InicioVM();
            var userId = ClaimsPrincipal.Current.FindFirst("Id").Value;
            model.Usuario = db.Users.Find(userId);
            model.Incidencias = db.Incidencias.Where(x => x.UsuarioId == userId).ToList();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
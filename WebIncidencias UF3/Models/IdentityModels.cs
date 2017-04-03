using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace WebIncidencias_UF3.Models
{
    // Puede agregar datos del perfil del usuario agregando más propiedades a la clase ApplicationUser. Para más información, visite http://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Tenga en cuenta que el valor de authenticationType debe coincidir con el definido en CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("HoraSesion", DateTime.Now.ToString()));
            userIdentity.AddClaim(new Claim("Id", userIdentity.GetUserId()));
            // Agregar aquí notificaciones personalizadas de usuario
            return userIdentity;
        }
        public string Nombre { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<WebIncidencias_UF3.Models.Mantenimientos.TiposIncidencias> TiposIncidencias { get; set; }
        public DbSet<WebIncidencias_UF3.Models.Mantenimientos.Distribuidores> Distribuidores { get; set; }
        public DbSet<WebIncidencias_UF3.Models.Mantenimientos.Dispositivos> Dispositivos { get; set; }
        public DbSet<WebIncidencias_UF3.Models.Incidencias.Incidencias> Incidencias { get; set; }
    }
}
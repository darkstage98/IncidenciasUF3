using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebIncidencias_UF3.Models.Inicio
{
    public class InicioVM
    {
        public ApplicationUser Usuario { get; set; } 
        public List<Incidencias.Incidencias> Incidencias { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebIncidencias_UF3.Models.Mantenimientos
{
    [Table("TiposIncidencias")]
    public class TiposIncidencias
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
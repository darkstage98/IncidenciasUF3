using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebIncidencias_UF3.Models.Mantenimientos
{
    [Table("Dispositivos")]
    public class Dispositivos
    {
        [Key]
        public string MAC { get; set; }
        public string Nombre { get; set;}
        [ForeignKey("Distribuidor")]
        public int DistribuidorId { get; set; }
        public virtual Distribuidores Distribuidor { get; set; }
        public DateTime FechaAdquisicion { get; set; }
        public DateTime Garantia { get; set; }
        public string Averias { get; set; }
        public string Reparacion { get; set; }
    }
}
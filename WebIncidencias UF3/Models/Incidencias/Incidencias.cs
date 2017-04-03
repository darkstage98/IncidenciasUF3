using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using WebIncidencias_UF3.Models.Mantenimientos;

namespace WebIncidencias_UF3.Models.Incidencias
{
    [Table("Incidencias")]
    public class Incidencias
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Dispositivo")]
        public string DispositivoId { get; set; }
        public virtual Dispositivos Dispositivo { get; set; }

        [ForeignKey("TipoIncidencia")]
        public int TipoIncidenciaId { get; set; }
        public virtual TiposIncidencias TipoIncidencia { get; set; }

        [ForeignKey("Usuario")]
        public string UsuarioId { get; set; }
        public virtual ApplicationUser Usuario { get; set; }

        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaCierre { get; set; }
        public string Descripion { get; set; }
    }
}
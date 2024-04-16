using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colegio.BL.Models
{
    [Table("Estudiante", Schema = "dbo")]
    public class Estudiante
    {
        [Key]
        public int IdEstudiante { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<Nota> Notas { get; set; }
    }
}

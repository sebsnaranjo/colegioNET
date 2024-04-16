using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colegio.BL.Models
{
    [Table("Profesor", Schema = "dbo")]
    public class Profesor
    {
        [Key]
        public int IdProfesor { get; set; }

        public string Nombre { get; set; }

        public virtual ICollection<Nota> Notas { get; set; }
    }
}

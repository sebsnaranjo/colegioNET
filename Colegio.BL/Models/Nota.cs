using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Colegio.BL.Models
{
    [Table("Nota", Schema = "dbo")]
    public class Nota
    {
        [Key]
        public int IdNota { get; set; }
        public string Nombre { get; set; }

        [ForeignKey("Profesor")]
        public int IdProfesor { get; set; }
        [ForeignKey("Estudiante")]
        public int IdEstudiante { get; set; }
        public int Valor { get; set; }

        public Profesor Profesor { get; set; }
        public Estudiante Estudiante { get; set; }
    }
}

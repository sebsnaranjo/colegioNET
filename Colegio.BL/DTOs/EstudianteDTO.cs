using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Colegio.BL.DTOs
{
    public class EstudianteDTO
    {
        public int IdEstudiante { get; set; }
        [Required(ErrorMessage = "El campo es requerido")]
        public string Nombre { get; set; }

    }
}

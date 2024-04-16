using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Models.Viewmodels
{
    public class NotaViewmodel
    {
        public int IdNota { get; set; }
        public string Nombre { get; set; }
        public int IdProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public int IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public int Valor { get; set; }

    }
}

using Colegio.BL.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.DTOs
{
    public class ConsultaNotaDTO
    {
        public int IdNota { get; set; }
        public string Nombre { get; set; }
        public int IdProfesor { get; set; }
        public string NombreProfesor { get; set; }
        public int IdEstudiante { get; set; }
        public string NombreEstudiante { get; set; }
        public int Valor { get; set; }

        private ConsultaNotaDTO(int idNota, string nombre, int idProfesor, string nombreProfesor, int idEstudiante, string nombreEstudiante, int valor)
        {
            IdNota = idNota;
            Nombre = nombre;
            IdProfesor = idProfesor;
            NombreProfesor = nombreProfesor;
            IdEstudiante = idEstudiante;
            NombreEstudiante = nombreEstudiante;
            Valor = valor;
        }

        public static ConsultaNotaDTO offViewModel(NotaViewmodel notaViewmodel)
        {
            return new ConsultaNotaDTO(notaViewmodel.IdNota, notaViewmodel.Nombre, notaViewmodel.IdProfesor, notaViewmodel.NombreProfesor, notaViewmodel.IdEstudiante, notaViewmodel.NombreEstudiante, notaViewmodel.Valor);
        }
    }
}

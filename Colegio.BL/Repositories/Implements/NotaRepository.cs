using Colegio.BL.Data;
using Colegio.BL.Models;
using Colegio.BL.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Repositories.Implements
{
    public class NotaRepository : GenericRepository<Nota>, INotaRepository
    {
        public NotaRepository(ColegioContext colegioContext) : base(colegioContext)
        {

        }

        IEnumerable<NotaViewmodel> INotaRepository.GetAllInfo()
        {
            var query = from Nota in colegioContext.Nota
                        join Profesor in colegioContext.Profesor on Nota.IdProfesor equals Profesor.IdProfesor
                        join Estudiante in colegioContext.Estudiante on Nota.IdEstudiante equals Estudiante.IdEstudiante
                        select new NotaViewmodel { IdNota   = Nota.IdNota, Nombre=Nota.Nombre, IdProfesor=Profesor.IdProfesor, NombreProfesor=Profesor.Nombre, IdEstudiante=Estudiante.IdEstudiante, NombreEstudiante =Estudiante.Nombre, Valor=Nota.Valor};

            return query.ToList();
        }
    }
}

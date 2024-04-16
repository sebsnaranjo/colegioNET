using Colegio.BL.Data;
using Colegio.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Repositories.Implements
{
    public class EstudianteRepository : GenericRepository<Estudiante>, IEstudianteRepository
    {
        public EstudianteRepository(ColegioContext colegioContext): base(colegioContext)
        {

        }
    }
}

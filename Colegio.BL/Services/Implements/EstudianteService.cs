using Colegio.BL.Models;
using Colegio.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Services.Implements
{
    public class EstudianteService : GenericService<Estudiante>, IEstudianteService
    {
        public EstudianteService(IEstudianteRepository estudianteRepository)  : base(estudianteRepository)
        {

        }
    }
}

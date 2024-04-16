using Colegio.BL.Models;
using Colegio.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Services.Implements
{
    public class ProfesorService : GenericService<Profesor>, IProfesorService
    {
        public ProfesorService(IProfesorRepository profesorRepository) : base(profesorRepository)
        {

        }
    }
}

using Colegio.BL.Data;
using Colegio.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Repositories.Implements
{
    public class ProfesorRepository : GenericRepository<Profesor>, IProfesorRepository
    {
        public ProfesorRepository(ColegioContext colegioContext) : base(colegioContext)
        {

        }
    }
}

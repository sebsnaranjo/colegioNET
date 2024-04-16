using Colegio.BL.Models;
using Colegio.BL.Models.Viewmodels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Repositories
{
    public interface INotaRepository : IGenericRepository<Nota>
    {
        IEnumerable<NotaViewmodel> GetAllInfo();
    }
}

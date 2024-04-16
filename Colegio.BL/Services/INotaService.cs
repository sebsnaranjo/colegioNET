using Colegio.BL.DTOs;
using Colegio.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Services
{
    public interface INotaService : IGenericService<Nota>
    {
        IEnumerable<ConsultaNotaDTO> GetAllInfo();
    }
}

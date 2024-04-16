using Colegio.BL.DTOs;
using Colegio.BL.Models;
using Colegio.BL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.Services.Implements
{
    public class NotaService : GenericService<Nota>
    {
        private readonly INotaRepository notaRepository;
        public NotaService(INotaRepository notaRepository): base(notaRepository)
        {
            this.notaRepository = notaRepository;

        }

        public IEnumerable<ConsultaNotaDTO> GetAllInfo()
        {
            var query = notaRepository.GetAllInfo();
            return query.Select(x => ConsultaNotaDTO.offViewModel(x));
        }

    }
}

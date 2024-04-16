using AutoMapper;
using Colegio.BL.Data;
using Colegio.BL.DTOs;
using Colegio.BL.Models;
using Colegio.BL.Repositories.Implements;
using Colegio.BL.Services;
using Colegio.BL.Services.Implements;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using log4net;
using log4net.Config;
using System.Runtime.CompilerServices;

namespace Colegio.API.Controllers
{
    [RoutePrefix("api/Notas")]
    public class NotasController : ApiController
    {
        private IMapper mapper;
        private static readonly ILog log = LogManager.GetLogger(typeof(NotasController));
        private readonly NotaService notaService = new NotaService(new NotaRepository(ColegioContext.Create()));
        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
        }

        public NotasController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
            BasicConfigurator.Configure();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            
            var notas = notaService.GetAllInfo();
            log.Info("Entering application.");
            return Ok(notas);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var nota = await notaService.GetById(id);

            if (nota == null)
            {
                return NotFound();
            }

            var notaDTO = mapper.Map<NotaDTO>(nota);

            return Ok(notaDTO);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> Post(NotaDTO notasDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            } 
            try
            {
                var nota = mapper.Map<Nota>(notasDTO);
                nota = await notaService.Insert(nota);
                return Ok(nota);
            }
            catch(Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(NotaDTO notaDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (notaDTO.IdNota != id)
            {
                return BadRequest();
            }

            var flag = await notaService.GetById(id);

            if (flag == null)
            {
                return NotFound();
            }

            try
            {
                var nota = mapper.Map<Nota>(notaDTO);
                nota = await notaService.Update(nota);
                return Ok(nota);
            }
            catch (Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await notaService.GetById(id);

            if (flag == null)
            {
                return NotFound();
            }

            try
            {
                await notaService.Delete(id);
                return Ok();
            }
            catch (Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }
    }
}

using AutoMapper;
using Colegio.BL.Data;
using Colegio.BL.DTOs;
using Colegio.BL.Models;
using Colegio.BL.Repositories.Implements;
using Colegio.BL.Services.Implements;
using log4net;
using log4net.Config;
using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web.Http;

namespace Colegio.API.Controllers
{
    [RoutePrefix("api/Profesor")]
    public class ProfesorController : ApiController
    {
        private IMapper mapper;
        private static readonly ILog log = LogManager.GetLogger(typeof(NotasController));
        private readonly ProfesorService profesorService = new ProfesorService(new ProfesorRepository(ColegioContext.Create()));

        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
            BasicConfigurator.Configure();
        }

        public ProfesorController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            var profesor = await profesorService.GetAll();
            var profesorDTO = profesor.Select(x => mapper.Map<ProfesorDTO>(x));

            return Ok(profesorDTO);
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetById(int id)
        {
            var profesor = await profesorService.GetById(id);

            if (profesor == null)
            {
                return NotFound();
            }

            var profesorDTO = mapper.Map<ProfesorDTO>(profesor);

            return Ok(profesorDTO);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> Post(ProfesorDTO profesorDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var profesor = mapper.Map<Profesor>(profesorDTO);
                profesor = await profesorService.Insert(profesor);
                return Ok(profesor);
            }
            catch (Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(ProfesorDTO profesorDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (profesorDTO.IdProfesor != id)
            {
                return BadRequest();
            }

            var flag = await profesorService.GetById(id);

            if (flag == null)
            {
                return NotFound();
            }

            try
            {
                var profesor = mapper.Map<Profesor>(profesorDTO);
                profesor = await profesorService.Update(profesor);
                return Ok(profesor);
            }
            catch (Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await profesorService.GetById(id);

            if (flag == null)
            {
                return NotFound();
            }

            try
            {
                await profesorService.Delete(id);
                return Ok();
            }
            catch (Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }
    }
}

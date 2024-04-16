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
    [RoutePrefix("api/Estudiantes")]
    public class EstudiantesController : ApiController
    {
        private IMapper mapper;
        private static readonly ILog log = LogManager.GetLogger(typeof(NotasController));
        private readonly EstudianteService estudianteService = new EstudianteService(new EstudianteRepository(ColegioContext.Create()));

        public static ILog GetLogger([CallerFilePath] string filename = "")
        {
            return LogManager.GetLogger(filename);
            BasicConfigurator.Configure();
        }

        public EstudiantesController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IHttpActionResult> GetAll()
        {
            var estudiantes = await estudianteService.GetAll();
            var estudianteDTO = estudiantes.Select(x => mapper.Map<EstudianteDTO>(x));

            return Ok(estudianteDTO);
        }

        [HttpGet]

        public async Task<IHttpActionResult> GetById(int id)
        {
            var estudiante = await estudianteService.GetById(id);

            if(estudiante == null)
            {
                return NotFound();
            }

            var estudianteDTO = mapper.Map<EstudianteDTO>(estudiante);

            return Ok(estudianteDTO);
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IHttpActionResult> Post(EstudianteDTO estudianteDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var estudiante = mapper.Map<Estudiante>(estudianteDTO);
                estudiante = await estudianteService.Insert(estudiante);
                return Ok(estudiante);
            }
            catch (Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(EstudianteDTO estudianteDTO, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(estudianteDTO.IdEstudiante != id)
            {
                return BadRequest();
            }

            var flag = await estudianteService.GetById(id);

            if(flag == null)
            {
                return NotFound();
            }

            try
            {
                var estudiante = mapper.Map<Estudiante>(estudianteDTO);
                estudiante = await estudianteService.Update(estudiante);
                return Ok(estudiante);
            }
            catch (Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var flag = await estudianteService.GetById(id);

            if (flag == null)
            {
                return NotFound();
            }

            try
            {
                await estudianteService.Delete(id);
                return Ok();
            }
            catch (Exception ex) {
                log.Error(ex.StackTrace);
                return InternalServerError(ex); 
            }
        }
    }
}

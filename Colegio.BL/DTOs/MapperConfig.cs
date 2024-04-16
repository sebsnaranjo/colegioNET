using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Colegio.BL.Models;

namespace Colegio.BL.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Estudiante, EstudianteDTO>();
                cfg.CreateMap<EstudianteDTO, Estudiante>();

                cfg.CreateMap<Nota, NotaDTO>();
                cfg.CreateMap<NotaDTO, Nota>();

                cfg.CreateMap<Profesor, ProfesorDTO>();
                cfg.CreateMap<ProfesorDTO, Profesor>();

            });
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colegio.BL.DTOs
{
    public class NotaDTO
    {
        public int IdNota { get; set; }
        public string Nombre { get; set; }
        public int IdProfesor { get; set; }
        public int IdEstudiante { get; set; }
        public int Valor { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TW.Servicio.Base;

namespace TW.IServicio.Horario.DTO
{
    public class HorarioDto : BaseDto
    {
        public DateTime Hora { get; set; }


        public bool Eliminado { get; set; }

        public long FechaId { get; set; }
    }
}

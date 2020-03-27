using System;
using System.Collections.Generic;
using System.Text;
using TW.Servicio.Base;

namespace TW.IServicio.Fecha.DTO
{
    public class FechaDto : BaseDto
    {
        public DateTime FechaTurno { get; set; }

        public bool Eliminado { get; set; }

        public long LugarId { get; set; }

    }
}

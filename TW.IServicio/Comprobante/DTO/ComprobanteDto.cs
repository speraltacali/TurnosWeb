using System;
using System.Collections.Generic;
using System.Text;
using TW.Servicio.Base;

namespace TW.IServicio.Comprobante.DTO
{
    public class ComprobanteDto : BaseDto
    {
        public string Codigo { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public long HorarioId { get; set; }

        public bool Eliminado { get; set; }
    }
}

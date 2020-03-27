using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Dominio.Entidades.Entidades
{
    public class Comprobante : EntityBase
    {
        public string Codigo { get; set; }

        public DateTime FechaSolicitud { get; set; }

        public long HorarioId { get; set; }

        public bool Eliminado { get; set; }

        //************************************//

        public virtual Horario Horario { get; set; }
    }
}

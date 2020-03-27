using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Dominio.Entidades.Entidades
{
    public class Horario : EntityBase
    {
        public DateTime Hora { get; set; }


        public bool Eliminado { get; set; }

        public long FechaId { get; set; }

        //**************************************//

        public virtual Fecha Fecha { get; set; }

        public virtual IEnumerable<Comprobante> Comprobantes { get; set; }
    }
}

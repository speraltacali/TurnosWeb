using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Dominio.Entidades.Entidades
{
    public class Fecha : EntityBase
    {
        public DateTime FechaTurno { get; set; }


        public bool Eliminado { get; set; }

        public long LugarId { get; set; }

        //***************************************//

        public virtual IEnumerable<Horario> Horarios { get; set; }

        public virtual Lugar Lugar { get; set; }
    }
}

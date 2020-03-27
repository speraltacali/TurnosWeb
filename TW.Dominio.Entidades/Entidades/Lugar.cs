using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TW.Dominio.Base;

namespace TW.Dominio.Entidades.Entidades
{
    public class Lugar : EntityBase
    {
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public bool Eliminado { get; set; }

        public long SubCategoriaId { get; set; }

        //******************************************//
        public virtual SubCategoria SubCategoria { get; set; }

        public virtual IEnumerable<Fecha> Fechas { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TW.Servicio.Base;

namespace TW.IServicio.Lugar.DTO
{
    public class LugarDto : BaseDto
    {
        public string Nombre { get; set; }

        public string Direccion { get; set; }

        public bool Eliminado { get; set; }

        public long SubCategoriaId { get; set; }
    }
}

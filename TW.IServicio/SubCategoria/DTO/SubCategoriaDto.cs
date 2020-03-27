using System;
using System.Collections.Generic;
using System.Text;
using TW.Servicio.Base;

namespace TW.IServicio.SubCategoria.DTO
{
    public class SubCategoriaDto : BaseDto
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public long CategoriaId { get; set; }
    }
}

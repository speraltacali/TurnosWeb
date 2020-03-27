using System;
using System.Collections.Generic;
using System.Text;
using TW.Servicio.Base;

namespace TW.IServicio.Categoria.DTO
{
    public class CategoriaDto : BaseDto
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public long EmpresaId { get; set; }
    }
}

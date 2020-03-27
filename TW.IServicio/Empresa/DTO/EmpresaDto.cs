using System;
using System.Collections.Generic;
using System.Text;
using TW.Servicio.Base;

namespace TW.IServicio.Empresa.DTO
{
    public class EmpresaDto : BaseDto
    {
        public string RazonSocial { get; set; }

        public string Descripcion { get; set; }

        public string Cuil { get; set; }

        public bool Eliminado { get; set; }
    }
}

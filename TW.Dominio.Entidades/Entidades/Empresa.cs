using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Dominio.Entidades.Entidades
{
    public class Empresa : EntityBase
    {

        public string RazonSocial { get; set; }

        public string Descripcion { get; set; }

        public string Cuil { get; set; }

        public bool Eliminado { get; set; }

        //*******************************************************//

        public virtual IEnumerable<Categoria> Categorias { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Dominio.Entidades.Entidades
{
    public class Categoria : EntityBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public long EmpresaId { get; set; }

        //*************************************************//

        public virtual Empresa Empresa { get; set; }

        public virtual IEnumerable<SubCategoria> SubCategorias { get; set; }
    }
}

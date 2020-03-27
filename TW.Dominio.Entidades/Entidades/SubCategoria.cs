using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Dominio.Entidades.Entidades
{
    public class SubCategoria : EntityBase
    {
        public string Descripcion { get; set; }

        public bool Eliminado { get; set; }

        public long  CategoriaId { get; set; }

        //**********************************************//

        public virtual Categoria Categoria { get; set; }

        public virtual IEnumerable<Lugar> Lugares { get; set; }
    }
}

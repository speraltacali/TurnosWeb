using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Dominio.Entidades.Entidades
{
    public class Usuario : EntityBase
    {
        public string User { get; set; }

        public string Password { get; set; }


        public bool Eliminado { get; set; }
    }
}

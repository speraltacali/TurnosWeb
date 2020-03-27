using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TW.Dominio.Base
{
    public class EntityBase
    {
        [Key]
        public long Id { get; set; }
    }
}

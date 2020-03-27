using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Repositorio.Base
{
    public interface IRepositorio<T> : IRepositorioConsulta<T> , IRepositorioPersistencia<T> where T : EntityBase
    {
    }
}

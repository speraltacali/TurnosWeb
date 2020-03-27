using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Base;

namespace TW.Repositorio.Base
{
    public interface IRepositorioPersistencia<T> where T : EntityBase
    {
        void Agregar(T entidad);

        void Modificar(T entidad);

        void Eliminar(long id);

        void Guardar();
    }
}

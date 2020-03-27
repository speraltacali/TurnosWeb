using System;
using System.Collections.Generic;
using System.Text;
using TW.IServicio.Fecha.DTO;

namespace TW.IServicio.Fecha
{
    public interface IFechaServicio
    {
        FechaDto Agregar(FechaDto dto);

        FechaDto Modificar(FechaDto dto);

        void Eliminar(long id);

        void Guardar();

        //***********************************************//

        IEnumerable<FechaDto> ObtenerTodo();

        IEnumerable<FechaDto> ObtenerPorFiltro(string cadena);

        FechaDto ObtenerPorId(long id);
    }
}

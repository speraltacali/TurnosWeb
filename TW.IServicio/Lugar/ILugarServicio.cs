using System;
using System.Collections.Generic;
using System.Text;
using TW.IServicio.Lugar.DTO;

namespace TW.IServicio.Lugar
{
    public interface ILugarServicio
    {
        LugarDto Agregar(LugarDto dto);

        LugarDto Modificar(LugarDto dto);

        void Eliminar(long id);

        void Guardar();

        //***********************************************//

        IEnumerable<LugarDto> ObtenerTodo();

        IEnumerable<LugarDto> ObtenerPorFiltro(string cadena);

        LugarDto ObtenerPorId(long id);
    }
}

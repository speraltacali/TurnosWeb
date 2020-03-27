using System;
using System.Collections.Generic;
using System.Text;
using TW.IServicio.Horario.DTO;

namespace TW.IServicio.Horario
{
    public interface IHorarioServicio
    {
        HorarioDto Agregar(HorarioDto dto);

        HorarioDto Modificar(HorarioDto dto);

        void Eliminar(long id);

        void Guardar();

        //***********************************************//

        IEnumerable<HorarioDto> ObtenerTodo();

        IEnumerable<HorarioDto> ObtenerPorFiltro(string cadena);

        HorarioDto ObtenerPorId(long id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TW.IServicio.Comprobante.DTO;

namespace TW.IServicio.Comprobante
{
    public interface IComprobanteServicio
    {
        ComprobanteDto Agregar(ComprobanteDto dto);

        ComprobanteDto Modificar(ComprobanteDto dto);

        void Eliminar(long id);

        void Guardar();

        //***********************************************//

        IEnumerable<ComprobanteDto> ObtenerTodo();

        IEnumerable<ComprobanteDto> ObtenerPorFiltro(string cadena);

        ComprobanteDto ObtenerPorId(long id);
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using TW.IServicio.SubCategoria.DTO;

namespace TW.IServicio.SubCategoria
{
    public interface ISubCategoriaServicio
    {
        SubCategoriaDto Agregar(SubCategoriaDto dto);

        SubCategoriaDto Modificar(SubCategoriaDto dto);

        void Eliminar(long id);

        void Guardar();

        //***********************************************//

        IEnumerable<SubCategoriaDto> ObtenerTodo();

        IEnumerable<SubCategoriaDto> ObtenerPorFiltro(string cadena);

        SubCategoriaDto ObtenerPorId(long id);
    }
}

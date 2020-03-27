using System;
using System.Collections.Generic;
using System.Text;
using TW.IServicio.Categoria.DTO;

namespace TW.IServicio.Categoria
{
    public interface ICategoriaServicio
    {
        CategoriaDto Agregar(CategoriaDto dto);

        CategoriaDto Modificar(CategoriaDto dto);

        void Eliminar(long id);

        void Guardar();

        //***********************************************//

        IEnumerable<CategoriaDto> ObtenerTodo();

        IEnumerable<CategoriaDto> ObtenerPorFiltro(string cadena);

        CategoriaDto ObtenerPorId(long id);

    }
}

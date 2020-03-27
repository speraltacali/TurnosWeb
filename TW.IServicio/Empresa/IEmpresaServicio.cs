using System;
using System.Collections.Generic;
using System.Text;
using TW.IServicio.Empresa.DTO;

namespace TW.IServicio.Empresa
{
    public interface IEmpresaServicio
    {
        EmpresaDto Agregar(EmpresaDto dto);

        EmpresaDto Modificar(EmpresaDto dto);

        void Eliminar(long id);

        void Guardar();

        //***********************************************//

        IEnumerable<EmpresaDto> ObtenerTodo();

        IEnumerable<EmpresaDto> ObtenerPorFiltro(string cadena);

        EmpresaDto ObtenerPorId(long id);

    }
}

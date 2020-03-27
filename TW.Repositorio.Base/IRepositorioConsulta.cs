using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;
using System.Text;
using TW.Dominio.Base;

namespace TW.Repositorio.Base
{
    public interface IRepositorioConsulta<T> where T : EntityBase
    {
        T ObtenerPorId(long id);

        T ObtenerPorId(long id , params Expression<Func<T,object>>[] incluirPropiedades);

        T ObtenerPorId(long id , string incluirPropiedades);

        //*************************************************************//

        IEnumerable<T> ObtenerTodo();

        IEnumerable<T> ObtenerTodo(params Expression<Func<T,object>>[] Propiedades);

        IEnumerable<T> ObtenerTodo(string incluirPropiedades);


        //*************************************************************//

        IEnumerable<T> ObtenerPorFiltros(Expression<Func<T,bool>> predicado);

        IEnumerable<T> ObtenerPorFiltros(Expression<Func<T, bool>> predicado ,
            params Expression<Func<T,object>> [] Propiedad);

        IEnumerable<T> ObtenerPorFiltros(Expression<Func<T, bool>> predicado , string incluirPropiedad);

    }
}

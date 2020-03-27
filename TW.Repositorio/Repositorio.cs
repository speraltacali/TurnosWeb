using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TW.Dominio.Base;
using TW.Infraestructura.Context;
using TW.Repositorio.Base;

namespace TW.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : EntityBase
    {
        protected Context Context;

        public Repositorio()
        : this(new Context())
        {
            
        }

        public Repositorio(Context context)
        {
            Context = context;
        }

        //***************************************************************************************//

        public T ObtenerPorId(long id)
        {
            return Context.Set<T>().Find(id);
        }

        public T ObtenerPorId(long id, params Expression<Func<T, object>>[] incluirPropiedades)
        {
            IQueryable<T> query = Context.Set<T>();

            query = incluirPropiedades.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == id);
        }

        public T ObtenerPorId(long id, string incluirPropiedades)
        {
            IQueryable<T> query = Context.Set<T>();

            query = incluirPropiedades.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.FirstOrDefault(x => x.Id == id);
        }

        //***************************************************************************************//

        public IEnumerable<T> ObtenerTodo()
        {
            return Context.Set<T>().AsNoTracking().ToList();
        }

        public IEnumerable<T> ObtenerTodo(params Expression<Func<T, object>>[] Propiedades)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = Propiedades.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<T> ObtenerTodo(string incluirPropiedades)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = incluirPropiedades.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        //***************************************************************************************//

        public IEnumerable<T> ObtenerPorFiltros(Expression<Func<T, bool>> predicado)
        {
            return Context.Set<T>().AsNoTracking().Where(predicado).ToList();
        }

        public IEnumerable<T> ObtenerPorFiltros(Expression<Func<T, bool>> predicado, params Expression<Func<T, object>>[] Propiedad)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = Propiedad.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        public IEnumerable<T> ObtenerPorFiltros(Expression<Func<T, bool>> predicado, string incluirPropiedad)
        {
            IQueryable<T> query = Context.Set<T>().AsNoTracking();

            query = incluirPropiedad.Split('.').Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return query.ToList();
        }

        //***************************************************************************************//

        public void Agregar(T entidad)
        {
            Context.Set<T>().Add(entidad);
        }

        public void Modificar(T entidad)
        {
            Context.Set<T>().Attach(entidad);
            Context.Entry(entidad).State = EntityState.Modified;
        }

        public void Eliminar(long id)
        {
            var entidad = ObtenerPorId(id);
            Context.Set<T>().Remove(entidad);
        }

        public void Guardar()
        {
            Context.SaveChanges();
        }
    }
}

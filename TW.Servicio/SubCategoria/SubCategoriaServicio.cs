using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TW.Dominio.Repositorio.SubCategoria;
using TW.Infraestructura.Repositorio.SubCategoria;
using TW.IServicio.SubCategoria;
using TW.IServicio.SubCategoria.DTO;

namespace TW.Servicio.SubCategoria
{
    public class SubCategoriaServicio : ISubCategoriaServicio
    {
        private readonly ISubCategoriaRepositorio _SubategoriaRepositorio = new SubCategoriaRepositorio();

        public SubCategoriaDto Agregar(SubCategoriaDto dto)
        {
            var entity = new Dominio.Entidades.Entidades.SubCategoria
            {
                Descripcion = dto.Descripcion,
                CategoriaId = dto.CategoriaId,
                Eliminado = false
            };

            _SubategoriaRepositorio.Agregar(entity);
            Guardar();
            dto.Id = entity.Id;

            return dto;
        }

        public SubCategoriaDto Modificar(SubCategoriaDto dto)
        {
            var entity = _SubategoriaRepositorio.ObtenerPorId(dto.Id);

            entity.Descripcion = dto.Descripcion;
            entity.CategoriaId = dto.CategoriaId;

            _SubategoriaRepositorio.Modificar(entity);
            Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var entity = _SubategoriaRepositorio.ObtenerPorId(id);

            if (entity != null)
            {
                entity.Eliminado = true;

                _SubategoriaRepositorio.Modificar(entity);
            }

            Guardar();
        }

        public void Guardar()
        {
            _SubategoriaRepositorio.Guardar();
        }

        public IEnumerable<SubCategoriaDto> ObtenerTodo()
        {
            return _SubategoriaRepositorio.ObtenerTodo()
                .Select(x => new SubCategoriaDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    CategoriaId = x.CategoriaId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public IEnumerable<SubCategoriaDto> ObtenerPorFiltro(string cadena)
        {
            return _SubategoriaRepositorio.ObtenerPorFiltros(x => x.Descripcion.Contains(cadena)
                                                                  && x.Eliminado != true)
                .Select(x => new SubCategoriaDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    CategoriaId = x.CategoriaId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public SubCategoriaDto ObtenerPorId(long id)
        {
            var entity = _SubategoriaRepositorio.ObtenerPorId(id);

            return new SubCategoriaDto()
            {
                Id = entity.Id,
                Descripcion = entity.Descripcion,
                CategoriaId = entity.CategoriaId,
                Eliminado = entity.Eliminado
            };
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using TW.Dominio.Repositorio.Categoria;
using TW.Infraestructura.Repositorio.Categoria;
using TW.IServicio.Categoria;
using TW.IServicio.Categoria.DTO;

namespace TW.Servicio.Categoria
{
    public class CategoriaServicio : ICategoriaServicio
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio = new CategoriaRepositorio();

        public CategoriaDto Agregar(CategoriaDto dto)
        {
            var entity = new Dominio.Entidades.Entidades.Categoria
            {
                Descripcion = dto.Descripcion,
                EmpresaId = dto.EmpresaId,
                Eliminado = false
            };

            _categoriaRepositorio.Agregar(entity);
            Guardar();
            dto.Id = entity.Id;

            return dto;
        }

        public CategoriaDto Modificar(CategoriaDto dto)
        {
            var entity = _categoriaRepositorio.ObtenerPorId(dto.Id);

            entity.Descripcion = dto.Descripcion;
            entity.EmpresaId = dto.EmpresaId;

            _categoriaRepositorio.Modificar(entity);
            Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var entity = _categoriaRepositorio.ObtenerPorId(id);

            if (entity != null)
            {
                entity.Eliminado = true;

                _categoriaRepositorio.Modificar(entity);
            }

            Guardar();
        }

        public void Guardar()
        {
            _categoriaRepositorio.Guardar();
        }

        public IEnumerable<CategoriaDto> ObtenerTodo()
        {
            return _categoriaRepositorio.ObtenerTodo()
                .Select(x => new CategoriaDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EmpresaId = x.EmpresaId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public IEnumerable<CategoriaDto> ObtenerPorFiltro(string cadena)
        {
            return _categoriaRepositorio.ObtenerPorFiltros(x => x.Descripcion.Contains(cadena)
                                                            && x.Eliminado != true)
                .Select(x => new CategoriaDto()
                {
                    Id = x.Id,
                    Descripcion = x.Descripcion,
                    EmpresaId = x.EmpresaId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public CategoriaDto ObtenerPorId(long id)
        {
            var entity = _categoriaRepositorio.ObtenerPorId(id);

            return new CategoriaDto()
            {
                Id = entity.Id,
                Descripcion = entity.Descripcion,
                EmpresaId = entity.EmpresaId,
                Eliminado = entity.Eliminado
            };
        }
    }
}

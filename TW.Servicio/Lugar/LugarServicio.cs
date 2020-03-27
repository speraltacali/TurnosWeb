using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TW.Dominio.Repositorio.Lugar;
using TW.Infraestructura.Repositorio.Lugar;
using TW.IServicio.Lugar;
using TW.IServicio.Lugar.DTO;

namespace TW.Servicio.Lugar
{
    public class LugarServicio : ILugarServicio
    {
        private readonly ILugarRepositorio _lugarRepositorio = new LugarRepositorio();

        public LugarDto Agregar(LugarDto dto)
        {
            var entity = new Dominio.Entidades.Entidades.Lugar()
            {
                Nombre = dto.Nombre,
                Direccion = dto.Direccion,
                SubCategoriaId = dto.SubCategoriaId,
                Eliminado = false
            };

            _lugarRepositorio.Agregar(entity);
            Guardar();
            dto.Id = entity.Id;

            return dto;
        }

        public LugarDto Modificar(LugarDto dto)
        {
            var entity = _lugarRepositorio.ObtenerPorId(dto.Id);

            entity.Nombre = dto.Nombre;
            entity.Direccion = dto.Direccion;
            entity.SubCategoriaId = dto.SubCategoriaId;

            _lugarRepositorio.Modificar(entity);
            Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var entity = _lugarRepositorio.ObtenerPorId(id);

            if (entity != null)
            {
                entity.Eliminado = true;
                _lugarRepositorio.Modificar(entity);
            }

            Guardar();
        }

        public void Guardar()
        {
            _lugarRepositorio.Guardar();
        }

        public IEnumerable<LugarDto> ObtenerTodo()
        {
            return _lugarRepositorio.ObtenerTodo()
                .Select(x => new LugarDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,
                    SubCategoriaId = x.SubCategoriaId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public IEnumerable<LugarDto> ObtenerPorFiltro(string cadena)
        {
            return _lugarRepositorio.ObtenerPorFiltros(x => x.Direccion.Contains(cadena)
                                                            && x.Eliminado != true)
                .Select(x => new LugarDto()
                {
                    Id = x.Id,
                    Nombre = x.Nombre,
                    Direccion = x.Direccion,
                    SubCategoriaId = x.SubCategoriaId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public LugarDto ObtenerPorId(long id)
        {
            var entity = _lugarRepositorio.ObtenerPorId(id);

            return new LugarDto()
            {
                Id = entity.Id,
                Nombre = entity.Nombre,
                Direccion = entity.Direccion,
                SubCategoriaId = entity.SubCategoriaId,
                Eliminado = entity.Eliminado
            };
        }
    }

}

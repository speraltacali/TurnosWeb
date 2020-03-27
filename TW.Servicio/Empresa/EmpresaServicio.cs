using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TW.Dominio.Repositorio.Empresa;
using TW.Infraestructura.Repositorio.Empresa;
using TW.IServicio.Empresa.DTO;
using TW.IServicio.Empresa;

namespace TW.Servicio.Empresa
{
    public class EmpresaServicio : IEmpresaServicio
    {
        private readonly IEmpresaRepositorio _empresaRepositorio = new EmpresaRepositorio();

        public EmpresaDto Agregar(EmpresaDto dto)
        {
            var entity = new Dominio.Entidades.Entidades.Empresa()
            {
                RazonSocial = dto.RazonSocial,
                Descripcion = dto.Descripcion,
                Cuil = dto.Cuil,
                Eliminado = false
            };

            _empresaRepositorio.Agregar(entity);
            Guardar();
            dto.Id = entity.Id;

            return dto;
        }

        public EmpresaDto Modificar(EmpresaDto dto)
        {
            var entity = _empresaRepositorio.ObtenerPorId(dto.Id);

            entity.RazonSocial = dto.RazonSocial;
            entity.Descripcion = dto.Descripcion;
            entity.Cuil = dto.Cuil;
            entity.Eliminado = dto.Eliminado;

            _empresaRepositorio.Modificar(entity);
            Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var entity = _empresaRepositorio.ObtenerPorId(id);

            if (entity != null)
            {
                entity.Eliminado = true;
                _empresaRepositorio.Modificar(entity);
            }

            Guardar();
        }

        public void Guardar()
        {
            _empresaRepositorio.Guardar();
        }

        public IEnumerable<EmpresaDto> ObtenerTodo()
        {
            return _empresaRepositorio.ObtenerTodo()
                .Select(x => new EmpresaDto()
                {
                    Id = x.Id,
                    RazonSocial = x.RazonSocial,
                    Descripcion = x.Descripcion,
                    Cuil = x.Cuil,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public IEnumerable<EmpresaDto> ObtenerPorFiltro(string cadena)
        {
            return _empresaRepositorio.ObtenerPorFiltros(x => x.Descripcion.Contains(cadena))
                .Select(x => new EmpresaDto()
                {
                    Id = x.Id,
                    RazonSocial = x.RazonSocial,
                    Descripcion = x.Descripcion,
                    Cuil = x.Cuil,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public EmpresaDto ObtenerPorId(long id)
        {
            var entity = _empresaRepositorio.ObtenerPorId(id);

            return new EmpresaDto()
            {
                Id = entity.Id,
                RazonSocial = entity.RazonSocial,
                Descripcion = entity.Descripcion,
                Cuil = entity.Cuil,
                Eliminado = entity.Eliminado
            };
        }
    }
}

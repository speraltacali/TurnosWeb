using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TW.Dominio.Repositorio.Comprobante;
using TW.Infraestructura.Repositorio.Comprobante;
using TW.IServicio.Comprobante.DTO;

namespace TW.Servicio.Comprobante
{
    public class ComprobanteServicio
    {
        private readonly IComprobanteRepositorio _comprobanteRepositorio = new ComprobanteRepositorio();

        public ComprobanteDto Agregar(ComprobanteDto dto)
        {
            var entity = new Dominio.Entidades.Entidades.Comprobante()
            {
                Codigo = dto.Codigo,
                FechaSolicitud = dto.FechaSolicitud,
                HorarioId = dto.HorarioId,
                Eliminado = false
            };

            _comprobanteRepositorio.Agregar(entity);
            Guardar();
            dto.Id = entity.Id;

            return dto;
        }

        public ComprobanteDto Modificar(ComprobanteDto dto)
        {
            var entity = _comprobanteRepositorio.ObtenerPorId(dto.Id);

            entity.Codigo = dto.Codigo;
            entity.FechaSolicitud = dto.FechaSolicitud;
            entity.HorarioId = dto.HorarioId;

            _comprobanteRepositorio.Modificar(entity);
            Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var entity = _comprobanteRepositorio.ObtenerPorId(id);

            if (entity != null)
            {
                entity.Eliminado = true;
                _comprobanteRepositorio.Modificar(entity);
            }

            Guardar();
        }

        public void Guardar()
        {
            _comprobanteRepositorio.Guardar();
        }

        public IEnumerable<ComprobanteDto> ObtenerTodo()
        {
            return _comprobanteRepositorio.ObtenerTodo()
                .Select(x => new ComprobanteDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    FechaSolicitud = x.FechaSolicitud,
                    HorarioId = x.HorarioId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public IEnumerable<ComprobanteDto> ObtenerPorFiltro(string cadena)
        {
            return _comprobanteRepositorio.ObtenerPorFiltros(x => x.FechaSolicitud.Date.ToString() == cadena
                                                            || x.Codigo.Contains(cadena) && x.Eliminado != true)
                .Select(x => new ComprobanteDto()
                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    FechaSolicitud = x.FechaSolicitud,
                    HorarioId = x.HorarioId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public ComprobanteDto ObtenerPorId(long id)
        {
            var entity = _comprobanteRepositorio.ObtenerPorId(id);

            return new ComprobanteDto()
            {
                Id = entity.Id,
                Codigo = entity.Codigo,
                FechaSolicitud = entity.FechaSolicitud,
                HorarioId = entity.HorarioId,
                Eliminado = entity.Eliminado
            };
        }
    }
}

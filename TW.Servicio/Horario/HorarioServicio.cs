using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TW.Dominio.Repositorio.Horario;
using TW.Infraestructura.Repositorio.Horario;
using TW.IServicio.Horario;
using TW.IServicio.Horario.DTO;

namespace TW.Servicio.Horario
{
    public class HorarioServicio : IHorarioServicio
    {
        private readonly IHorarioRepositorio _horarioRepositorio = new HorarioRepositorio();

        public HorarioDto Agregar(HorarioDto dto)
        {
            var entity = new Dominio.Entidades.Entidades.Horario()
            {
                Hora = dto.Hora,
                FechaId = dto.FechaId,
                Eliminado = false
            };

            _horarioRepositorio.Agregar(entity);
            Guardar();
            dto.Id = entity.Id;

            return dto;
        }

        public HorarioDto Modificar(HorarioDto dto)
        {
            var entity = _horarioRepositorio.ObtenerPorId(dto.Id);

            entity.Hora = dto.Hora;
            entity.FechaId = dto.FechaId;

            _horarioRepositorio.Modificar(entity);
            Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var entity = _horarioRepositorio.ObtenerPorId(id);

            if (entity != null)
            {
                entity.Eliminado = true;
                _horarioRepositorio.Modificar(entity);
            }

            Guardar();
        }

        public void Guardar()
        {
            _horarioRepositorio.Guardar();
        }

        public IEnumerable<HorarioDto> ObtenerTodo()
        {
            return _horarioRepositorio.ObtenerTodo()
                .Select(x => new HorarioDto()
                {
                    Id = x.Id,
                    Hora = x.Hora,
                    FechaId = x.FechaId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public IEnumerable<HorarioDto> ObtenerPorFiltro(string cadena)
        {
            return _horarioRepositorio.ObtenerPorFiltros(x => x.Hora.Hour.ToString() == cadena
                                                              && x.Eliminado != true)
                .Select(x => new HorarioDto()
                {
                    Id = x.Id,
                    Hora = x.Hora,
                    FechaId = x.FechaId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public HorarioDto ObtenerPorId(long id)
        {
            var entity = _horarioRepositorio.ObtenerPorId(id);

            return new HorarioDto()
            {
                Id = entity.Id,
                Hora = entity.Hora,
                FechaId = entity.FechaId,
                Eliminado = entity.Eliminado
            };
        }
    }
}

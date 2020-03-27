using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TW.Dominio.Repositorio.Fecha;
using TW.Infraestructura.Repositorio.Fecha;
using TW.IServicio.Fecha.DTO;
using TW.IServicio.Horario.DTO;

namespace TW.Servicio.Fecha
{
    public class FechaServicio
    {
        private readonly IFechaRepositorio _fechaRepositorio = new FechaRepositorio();

        public FechaDto Agregar(FechaDto dto)
        {
            var entity = new Dominio.Entidades.Entidades.Fecha()
            {
                FechaTurno = dto.FechaTurno,
                LugarId = dto.LugarId,
                Eliminado = false
            };

            _fechaRepositorio.Agregar(entity);
            Guardar();
            dto.Id = entity.Id;

            return dto;
        }

        public FechaDto Modificar(FechaDto dto)
        {
            var entity = _fechaRepositorio.ObtenerPorId(dto.Id);

            entity.FechaTurno = dto.FechaTurno;
            entity.LugarId = dto.LugarId;

            _fechaRepositorio.Modificar(entity);
            Guardar();

            return dto;
        }

        public void Eliminar(long id)
        {
            var entity = _fechaRepositorio.ObtenerPorId(id);

            if (entity != null)
            {
                entity.Eliminado = true;
                _fechaRepositorio.Modificar(entity);
            }

            Guardar();
        }

        public void Guardar()
        {
            _fechaRepositorio.Guardar();
        }

        public IEnumerable<FechaDto> ObtenerTodo()
        {
            return _fechaRepositorio.ObtenerTodo()
                .Select(x => new FechaDto()
                {
                    FechaTurno = x.FechaTurno,
                    LugarId = x.LugarId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public IEnumerable<FechaDto> ObtenerPorFiltro(string cadena)
        {
            return _fechaRepositorio.ObtenerPorFiltros(x => x.FechaTurno.Date.ToString() == cadena
                                                            && x.Eliminado != true)
                .Select(x => new FechaDto()
                {
                    FechaTurno = x.FechaTurno,
                    LugarId = x.LugarId,
                    Eliminado = x.Eliminado
                }).ToList();
        }

        public FechaDto ObtenerPorId(long id)
        {
            var entity = _fechaRepositorio.ObtenerPorId(id);

            return new FechaDto()
            {
                FechaTurno = entity.FechaTurno,
                LugarId = entity.LugarId,
                Eliminado = entity.Eliminado
            };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TW.IServicio.Empresa;
using TW.IServicio.Empresa.DTO;
using TW.Servicio.Empresa;

namespace Angular_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaServicio _empresaServicio;

        public EmpresaController(EmpresaServicio empresaServicio)
        {
            _empresaServicio = empresaServicio;
        }

        [HttpGet("[action]")]
        public IEnumerable<EmpresaDto> ObtenerTodo()
        {
            return _empresaServicio.ObtenerTodo();
        }

        public class Persona
        {
            public long Id { get; set; }

            public string Nombre { get; set; }

            public string Apellido { get; set; }
        }

        [HttpGet("[action]")]
        public IEnumerable<Persona> GetPersona()
        {
            List<Persona> personas = new List<Persona>();

            var persona = new Persona()
            {
                Id = 1,
                Nombre = "Santiago",
                Apellido = "Gonzalez"
            };

            personas.Add(persona);

            var persona1 = new Persona()
            {
                Id = 2,
                Nombre = "Juan",
                Apellido = "Diaz"
            };

            personas.Add(persona1);

            var persona2 = new Persona()
            {
                Id = 3,
                Nombre = "Pepe",
                Apellido = "Nemez"
            };

            personas.Add(persona2);

            var persona3 = new Persona()
            {
                Id = 4,
                Nombre = "Jose",
                Apellido = "Velez"
            };

            personas.Add(persona3);

            return personas.ToList();
        }
    }
}
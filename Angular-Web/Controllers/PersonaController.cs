using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Angular_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly ILogger<PersonaController> _logger;

        public PersonaController(ILogger<PersonaController> logger)
        {
            _logger = logger;
        }

        public class Persona
        {
            public long Id { get; set; }

            public string Nombre { get; set; }

            public string Apellido { get; set; }
        }

        [HttpGet]
        public IEnumerable<Persona> Get()
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
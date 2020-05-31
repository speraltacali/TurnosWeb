using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TW.IServicio.Empresa;
using TW.IServicio.Empresa.DTO;
using TW.Servicio.Empresa;

namespace Angular_Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaServicio _empresaServicio = new EmpresaServicio();
        private readonly ILogger<EmpresaController> _logger;


        public EmpresaController(ILogger<EmpresaController> logger)
        {
            _logger = logger;
        }

        //api/Empresa
        [HttpGet]
        public IEnumerable<EmpresaDto> Get()
        {
            return _empresaServicio.ObtenerTodo();
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmpresa([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var Empresa = _empresaServicio.ObtenerPorId(id);

            if (Empresa == null)
            {
                return NotFound();
            }

            return Ok(Empresa);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa([FromRoute] long id,[FromBody] EmpresaDto empresaDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != empresaDto.Id)
            {
                return BadRequest();
            }

            var empresa = _empresaServicio.Modificar(empresaDto);

            try
            {
                _empresaServicio.Guardar();
                // Verificar linea , no aplica 
                return Ok(empresa);
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!EmpresaExiste(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmpresaDto empresaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa =_empresaServicio.Agregar(empresaDto);

            return Ok(empresa);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa([FromRoute] long id)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var empresa = _empresaServicio.ObtenerPorId(id);

            if(empresa == null)
            {
                return NotFound();
            }

            _empresaServicio.Eliminar(id);

            return Ok(empresa);
        }

        private bool EmpresaExiste(long id)
        {
            return _empresaServicio.ObtenerTodo().Any(x => x.Id == id);
        }
      
    }
}
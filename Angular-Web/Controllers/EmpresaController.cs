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
        private readonly IEmpresaServicio _empresaServicio = new EmpresaServicio();

        [HttpGet]
        public IEnumerable<EmpresaDto> ObtenerTodo()
        {
            return _empresaServicio.ObtenerTodo();
        }
    }
}
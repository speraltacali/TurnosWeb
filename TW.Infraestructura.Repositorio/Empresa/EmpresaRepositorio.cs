using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Repositorio.Empresa;
using TW.Repositorio;

namespace TW.Infraestructura.Repositorio.Empresa
{
    public class EmpresaRepositorio : Repositorio<Dominio.Entidades.Entidades.Empresa> , IEmpresaRepositorio
    {
    }
}

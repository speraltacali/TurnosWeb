using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Repositorio.Lugar;
using TW.Repositorio;

namespace TW.Infraestructura.Repositorio.Lugar
{
    public class LugarRepositorio : Repositorio<Dominio.Entidades.Entidades.Lugar> , ILugarRepositorio 
    {
    }
}

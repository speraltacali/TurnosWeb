using System;
using System.Collections.Generic;
using System.Text;
using TW.Dominio.Repositorio.Comprobante;
using TW.Repositorio;

namespace TW.Infraestructura.Repositorio.Comprobante
{
    public class ComprobanteRepositorio : Repositorio<Dominio.Entidades.Entidades.Comprobante> , IComprobanteRepositorio
    {
    }
}

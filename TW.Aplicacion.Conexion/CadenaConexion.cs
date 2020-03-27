using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace TW.Aplicacion.Conexion
{
    public  class CadenaConexion
    {
        public const string DataBase = "TurnosWeb";


        public const string Server = "DESKTOP-NK0OJF1";


        public static string AccesoCadenaConexion => $"Data Source={Server};" +
                                                     $"Initial Catalog={DataBase};" +
                                                     $"Integrated Security=true";
        //$"User Id={User};" +
        //$"Password={Password};";
    }
}

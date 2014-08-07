using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using SubastaAutos;
namespace SubastAutos.Web.Conexion
{
    public class Prueba
    {
        
        public String getColor ()
        {
               DbSubAsTAs db= new DbSubAsTAs(new MySqlConnection("Database=dbsubastas;Data Source=localhost;User Id=root;Password="));
               string res = "";
               return res;
        }
    }
}
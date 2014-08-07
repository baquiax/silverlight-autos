using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubastAutos.ModeloDeDatos
{
    public class DetallesDeEstadoDelVehiculo
    {
        public int IdEstado { set; get; }
        public int IdVehiculo { set; get; }
        public String Tema { set; get; }
        public String Descripcion { set; get; }
    }
}
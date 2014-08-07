using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubastAutos.ModeloDeDatos
{
    public class Subasta
    {
        public int IdSubasta { set; get; }
        public int IdVehiculo { set; get; }
        public String LogginDueño { set; get; }
        public int hora { set; get; }
        public String fechaPropuesta { set; get; }
        public Double PrecioSugerido { set; get; }
        public sbyte Estado { set; get; }
        public List<ModeloDeDatos.Vehiculo> VehiculosDeSubasta { set; get; }
    }
}
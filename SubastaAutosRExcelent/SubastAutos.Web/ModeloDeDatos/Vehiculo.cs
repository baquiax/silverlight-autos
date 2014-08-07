using System;
using System.Net;
using System.Collections.Generic;

namespace SubastAutos.ModeloDeDatos
{
    public class Vehiculo
    {
        public int idVehiculo
        {
            set;
            get;
        }
        public String placa
        {
            set;
            get;
        }

        public int idCombustible
        {
            set;
            get;
        }
        public String combustible
        {
            set;
            get;
        }
        public String marca
        {
            set;
            get;
        }
        public int  año
        {
            set;
            get;
        }
        public String modelo
        {
            set;
            get;
        }
        public Double kilometraje
        {
            set;
            get;
        }
        public String color
        {
            set;
            get;
        }

        public int idTipoVehiculo
        {
            set;
            get;
        }

        public String tipoVehiculo
        {
            set;
            get;
        }
        public Double precioBase
        {
            set;
            get;
        }

        public int idEstado
        {
            set;
            get;
        }
        public String estado
        {
            set;
            get;
        }
        public String pathImagen
        {
            set;
            get;
        }
    }
    public class Vehiculos : List<Vehiculo> { }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubastAutos.ModeloDeDatos
{
    public class Departamento
    {
        public int idDepartamento { set; get; }
        public String departamento { set; get; }
    }

    public class Municipio {
        public int idDepartamento { set; get; }
        public int idMunicipio { set; get; }
        public String municipio { set; get; }
    }

}
using System;
using System.Net;
using System.Collections.Generic;

namespace SubastAutos.ModeloDeDatos
{

    public class Usuario{
	        public String Loggin { set; get; }
            public String Password { set; get; }
		    public int Estado { set; get; }
            public int IdRol { set; get; }
            public String Rol { set; get; }
     }
	 public class Usuarios : List<Usuario>{
        }
}

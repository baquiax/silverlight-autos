using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SubastAutos.ModeloDeDatos
{
    public class Perfil
    {
        public String loggin {set;get;}
	    public String nombresUsuario {set;get;}
	    public String apellidosUsuario {set;get;}
	    public String pais {set;get;}
	    public String depto {set;get;}
	    public String ciudad {set;get;}
	    public String direccion {set;get;}
	    public String telefono {set;get;}
	    public String mail {set;get;}
	    public String fax {set;get;}
	    public String fechaNacimiento {set;get;}
	    public String codigoPostal {set;get;}
	    public int idSexo {set;get;}
        public String sexo { set; get; }
        public String foto { set; get; }
        public SubastAutos.Web.PictureFile Picture { set; get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace SubastAutos.ModeloDeDatos
{
    public class DetalleVehiculo
    {
        public int IdDetalle { set; get; }
        public int IdVehiculo { set; get; }
        public SubastAutos.Web.PictureFile Foto { set; get; }
        public String Comentario { set; get; }
        
    }
}
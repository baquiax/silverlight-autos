using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.Windows.Data;
using System.IO;

namespace SubastAutos.Convertidores
{
    public  class ConvertidorImagen : IValueConverter 
    {
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ServicioAlCliente.PictureFile img = (ServicioAlCliente.PictureFile)value;
            byte[] bytes = (byte[]) img.PictureStream;
            BitmapImage imagenPerfil = new BitmapImage();
            MemoryStream stremImagen = new MemoryStream(bytes);
            imagenPerfil.SetSource(stremImagen);
            BitmapImage nuevaImagen = new BitmapImage();
            nuevaImagen.SetSource(stremImagen);
            return nuevaImagen;
        }
    }
}

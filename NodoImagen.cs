using System.Drawing;

namespace WindowsFormsApp3
{
    internal class NodoImagen
    {
        public string Ruta { get; set; }
        public Image Imagen { get; set; }
        public NodoImagen Siguiente { get; set; }
        public NodoImagen Anterior { get; set; } //puntero al nodo anterior

        public NodoImagen(string ruta)
        {
            Ruta = ruta;
            try
            {
                Imagen = Image.FromFile(ruta);
            }
            catch//para evitar que se caiga el programa si la ruta es inválida, se captura la excepción y se asigna null a la imagen
            {
                Imagen = null; // Por si falla la ruta
            }
            Siguiente = null;
            Anterior = null;
        }
    }
}
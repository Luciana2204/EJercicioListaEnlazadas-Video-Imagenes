using System.Drawing;

namespace WindowsFormsApp3
{
    internal class ListaSimpleEnlazada
    {
        private NodoImagen Cabeza { get; set; }
        private NodoImagen Cola { get; set; }
        private NodoImagen actual; // Puntero de navegación

        public ListaSimpleEnlazada()
        {
            Cabeza = null;
            Cola = null;
            actual = null;
        }

        //  Método para agregar una imagen a la lista doblemente enlazada
        public void AgregarImagen(string ruta)
        {
            NodoImagen nuevoNodo = new NodoImagen(ruta);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                Cola = nuevoNodo;
                actual = Cabeza; // El primer nodo es el actual
            }
            else
            {
                Cola.Siguiente = nuevoNodo;
                nuevoNodo.Anterior = Cola; // Enlazamos hacia atrás
                Cola = nuevoNodo;          // El nuevo nodo pasa a ser la cola
            }
        }

        // Avanza al siguiente nodo (SE DETIENE al llegar al último)
        public Image ObtenerSiguienteImagen()
        {
            if (actual == null) return null;

            // Si hay un nodo siguiente, avanza. Si no, se queda en el último.
            if (actual.Siguiente != null)
            {
                actual = actual.Siguiente;
            }

            return actual.Imagen;
        }

        //  Retrocede al nodo anterior (SE DETIENE al llegar al primero)
        public Image ObtenerAnteriorImagen()
        {
            if (actual == null) return null;

            // Si hay un nodo anterior, retrocede. Si no, se queda en el primero.
            if (actual.Anterior != null)
            {
                actual = actual.Anterior;
            }

            return actual.Imagen;
        }

        //  Método para obtener la imagen en la posición actual
        public Image ObtenerImagenActual()
        {
            return actual?.Imagen;
        }

        // Método para resetear la posición 'actual' al inicio
        public void Reiniciar()
        {
            actual = Cabeza;
        }
    }
}
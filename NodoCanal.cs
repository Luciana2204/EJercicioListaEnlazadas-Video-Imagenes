using System;

// Actualizado del namespace anterior para reflejar la nueva estructura de lista
namespace ListaSimplementeEnlazadaVideo
{
    internal class NodoCanal
    {
        public string Nombre { get; set; }
        public string UrlStream { get; set; }
        public NodoCanal Siguiente { get; set; }

        // NUEVO: referencia al nodo previo para permitir navegación hacia atrás
        public NodoCanal Anterior { get; set; }

        public NodoCanal(string nombre, string url)
        {
            Nombre = nombre;
            UrlStream = url;
            Siguiente = null;

            // NUEVO: al crearse sin enlazar, el nodo anterior comienza en null
            Anterior = null;
        }
    }
}
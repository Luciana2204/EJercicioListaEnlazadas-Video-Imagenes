using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaSimplementeEnlazadaVideo
{
    internal class ListaDoblecircularanales
    {
        private NodoCanal Cabeza { get; set; }
        private NodoCanal actual;

        public ListaDoblecircularanales()
        {
            Cabeza = null;
            actual = null;
        }

        // Método para agregar un nuevo canal manteniendo el doble enlace y la forma circular
        public void AgregarCanal(string nombre, string url)
        {
            NodoCanal nuevoNodo = new NodoCanal(nombre, url);

            if (Cabeza == null)
            {
                Cabeza = nuevoNodo;
                actual = Cabeza;

                // NUEVO: si solo hay un nodo, tanto su Siguiente como su Anterior apuntan a sí mismo
                // para que la lista ya sea circular desde el primer elemento
                Cabeza.Siguiente = Cabeza;
                Cabeza.Anterior = Cabeza;
                return;
            }

            // CAMBIO: antes recorría hasta temp.Siguiente != null; en una lista circular
            // el último nodo apunta a Cabeza, no a null
            NodoCanal temp = Cabeza;
            while (temp.Siguiente != Cabeza)
            {
                temp = temp.Siguiente;
            }

            // NUEVO: conecta el último nodo actual con el nuevo nodo hacia adelante y hacia atrás
            temp.Siguiente = nuevoNodo;
            nuevoNodo.Anterior = temp;

            // NUEVO: cierra el círculo conectando el nuevo último nodo con Cabeza en ambos sentidos
            nuevoNodo.Siguiente = Cabeza;
            Cabeza.Anterior = nuevoNodo;
        }

        // Obtiene el nodo actual (para la reproducción inicial o después de reiniciar)
        public NodoCanal ObtenerCanalActual()
        {
            return actual;
        }

        // CAMBIO: se quitó la condición que frenaba en el último nodo; ahora siempre avanza
        // a actual.Siguiente, por lo que al llegar al último canal vuelve automáticamente a Cabeza
        public NodoCanal ObtenerSiguienteCanal()
        {
            if (actual != null)
            {
                actual = actual.Siguiente;
            }
            return actual;
        }

        // NUEVO: aprovecha el puntero Anterior de NodoCanal para retroceder al canal previo;
        // si estás en Cabeza, salta de forma circular hasta el último canal
        public NodoCanal ObtenerCanalAnterior()
        {
            if (actual != null)
            {
                actual = actual.Anterior;
            }
            return actual;
        }

        // Vuelve al primer canal de la lista
        public void Reiniciar()
        {
            actual = Cabeza;
        }
    }
}
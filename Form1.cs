using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //Para usar archivos de windows      
namespace ListaSimplementeEnlazadaVideo
{
    public partial class Form1 : Form
    {
        private ListaDoblecircularanales galeriaCanales;
        public Form1()
        {
            InitializeComponent();
            InicializarCanales();
        }

        private void InicializarCanales()
        {
            galeriaCanales = new ListaDoblecircularanales();

           


            string rutaResources = @"E:\proyecto 2 estructura de datos\ListaSimplementeEnlazadaVideo\Resources";// se usa la ruta de la carpeta Resources para acceder a los archivos de video

            //  AGREGAR CANALES A LA LISTA DOBLE CIRCULAR 
            galeriaCanales.AgregarCanal("Canal 1: En este canal veras como caza un Tigre", Path.Combine(rutaResources, "V1.mp4"));
            galeriaCanales.AgregarCanal("Canal 2: En este canal veras como caza un Leon", Path.Combine(rutaResources, "V2.mp4"));
            galeriaCanales.AgregarCanal("Canal 3: En este canal veras un VS entre una mantis y una avispa", Path.Combine(rutaResources, "V3.mp4"));
            galeriaCanales.AgregarCanal("Canal 4: En este canal veras como caza un cocodrilo", Path.Combine(rutaResources, "V4.mp4"));
            galeriaCanales.AgregarCanal("Canal 5: En este canal veras como caza un tiburon", Path.Combine(rutaResources, "V5.mp4"));
            galeriaCanales.AgregarCanal("Canal 6: En este canal veras como caza un lobo", Path.Combine(rutaResources, "V6.mp4"));

            // Iniciar con el primer canal
            ReproducirCanal(galeriaCanales.ObtenerCanalActual());
        }

        private void ReproducirCanal(NodoCanal canal)
        {
            if (canal != null)
            {
                // 1. Mostrar el nombre del canal
                lblNombreCanal.Text = $"🔴 En Vivo: {canal.Nombre}";

                // 2. Cargar y reproducir el stream en el AxWindowsMediaPlayer
                // La propiedad URL es la clave para iniciar la reproducción.
                axWindowsMediaPlayer1.URL = canal.UrlStream;
            }
            else
            {
                lblNombreCanal.Text = "FIN DE LA LISTA DE CANALES";
                axWindowsMediaPlayer1.URL = string.Empty; // Detener la reproducción
            }
        }
        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Pide a la lista enlazada que avance su puntero al siguiente nodo
            NodoCanal siguienteCanal = galeriaCanales.ObtenerSiguienteCanal();

            // Actualiza la visualización
            ReproducirCanal(siguienteCanal);
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Vuelve al primer nodo y actualiza la visualización
            galeriaCanales.Reiniciar();
            ReproducirCanal(galeriaCanales.ObtenerCanalActual());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

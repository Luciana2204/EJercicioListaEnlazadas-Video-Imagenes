using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3;

namespace ListaEnlazadaImagenes
{
    public partial class FormPrincipal : Form
    {
        private ListaSimpleEnlazada galeriaImagenes;
        public FormPrincipal()
        {
            InitializeComponent();
            // 1. Inicializar la lista enlazada y cargar imágenes al inicio.
            InicializarGaleria();
        }

        private void InicializarGaleria()
        {
            galeriaImagenes = new ListaSimpleEnlazada();

              galeriaImagenes.AgregarImagen(@"E:\proyecto 2 estructura de datos\WindowsFormsApp3\Imagenes\1.jpg");
              galeriaImagenes.AgregarImagen(@"E:\proyecto 2 estructura de datos\WindowsFormsApp3\Imagenes\2.jpg");
              galeriaImagenes.AgregarImagen(@"E:\proyecto 2 estructura de datos\WindowsFormsApp3\Imagenes\3.jpg");
              galeriaImagenes.AgregarImagen(@"E:\proyecto 2 estructura de datos\WindowsFormsApp3\Imagenes\4.jpg");
              galeriaImagenes.AgregarImagen(@"E:\proyecto 2 estructura de datos\WindowsFormsApp3\Imagenes\5.jpg");
          
              galeriaImagenes.AgregarImagen(@"E:\proyecto 2 estructura de datos\WindowsFormsApp3\Imagenes\6.jpg");
              galeriaImagenes.AgregarImagen(@"E:\proyecto 2 estructura de datos\WindowsFormsApp3\Imagenes\7.jpg");
              galeriaImagenes.AgregarImagen(@"E:\proyecto 2 estructura de datos\WindowsFormsApp3\Imagenes\8.jpg");

            // Mostrar la primera imagen al cargar el formulario
            ActualizarPictureBox(galeriaImagenes.ObtenerImagenActual());
        }

        // Función de utilidad para actualizar el PictureBox
        private void ActualizarPictureBox(Image img)
        {
            if (img != null)
            {
                pictureBoxImagen.Image = img;
            }
        }
      

        private void FormPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            // Esto llama al método de la lista enlazada que avanza el puntero interno
            Image siguienteImg = galeriaImagenes.ObtenerSiguienteImagen();

            // Actualiza la UI
            ActualizarPictureBox(siguienteImg);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            // Esto llama al método de la lista enlazada que resetea el puntero 'actual' a 'Cabeza'
            galeriaImagenes.Reiniciar();

            // Actualiza la UI con la imagen de la Cabeza
            ActualizarPictureBox(galeriaImagenes.ObtenerImagenActual());
        }

        private void btnanterior_Click(object sender, EventArgs e)
        {
            // Llama al método que retrocede en la lista y actualiza el PictureBox (ej. pictureBox1)
            Image anteriorImg = galeriaImagenes.ObtenerAnteriorImagen();
            ActualizarPictureBox(anteriorImg);
        }

        private void pictureBoxImagen_Click(object sender, EventArgs e)
        {

        }
    }
}

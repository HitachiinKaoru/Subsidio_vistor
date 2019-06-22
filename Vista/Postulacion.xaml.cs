using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para Postulacion.xaml
    /// </summary>
    public partial class Postulacion : MetroWindow
    {
        public Postulacion()
        {
            InitializeComponent();
            btnDetalle.Visibility = Visibility.Hidden;
        }

        private async void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool resp = true; //postulante.Grabar();
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Postulación Guardada" : "No se guardo la Postulación"));

                btnDetalle.Visibility = Visibility.Visible;
            }
            catch (ArgumentException exa) //catch excepciones hechas por el usuario
            {
                await this.ShowMessageAsync("Mensaje:", string.Format((exa.Message)));
            }
            catch (Exception ex)
            {
                await this.ShowMessageAsync("Mensaje:",
                      string.Format("Error al ingresar los datos"));
               
                //Logger.Mensaje(ex.Message);
            }

        }

        private void btnDetalle_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVolverP_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

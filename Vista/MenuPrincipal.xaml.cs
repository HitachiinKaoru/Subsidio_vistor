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
using System.Windows.Navigation;
using System.Windows.Shapes;

using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using MahApps.Metro.Behaviours;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MenuPrincipal : MetroWindow
    {
     
        public MenuPrincipal()
        {
            InitializeComponent();
        }


        private void btnBeneficiados_Click(object sender, RoutedEventArgs e)
        {
            ListarBeneficiados beneficiados = new ListarBeneficiados();
            beneficiados.Show();
        }

        private void btnPostular_Click(object sender, RoutedEventArgs e)
        {
            Postulacion pos = new Postulacion();
            pos.Show();
        }

        private void btnPuntaje_Click(object sender, RoutedEventArgs e)
        {
            DetallePuntaje puntaje = new DetallePuntaje();
            puntaje.Show();
        }
    }
}

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

using Oracle.ManagedDataAccess.Client;  //referencia a oracle, un cliente
using Oracle.ManagedDataAccess.Types; //referencia a oracle: tipos de dato de oracle
using System.Data;

using Conexion;
using CapaAccesoDatos;

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para DetallePuntaje.xaml
    /// </summary>
    public partial class DetallePuntaje : MetroWindow
    {
        ConexionOracle Oracle = new ConexionOracle();
        OracleConnection Cone = new OracleConnection();
        Postulante pos = new Postulante();
        public DetallePuntaje()
        {
            InitializeComponent();
        }

        private async void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (txtBuscarPostulante.Text != null)
            {
                string rut = txtBuscarPostulante.Text;
                
                Cone = Oracle.abrirConexion(); 

                OracleCommand cmd = new OracleCommand("FN_LISTAR_TODO (rut string)", Cone);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Postulante> listaBeneficiados = new List<Postulante>();

                OracleParameter copia_cursor = cmd.Parameters.Add("L_TODO", OracleDbType.RefCursor); // es igual a %rowtype
                copia_cursor.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader info_leida = ((OracleRefCursor)copia_cursor.Value).GetDataReader(); //lo parseamos a cursor, por los distintos tipo de datos que contiene
                while (info_leida.Read())
                {
                    //rescatamos
                    Postulante pos = new Postulante();
                    pos.Rut = info_leida.GetString(0);
                    pos.Nombre = info_leida.GetString(1);
                    pos.Edad = info_leida.GetInt32(2);
                    pos.PuntjEdad = info_leida.GetInt32(3);
                    pos.CantCargas = info_leida.GetInt32(4);
                    pos.PuntjCargas = info_leida.GetInt32(5);
                    pos.EstadoCivil = info_leida.GetString(6);
                    pos.PuntjCivil = info_leida.GetInt32(7);
                    pos.PuebloIndigena = info_leida.GetString(8);
                    pos.PuntjIndigena = info_leida.GetInt32(9);
                    pos.MontoAhorrado = info_leida.GetString(10);
                    pos.PuntjAhorro = info_leida.GetInt32(11);
                    pos.Titulo = info_leida.GetString(12);
                    pos.PuntjTitulo = info_leida.GetInt32(13);
                    pos.Region = info_leida.GetString(14);
                    pos.PuntjRegion = info_leida.GetInt32(15);
                    pos.TipoVivienda = info_leida.GetString(16);
                    pos.ValorVivienda = info_leida.GetString(17);
                    pos.PuntjTotal = info_leida.GetInt32(18);


                    //agregamos a la lista
                    listaBeneficiados.Add(pos);
                }

                gvListarFiltro.ItemsSource = listaBeneficiados;
                txtAhorro.Text = pos.PuntjAhorro.ToString();
                txtCarga.Text = pos.PuntjCargas.ToString();
                txtEdad.Text = pos.PuntjEdad.ToString();
                txtEstadoCivil.Text = pos.PuntjCivil.ToString();
                txtIndigena.Text = pos.PuntjIndigena.ToString();
                txtRegion.Text = pos.PuntjRegion.ToString();
                txtTitulo.Text = pos.PuntjTitulo.ToString();
                txtTotal.Text = pos.PuntjTotal.ToString();

            }

        }

      

        private Task ShowMessageAsync(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private void btnVolverDP_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

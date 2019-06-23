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
    /// Lógica de interacción para Postulacion.xaml
    /// </summary>
    public partial class Postulacion : MetroWindow
    {
        
        ConexionOracle Oracle = new ConexionOracle();
        OracleConnection Cone = new OracleConnection();
        Postulante postulante = new Postulante();

        public Postulacion()
        {
            InitializeComponent();
            btnDetalle.Visibility = Visibility.Hidden;
            gPuntaje.Visibility = Visibility.Hidden;

            Cone = Oracle.abrirConexion();
            cbTipoTitulo.ItemsSource = Enum.GetValues(typeof(TipoTitulo));
            cbTipoTitulo.SelectedIndex = 0;

            foreach (Genero item in new Genero().ReadAll2())
            {
                comboBoxItem cb = new comboBoxItem();
                cb.id = item.Id_genero;
                cb.descripcion = item.Descripcion;
                cbGenero.Items.Add(cb);
            }
            cbGenero.SelectedIndex = 0;

            foreach (EstadoCivil item in new EstadoCivil().ReadAll3())
            {
                comboBoxItem cc = new comboBoxItem();
                cc.id = item.Id_estado_civil;
                cc.descripcion = item.Descripcion;
                cbEstadoCivil.Items.Add(cc);
            }
            cbEstadoCivil.SelectedIndex = 0;

            foreach (TipoVivienda item in new TipoVivienda().ReadAll4())
            {
                comboBoxItem cc = new comboBoxItem();
                cc.id = item.Id_tipo_vivienda;
                cc.descripcion = item.Descripcion;
                cbTipoVivienda.Items.Add(cc);
            }
            cbTipoVivienda.SelectedIndex = 0;

            foreach (Region item in new Region().ReadAll5())
            {
                comboBoxItem cc = new comboBoxItem();
                cc.id = item.Id_region;
                cc.descripcion = item.Descripcion;
                cbRegion.Items.Add(cc);
            }
            cbRegion.SelectedIndex = 0;

            foreach (PuebloOriginario item in new PuebloOriginario().ReadAll6())
            {
                comboBoxItem cc = new comboBoxItem();
                cc.id = item.Id_pueblo;
                cc.descripcion = item.Descripcion;
                cbIndigena.Items.Add(cc);
            }
            cbIndigena.SelectedIndex = 0;

            foreach (Nacionalidad item in new Nacionalidad().ReadAll7())
            {
                comboBoxItem cc = new comboBoxItem();
                cc.id = item.Id_nacionalidad;
                cc.descripcion = item.Descripcion;
                cbNacionalidad.Items.Add(cc);
            }
            cbNacionalidad.SelectedIndex = 0;

        }


        /// ///////////////////////////////////////

        private async void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OracleCommand cmd = new OracleCommand("sp_insertar_postulante", Cone);
                cmd.CommandType = CommandType.StoredProcedure;


                OracleParameter p_rut_postulante = new OracleParameter("p_rut_postulante", OracleDbType.Varchar2);
                p_rut_postulante.Direction = ParameterDirection.Input;
                p_rut_postulante.Value = txtRut.Text;

                OracleParameter p_nombre = new OracleParameter("p_nombre", OracleDbType.Varchar2);
                p_nombre.Direction = ParameterDirection.Input;
                p_nombre.Value = txtNombres.Text;

                OracleParameter p_apellidos = new OracleParameter("p_apellidos", OracleDbType.Varchar2);
                p_apellidos.Direction = ParameterDirection.Input;
                p_apellidos.Value = txtApellidos.Text;

                OracleParameter p_fecha_nac = new OracleParameter("p_fecha_nac", OracleDbType.Date);
                p_fecha_nac.Direction = ParameterDirection.Input;
                p_fecha_nac.Value = dpFechaNac.Text;

                OracleParameter p_telefono = new OracleParameter("p_telefono", OracleDbType.Int32);
                p_telefono.Direction = ParameterDirection.Input;
                p_telefono.Value = txtTelefono.Text;

                OracleParameter p_correo = new OracleParameter("p_correo", OracleDbType.Varchar2);
                p_correo.Direction = ParameterDirection.Input;
                p_correo.Value = txtCorreo.Text;

                OracleParameter p_direccion = new OracleParameter("p_direccion", OracleDbType.Varchar2);
                p_direccion.Direction = ParameterDirection.Input;
                p_direccion.Value = txtDireccion.Text;

                OracleParameter p_id_nacionalidad = new OracleParameter("p_id_nacionalidad", OracleDbType.Int32);
                p_id_nacionalidad.Direction = ParameterDirection.Input;
                p_id_nacionalidad.Value = cbNacionalidad.ItemsSource;

                OracleParameter p_id_civil = new OracleParameter("p_id_civil", OracleDbType.Int32);
                p_id_civil.Direction = ParameterDirection.Input;
                p_id_civil.Value = cbEstadoCivil.ItemsSource;

                //HACER UN IF, pasar boolean a int
                String Pert_Pueblo = "";

                if (chbPueblo.IsChecked == true)
                {
                   Pert_Pueblo = "S";
                }
                else
                {
                    Pert_Pueblo = "N";
                }
                OracleParameter p_pueblo = new OracleParameter("p_pueblo", OracleDbType.Varchar2);
                p_pueblo.Direction = ParameterDirection.Input;
                p_pueblo.Value = Pert_Pueblo;

                OracleParameter p_nombre_titulo = new OracleParameter("p_nombre_titulo", OracleDbType.Varchar2);
                p_nombre_titulo.Direction = ParameterDirection.Input;
                p_nombre_titulo.Value = txtTitulo.Text;

                OracleParameter p_monto_ahorro = new OracleParameter("p_monto_ahorro", OracleDbType.Varchar2);
                p_monto_ahorro.Direction = ParameterDirection.Input;
                p_monto_ahorro.Value = txtMontoAhorro.Text;

                OracleParameter p_id_genero = new OracleParameter("p_id_genero", OracleDbType.Int32);
                p_id_genero.Direction = ParameterDirection.Input;
                p_id_genero.Value = cbGenero.ItemsSource;

                OracleParameter p_region = new OracleParameter("p_region", OracleDbType.Int32);
                p_region.Direction = ParameterDirection.Input;
                p_region.Value = cbRegion.ItemsSource;

                OracleParameter p_id_indigena = new OracleParameter("p_id_indigena", OracleDbType.Int32);
                p_id_indigena.Direction = ParameterDirection.Input;
                p_id_indigena.Value = cbIndigena.ItemsSource;
                
                OracleParameter copia_cursor = cmd.Parameters.Add("L_TODO", OracleDbType.RefCursor); // es igual a %rowtype
                copia_cursor.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(p_rut_postulante); //añade la variable de entrada
                cmd.Parameters.Add(p_nombre);
                cmd.Parameters.Add(p_apellidos);
                cmd.Parameters.Add(p_fecha_nac);
                cmd.Parameters.Add(p_telefono);
                cmd.Parameters.Add(p_correo);
                cmd.Parameters.Add(p_direccion);
                cmd.Parameters.Add(p_id_nacionalidad);
                cmd.Parameters.Add(p_id_civil);
                cmd.Parameters.Add(p_pueblo);
                cmd.Parameters.Add(p_nombre_titulo);
                cmd.Parameters.Add(p_monto_ahorro);
                cmd.Parameters.Add(p_id_genero);
                cmd.Parameters.Add(p_region);
                cmd.Parameters.Add(p_id_indigena);

                cmd.ExecuteNonQuery();

               
                bool resp = false; //postulante.Grabar();
                await this.ShowMessageAsync("Mensaje:",
                      string.Format(resp ? "Postulación Guardada" : "No se guardo la Postulación"));

                btnDetalle.Visibility = Visibility.Visible;
                gPuntaje.Visibility = Visibility.Visible;
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
            DetallePuntaje detalle = new DetallePuntaje(this);
            detalle.Show();
        }

        private void btnVolverP_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }


    }

}

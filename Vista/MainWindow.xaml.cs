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

using Oracle.ManagedDataAccess.Client;  //referencia a oracle, un cliente
using Oracle.ManagedDataAccess.Types; //referencia a oracle: tipos de dato de oracle
using System.Data;
using System.Configuration; //cualquier configuracion de visual studio a oracle, sale de esta libreria
using CapaAccesoDatos; 

namespace Vista
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OracleConnection conn = null;
        public MainWindow()
        {
            //se abre la conexion antes de hacer cualquier cosa
            abrirConexion();
            InitializeComponent();
        }

        private void abrirConexion()
        {
            //el string de conexion por donde abriré la BD
            string connectionString = ConfigurationManager.ConnectionStrings["oracleBD"].ConnectionString; //lo parseo

            //abrir conexion BD
            conn = new OracleConnection(connectionString);
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("hola, soy un error de conexion");
                throw new Exception("horrro");
            }
        }

        private void gvListado_Loaded(object sender, RoutedEventArgs e)
        {
            cargarGrilla(); //metodo donde llamamos el cursor
        }

        private void cargarGrilla()
        { 
            try
            {
                //1)
                //si me conecto correctamente a oracle, podré usar la función que creé
                OracleCommand cmd = new OracleCommand("fn_listar", conn);

                //2)
                //establecer qué tipo de dato es el cmd (fn_listar) con el StoredProcedure
                //ya que c# no distingue entre funcion y procedimiento, son lo mismo para él
                cmd.CommandType = CommandType.StoredProcedure;

                //3)
                List<Postulante> lista = new List<Postulante>();

                //4)
                // creamos una copia del cursor que se creó en Oracle desde la funcion que rescatamos (cmd)
                // l_cursor es de tipo RefCursor
                OracleParameter copia_cursor = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor); // es igual a %rowtype

                //5)
                //recibe la informacion del cursor (a traves de una direccion), cómo lo sabe? colocando que es de tipo ReturnValue
                copia_cursor.Direction = ParameterDirection.ReturnValue;

                //6)
                //ejecutar la funcion - cargar la variable "copia_cursor" con los datos
                cmd.ExecuteNonQuery();

                //7)
                //leemos la informacion que está guardada adentro del cursor que creamos y llenamos de info
                OracleDataReader info_leida = ((OracleRefCursor)copia_cursor.Value).GetDataReader(); //lo parseamos a cursor, por los distintos tipo de datos que contiene

                //8)
                //extraemos la informacion del cursor que creamos
                while (info_leida.Read())
                {
                    //rescatamos
                    Postulante pos = new Postulante();
                    pos.Rut = info_leida.GetString(0);
                    pos.Nombre = info_leida.GetString(1);
                    pos.ApPaterno = info_leida.GetString(2);
                    pos.ApMaterno = info_leida.GetString(3);
                    pos.FechaNacimiento = info_leida.GetDateTime(4).ToString("dd-MM-yyyy");
                    pos.Telefono = info_leida.GetInt32(5);
                    pos.Mail = info_leida.GetString(6);

                    //agregamos a la lista
                    lista.Add(pos);
                }

                //9)
                //cargamos la grilla con los datos de la lista
                gvListado.ItemsSource = lista;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //se cerrará la conexion con la BD cuando se cierre esta ventana
        private void Window_Closed(object sender, EventArgs e)
        {
            conn.Close();
        }
    }
}

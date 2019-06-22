using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;  //referencia a oracle, un cliente
using Oracle.ManagedDataAccess.Types; //referencia a oracle: tipos de dato de oracle
using System.Data;
using System.Configuration; //cualquier configuracion de visual studio a oracle, sale de esta libreria


namespace Conexion
{
    public class ConexionOracle
    {
        public OracleConnection Conn { get; set; }
        public OracleConnection abrirConexion()
        {
            //el string de conexion por donde abriré la BD
            string connectionString = ConfigurationManager.ConnectionStrings["oracleBD"].ConnectionString; //lo parseo

            //abrir conexion BD
            Conn = new OracleConnection(connectionString);
            try
            {
                Conn.Open();
            }
            catch (Exception ex)
            {
               
                throw new Exception("horrro");
            }
            return Conn;
        }
    }
}

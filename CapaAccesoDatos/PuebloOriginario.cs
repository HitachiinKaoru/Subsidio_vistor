using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Oracle.ManagedDataAccess.Client;  //referencia a oracle, un cliente
using Oracle.ManagedDataAccess.Types; //referencia a oracle: tipos de dato de oracle
using System.Data;
using System.Configuration; //cualquier configuracion de visual studio a oracle, sale de esta libreria
using Conexion;

namespace CapaAccesoDatos
{
    public class PuebloOriginario
    {
        private ConexionOracle Oracle { get; set; }
        private OracleConnection Cone { get; set; }
        public int Id_pueblo { get; set; }
        public String Descripcion { get; set; }

        public PuebloOriginario()
        {
            Oracle = new ConexionOracle();
        }

        public List<PuebloOriginario> ReadAll6()
        {
            try
            {
                Cone = Oracle.abrirConexion();
                OracleCommand cmd = new OracleCommand("FN_LPUEBLO", Cone);
                cmd.CommandType = CommandType.StoredProcedure;

                List<PuebloOriginario> pueblos = new List<PuebloOriginario>();
                OracleParameter copia_cursor = cmd.Parameters.Add("L_PUEBLO", OracleDbType.RefCursor); // es igual a %rowtype
                copia_cursor.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader info_leida = ((OracleRefCursor)copia_cursor.Value).GetDataReader(); //lo parseamos a cursor, por los distintos tipo de datos que contiene
                while (info_leida.Read())
                {
                    //rescatamos
                    PuebloOriginario pos = new PuebloOriginario();
                    pos.Id_pueblo = info_leida.GetInt32(0);
                    pos.Descripcion = info_leida.GetString(1);


                    //agregamos a la lista
                    pueblos.Add(pos);
                }

                return pueblos;

            }
            catch (Exception ex)
            {
                return null;
            }

        }
    }
}

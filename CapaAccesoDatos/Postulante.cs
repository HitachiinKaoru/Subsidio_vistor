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
    public class Postulante
    {
        private ConexionOracle Oracle { get; set; }
        private OracleConnection Cone { get; set; }

        private String _rut;
        private String _nombre;
        private int _edad;
        private int _puntjEdad;
        private int _cantCargas;
        private int _puntjCargas;
        private String _estadoCivil;
        private int _puntjCivil;
        private String _puebloIndigena;
        private int _puntjIndigena;
        private String _montoAhorrado;
        private int _puntjAhorro;
        private String _titulo;
        private int _puntjTitulo;
        private String _region;
        private int _puntjRegion;
        private String _tipoVivienda;
        private String _valorVivienda;
        private int _puntjTotal;
       

        public string Rut
        {
            get
            {
                return _rut;
            }

            set
            {
                _rut = value;
            }
        }

        public string Nombre
        {
            get
            {
                return _nombre;
            }

            set
            {
                _nombre = value;
            }
        }

        public int Edad
        {
            get
            {
                return _edad;
            }

            set
            {
                _edad = value;
            }
        }

        public int PuntjEdad
        {
            get
            {
                return _puntjEdad;
            }

            set
            {
                _puntjEdad = value;
            }
        }

        public int CantCargas
        {
            get
            {
                return _cantCargas;
            }

            set
            {
                _cantCargas = value;
            }
        }

        public int PuntjCargas
        {
            get
            {
                return _puntjCargas;
            }

            set
            {
                _puntjCargas = value;
            }
        }

        public string EstadoCivil
        {
            get
            {
                return _estadoCivil;
            }

            set
            {
                _estadoCivil = value;
            }
        }

        public int PuntjCivil
        {
            get
            {
                return _puntjCivil;
            }

            set
            {
                _puntjCivil = value;
            }
        }

        public string PuebloIndigena
        {
            get
            {
                return _puebloIndigena;
            }

            set
            {
                _puebloIndigena = value;
            }
        }
        public int PuntjIndigena
        {
            get
            {
                return _puntjIndigena;
            }

            set
            {
                _puntjIndigena = value;
            }
        }
        public string MontoAhorrado
        {
            get
            {
                return _montoAhorrado;
            }

            set
            {
                _montoAhorrado = value;
            }
        }

        public int PuntjAhorro
        {
            get
            {
                return _puntjAhorro;
            }

            set
            {
                _puntjAhorro = value;
            }
        }

        public string Titulo
        {
            get
            {
                return _titulo;
            }

            set
            {
                _titulo = value;
            }
        }

        public int PuntjTitulo
        {
            get
            {
                return _puntjTitulo;
            }

            set
            {
                _puntjTitulo = value;
            }
        }

        public string Region
        {
            get
            {
                return _region;
            }

            set
            {
                _region = value;
            }
        }

        public int PuntjRegion
        {
            get
            {
                return _puntjRegion;
            }

            set
            {
                _puntjRegion = value;
            }
        }

        public string TipoVivienda
        {
            get
            {
                return _tipoVivienda;
            }

            set
            {
                _tipoVivienda = value;
            }
        }

        public string ValorVivienda
        {
            get
            {
                return _valorVivienda;
            }

            set
            {
                _valorVivienda = value;
            }
        }

        public int PuntjTotal
        {
            get
            {
                return _puntjTotal;
            }

            set
            {
                _puntjTotal = value;
            }
        }

       

        public Postulante()
        {
            Oracle = new ConexionOracle();
        }


        //METODOS

        //Listado de beneficiados
        public List<Postulante> ReadAll()
        {
            try
            {
                Cone = Oracle.abrirConexion();
                //1)
                //si me conecto correctamente a oracle, podré usar la función que creé
                OracleCommand cmd = new OracleCommand("FN_LISTAR_BENEFICIADOS", Cone);

                //2)
                //establecer qué tipo de dato es el cmd (fn_listar) con el StoredProcedure
                //ya que c# no distingue entre funcion y procedimiento, son lo mismo para él
                cmd.CommandType = CommandType.StoredProcedure;

                //3)
                List<Postulante> listaBeneficiados = new List<Postulante>();

                //4)
                // creamos una copia del cursor que se creó en Oracle desde la funcion que rescatamos (cmd)
                // l_cursor es de tipo RefCursor
                OracleParameter copia_cursor = cmd.Parameters.Add("L_TODO", OracleDbType.RefCursor); // es igual a %rowtype

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

                //9)
                //cargamos la grilla con los datos de la lista
               return listaBeneficiados;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaAccesoDatos
{
    public class Postulante
    {
        private String _rut;
        private String _nombre;
        private String _apPaterno;
        private String _apMaterno;
        
        private int _telefono;
        private String _mail;


        public String Rut
        {
            get { return _rut; }
            set
            {
                if (value != null && value.Length >= 9 && value.Length <= 13)
                {
                    _rut = value;
                }
                else
                {
                    throw new ArgumentException("Campo Rut no puede estar Vacío y debe tener un largo de 9 o 10 dígitos");
                }
            }
        }
        public String Nombre
        {
            get { return _nombre; }
            set
            {
                if (value != null)
                {
                    _nombre = value;
                }
                else
                {
                    throw new ArgumentException("Campo Nombre no puede estar Vacío");
                }

            }
        }
        public String ApPaterno
        {
            get { return _apPaterno; }
            set
            {
                if (value != null)
                {
                    _apPaterno = value;
                }
                else
                {
                    throw new ArgumentException("Campo Apellido Paterno no puede estar Vacío");
                }

            }
        }
        public String ApMaterno
        {
            get { return _apMaterno; }
            set
            {
                if (value != null)
                {
                    _apMaterno = value;
                }
                else
                {
                    throw new ArgumentException("Campo Apellido Materno no puede estar Vacío");
                }

            }
        }

        //METODO FECHA NACIMIENTO FALTA
        public String FechaNacimiento { get; set; } ///como se hace?

        public int Telefono
        {
            get { return _telefono; }
            set
            {
                if (value != 0)
                {
                    _telefono = value;
                }
                else
                {
                    throw new ArgumentException("Campo Teléfono no puede estar Vacío");
                }

            }
        }
        public String Mail
        {
            get { return _mail; }
            set
            {
                if (value != null)
                {
                    _mail = value;
                }
                else
                {
                    throw new ArgumentException("Campo Email no puede estar Vacío");
                }
            }
        }


        public Postulante()
        {

        }

        //public Postulante(string rut, string nombre, string apPaterno, string apMaterno, DateTime fechaNacimiento,
        //    string mail, int telefono)
        //{
        //    Rut = rut;
        //    Nombre = nombre;
        //    Mail = mail;
        //    Telefono = telefono;
        //    ApPaterno = apPaterno;
        //    ApMaterno = apMaterno;
        //    FechaNacimiento = fechaNacimiento;
        //}


    }
}


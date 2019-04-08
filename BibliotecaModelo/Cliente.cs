using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaModelo
{
    public class Cliente
    {
        public String Rut { get; set; }
        public String Razon { get; set; }
        public String Direccion { get; set; }
        private int _telefono;

        public int Telefono
        {
            get { return _telefono; }
            set
            {
                String fono = "" + value;
                if (fono.Length == 8)
                {
                    _telefono = value;
                }
                else
                {
                    throw new ArgumentException("el numero debe ser de 8 digitos");
                }

            }
        }

        public String Actividad { get; set; }
        public String Tipo { get; set; }


        public Cliente(String rut, String razon, String direccion, int telefono, String actividad, String tipo)
        {
            Rut = rut;
            Razon = razon;
            Direccion = direccion;
            Telefono = telefono;
            Actividad = actividad;
            Tipo = tipo;
        }

    }
}

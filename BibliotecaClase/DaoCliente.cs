using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BibliotecaModelo;

namespace BibliotecaControlador
{
    public class DaoCliente
    {
        private static List<Cliente> clientes;


        public DaoCliente()
        {
            if (clientes == null)
            {
                clientes = new List<Cliente>();

            }

        }


        public bool Agregar(Cliente cli)
        {
            try
            {
                if (ExisteCliente(cli.Rut) == false)
                {
                    clientes.Add(cli);
                    return true;

                }
                return false;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al grabar");
            }
        }
        private bool ExisteCliente(String rut)
        {
            foreach (Cliente item in clientes)
            {
                if (item.Rut.Equals(rut))
                {
                    return true;

                }

            }
            return false;
        }

        public Cliente Buscar(String rut)
        {
            try
            {
                foreach (Cliente item in clientes)
                {
                    if (item.Rut.Equals(rut))
                    {
                        return item;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new ArgumentException("cliente no existe");
            }
        }


        public bool Eliminar(String rut)
        {
            try
            {
                foreach (Cliente item in clientes)
                {
                    if (item.Rut.Equals(rut))
                    {
                        clientes.Remove(item);
                        return true;
                    }

                }
                return false;

            }
            catch (Exception ex)
            {
                throw new ArgumentException("rut no existe");
            }

        }

        public bool Actualizar(Cliente cli)
        {
            try
            {
                foreach (Cliente item in clientes)
                {
                    if (cli.Rut.Equals(item.Rut))
                    {
                        clientes.Remove(item);
                        clientes.Add(cli);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("No se puede modificar");
            }
        }
    }
}

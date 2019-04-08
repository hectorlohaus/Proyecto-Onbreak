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
using BibliotecaModelo;
using BibliotecaControlador;

namespace Vista___OnBreak
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        public Registro()
        {
            InitializeComponent();

            cboActividad.Items.Add("Agropecuario");
            cboActividad.Items.Add("Minería");
            cboActividad.Items.Add("Manufactura");
            cboActividad.Items.Add("Comercio");
            cboActividad.Items.Add("Hoteleria");
            cboActividad.Items.Add("Alimentos");
            cboActividad.Items.Add("Transporte");
            cboActividad.Items.Add("Servicios");

            cboActividad.SelectedIndex = 0;

            cboTipo.Items.Add("SPA");
            cboTipo.Items.Add("EIRL");
            cboTipo.Items.Add("LTDA");
            cboTipo.Items.Add("Sociedad Anonima");
            cboTipo.SelectedIndex = 0;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DaoCliente dao = new DaoCliente();
                if (dao.Buscar(txtRut.Text)!=null)
                {
                    MessageBox.Show("Lo encontró");
                    Cliente cli = dao.Buscar(txtRut.Text);
                }
                else
                {
                    MessageBox.Show("No lo encontró");
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("error");
                throw;
            }
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                String rut = txtRut.Text;
                String dire = txtDireccion.Text;
                String razo = txtRazon.Text;
                int fono = int.Parse( txtTelefono.Text);
                String tipo = cboTipo.SelectedItem.ToString();
                String acti = cboActividad.SelectedItem.ToString();

                Cliente cli = new Cliente(rut, razo, dire, fono, acti, tipo);
                DaoCliente dao = new DaoCliente();
                bool resp = dao.Agregar(cli);
                MessageBox.Show(resp ? "Grabo" : "No Grabo");
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DaoCliente dao = new DaoCliente();
                bool resp = dao.Eliminar(txtRut.Text);
                MessageBox.Show(resp ? "Elimino" : "No elimino");
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}

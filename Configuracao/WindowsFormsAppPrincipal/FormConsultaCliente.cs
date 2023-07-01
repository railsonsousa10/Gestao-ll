using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace WindowsFormsAppPrincipal
{
    public partial class FormConsultaCliente : Form
    {
        public FormConsultaCliente()
        {
            InitializeComponent();
        }

       
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void FormConsultaCliente_Load(object sender, EventArgs e)
        {
            comboBoxBuscarPor.SelectedIndex = 3;
        }

        private void Alterar_Click(object sender, EventArgs e)
        {
            try
            {
                if(clienteBindingSource.Count == 0)
                {
                    MessageBox.Show("Não exixte cliente para ser alterado");
                    return;
                }
                int id = ((Cliente)clienteBindingSource.Current).Id;

                using (FormCadastroCliente frm = new FormCadastroCliente(id))
                {
                    frm.ShowDialog();   
                }
                button4Buscar_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4Buscar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (comboBoxBuscarPor.SelectedIndex)
                {
                    case 0:
                        if (String.IsNullOrEmpty(textBoxBuscar.Text))
                            throw new Exception("Informe um ID para fazer a buscar") { Data = { { "Id",31} } };

                        clienteBindingSource.DataSource = new ClienteBLL().BuscarPorId(Convert.ToInt32(textBoxBuscar.Text));
                        break;
                        case 1:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarPorNome(textBoxBuscar.Text);
                        break;
                    case 2:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarPorCPF(textBoxBuscar.Text);
                        break;
                    case 3:
                        clienteBindingSource.DataSource = new ClienteBLL().BuscarTodos();
                        break;
                    default:
                        break;
                }
                clienteBindingSource.DataSource = new ClienteBLL().BuscarPorNome(textBoxBuscar.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void buttonSelecionar_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

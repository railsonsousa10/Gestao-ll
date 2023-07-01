﻿using BLL;
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


namespace WindowsFormsAppPrincipal
{
    public partial class FormCadastroCliente : Form
    {
        
        int id;
        public FormCadastroCliente(int _id = 0)
        {
            InitializeComponent();
            id = _id;
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cliente = (Cliente)clienteBindingSource.Current;

                clienteBindingSource.EndEdit();

                if (id == 0)
                    new ClienteBLL().Inserir(cliente);
                else
                    new ClienteBLL().Alterar(cliente);

                MessageBox.Show("Registro salvo com sucesso!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void buttonExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (clienteBindingSource.Count <= 0)
                {
                    MessageBox.Show("Nõa exixte registro para ser excluido! ");
                    return;
                }
                int id = ((Cliente)clienteBindingSource.Current).Id;
                new ClienteBLL().Excluir(id);
                clienteBindingSource.RemoveCurrent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FormCadatroCliente_Load(object sender, EventArgs e)
        {
            try
            {
                if (id == 0)
                    clienteBindingSource.AddNew();
                else
                    clienteBindingSource.DataSource = new ClienteBLL().BuscarPorId(id);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

    }
}

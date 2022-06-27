﻿using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using FluentValidation.Results;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using ValidationResult = FluentValidation.Results.ValidationResult;
using LocadoraVeiculos.BancoDados.ModuloCliente;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public partial class TelaCadastroClienteForm : Form
    {

        Cliente cliente;
        RepositorioClienteEmBancoDados repositorio;
        public TelaCadastroClienteForm()
        {
            InitializeComponent();
            repositorio = new RepositorioClienteEmBancoDados();
        }

        public Func<Cliente, ValidationResult> GravarRegistro { get; set; }


        public Cliente Cliente
        {
            get
            {
                return cliente;
            }
            set
            {
                cliente = value;
                txtNome.Text = cliente.Nome;
                txtEmail.Text = cliente.Email;
                txtTelefone.Text = cliente.Telefone;
                txtCpf.Text = cliente.CPF;
                txtEndereco.Text = cliente.Endereco;
                txtNumeroCnh.Text = cliente.CnhNumero.ToString();
                txtNomeCnh.Text = cliente.CnhNome;
                monthCalendarVencimento.SelectionStart = cliente.CnhVencimento;

            }
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {

            cliente.Nome = txtNome.Text;
            cliente.Email = txtEmail.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.CPF = txtCpf.Text;
            cliente.CnhNumero = Convert.ToInt32(txtNumeroCnh.Text);
            cliente.CnhNome = txtNomeCnh.Text;
            cliente.CnhVencimento = monthCalendarVencimento.SelectionStart;

            if (!repositorio.VerificarSeExiste(cliente))
            {

                MessageBox.Show("Cliente ou dados já inseridos",
               "Cadastro de clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;

            }

            var resultadoValidacao = GravarRegistro(cliente);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroClientesForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroClientesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

    }
}

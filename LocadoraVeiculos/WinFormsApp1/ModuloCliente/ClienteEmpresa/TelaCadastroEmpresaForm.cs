﻿using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa
{
    public partial class TelaCadastroEmpresaForm : Form
    {

        Empresa empresa;


        public TelaCadastroEmpresaForm()
        {
            InitializeComponent();
        }

        public Func<Empresa, ValidationResult> GravarRegistro { get; set; }

        public Empresa Empresa
        {
            get
            {
                return empresa;
            }
            set
            {
                empresa = value;
                txtNomeEmpresa.Text = empresa.Nome;
                txtEmailEmpresa.Text = empresa.Email;
                txtTelefoneEmpresa.Text = empresa.Telefone;
                txtCnpjEmpresa.Text = empresa.CNPJ;
                txtEnderecoEmpresa.Text = empresa.Endereco;

            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            empresa.Nome = txtNomeEmpresa.Text;
            empresa.Email = txtEmailEmpresa.Text;
            empresa.Telefone = txtTelefoneEmpresa.Text;
            empresa.Endereco = txtEnderecoEmpresa.Text;
            empresa.CNPJ = txtCnpjEmpresa.Text;

            var resultadoValidacao = GravarRegistro(empresa);

            if (resultadoValidacao.IsValid == false)
            {
                string erro = resultadoValidacao.Errors[0].ErrorMessage;

                TelaMenuPrincipalForm.Instancia.AtualizarRodape(erro);

                DialogResult = DialogResult.None;
            }
        }

        private void TelaCadastroEmpresasForm_Load(object sender, EventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

        private void TelaCadastroEmpresasForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            TelaMenuPrincipalForm.Instancia.AtualizarRodape("");
        }

    }
}

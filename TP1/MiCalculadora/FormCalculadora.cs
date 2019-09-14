using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void BtnToDecimal_Click(object sender, EventArgs e)
        {
            if (this.lblView.Text != "" && this.lblView.Text != "Valor Invalido")
            {
                this.lblView.Text = Numero.BinarioDecimal(this.lblView.Text);
                this.btnToDecimal.Enabled = false;
                this.btnToBinario.Enabled = true;
            }
            

        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            this.lblView.Text = Operar(this.txtNum1.Text, this.txtNum2.Text, this.comboOperator.Text).ToString();
            if(this.lblView.Text!="0")
            {
                this.btnToBinario.Enabled = true;
                this.btnToDecimal.Enabled = true;
            }
            
        }

        private void BtnToBinario_Click(object sender, EventArgs e)
        {
            if (this.lblView.Text != "" && this.lblView.Text != "Valor Invalido")
            {
                this.lblView.Text = Numero.DecimalBinario(this.lblView.Text);
                this.btnToBinario.Enabled = false;
                this.btnToDecimal.Enabled = true;
            }
        }

        private static double Operar(string numero1,string numero2,string operador)
        {
            return Calculadora.Operar(new Numero(numero1), new Numero(numero2), operador);
        }

        private void Limpiar()
        {
            this.txtNum1.Text = "";
            this.txtNum2.Text = "";
            this.comboOperator.Text = "+";
            this.lblView.Text = "";
            this.btnToBinario.Enabled = false;
            this.btnToDecimal.Enabled = false;
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.btnToBinario.Enabled = false;
            this.btnToDecimal.Enabled = false;
        }
    }
}

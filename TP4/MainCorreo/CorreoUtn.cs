using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainCorreo
{
    public partial class CorreoUtn : Form
    {
        public Correo correo { get; set; }

        public CorreoUtn()
        {
            InitializeComponent();
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {

        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {

        }

        private void paq_InformaEstado(object sender,EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            { 
                // Llamar al método }
            }
        }

        private void CorreoUtn_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }
    }
}

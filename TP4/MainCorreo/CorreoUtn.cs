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
            correo = new Correo();
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDireccion.Text) && !string.IsNullOrEmpty(maskedTextBox1.Text))
            {
                Paquete paquete = new Paquete(txtDireccion.Text, maskedTextBox1.Text);
                try
                {
                    paquete.InformaEstado += paq_InformaEstado;
                    correo += paquete;
                    ActualizarEstados();
                }
                catch (Exception ex)
                {
                    ex = new Exception("Error al agregar paquete");
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        private void BtnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)listBoxEntregado.SelectedItem);
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
                ActualizarEstados();
            }
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null && (elemento is Paquete || elemento is Correo))
            {
                richTextBox.Text = elemento.MostrarDatos(elemento);
                GuardaString.Guardar(elemento.MostrarDatos(elemento), "salida.txt");                       
            }
        }

        private void ActualizarEstados()
        {
            listBoxIngresado.Items.Clear();
            listBoxEnViaje.Items.Clear();
            listBoxEntregado.Items.Clear();

            foreach (Paquete paquete in correo.Paquetes)
            {
                switch (paquete.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        listBoxIngresado.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.EnViaje:
                        listBoxEnViaje.Items.Add(paquete);
                        break;
                    case Paquete.EEstado.Entregado:
                        listBoxEntregado.Items.Add(paquete);
                        break;
                    default:
                        break;
                }
            }
        }

        private void CorreoUtn_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        
    }
}

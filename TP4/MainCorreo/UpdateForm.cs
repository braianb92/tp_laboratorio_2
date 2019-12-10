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
    public partial class UpdateForm : Form
    {
        private Paquete paquete;

        public UpdateForm(Paquete paqueteToUpdate)
        {
            InitializeComponent();
            this.paquete = paqueteToUpdate;
        }

        private void update_Load(object sender, EventArgs e)
        {
            lblPaquete.Text = "Paquete " + this.paquete.TrackingID;
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtNuevaDir.Text))
            {
               if( PaqueteDAO.Modificar(this.paquete, txtNuevaDir.Text))
                    MessageBox.Show("Se modifico la direccion!");

            }
            else
            {
                MessageBox.Show("Dato no valido.");
            }
            this.Close();
        }
    }
}

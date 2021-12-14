using System;
using System.Windows.Forms;
using Negocio;

namespace maquinariasGAQ
{
    public partial class Acceso : Form
    {
        public Acceso()
        {
            InitializeComponent();
        }

        private void Acceso_Load(object sender, EventArgs e)
        {
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            Validacion val = new Validacion();
            string rut = txtUsuario.Text;
            string clave = txtClave.Text;
       
            try
            {
                if (rut != "" && clave != "")
                {
                     bool response = val.ValidaUsuario(rut, clave);
                     if (response)
                     {
                        val.Reinicio();
                        Sistema mv = new Sistema();
                        mv.ShowDialog();
                     }
                } 
                else
                {
                    LimpiarForm();
                    throw new Exception("Debe ingresar Usuario y Clave");
                }
            }
            catch (Exception err)
            {
                LimpiarForm();
                MessageBox.Show(err.Message);
            }
        }

        private void LimpiarForm()
        {
            // Limpiar formulario
            txtClave.Clear();
            txtUsuario.Clear();
            txtUsuario.Focus();
        }
    }
}

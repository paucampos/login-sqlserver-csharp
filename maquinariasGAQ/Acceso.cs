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
                     bool response = val.validaUsuario(rut, clave);
                     if (response)
                     {
                        val.Reinicio();
                        Sistema mv = new Sistema();
                        mv.ShowDialog();
                     } 
                } 
                else
                {
                    throw new Exception("Debe ingresar Usuario y Clave");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}

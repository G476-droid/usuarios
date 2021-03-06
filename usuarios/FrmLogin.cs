using AccesoDatos.ClassLibrary;
using Logica.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace usuarios
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            login();
        }

        private void login()
        {
            try
            {
                string correo = txtCorreo.Text.TrimStart().TrimEnd();
                string clave = txtClave.Text;

                //string ecriptar = logica.encriptar(clave);

                if (!string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(clave))
                {
                    Usuario usuario = new Usuario();
                    usuario = LogicaUsuario.getUserXLogin(correo, Logica.ClassLibrary.Utilidades.Encriptar.GetMD5(clave));
                    if (usuario != null)
                    {
                        var dataUser = usuario.usu_nombres + " " + usuario.usu_apellidos;
                        //Interpolation
                        var dataUser2 = $"{ usuario.usu_nombres}  { usuario.usu_apellidos}";

                        MessageBox.Show("Bienvenido al sistema\n Rol:" + usuario.Rol.rol_descripcion
                        + "\nUsuario: " + dataUser2, "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //Form1 form1 = new Form1();
                        //form1.Show();


                        Formularios.FrmPrincipal frmPrincipal = new Formularios.FrmPrincipal();
                        frmPrincipal.Show();

                       // this.Hide();


                    }
                    else
                    {

                        MessageBox.Show("Error en usuario o clave", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                //else
                //{
                   // MessageBox.Show("Error en usuario o clave", "Sistema de Matriculación Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
               // }
            }
            catch (Exception)
            {

                throw;
            }


        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

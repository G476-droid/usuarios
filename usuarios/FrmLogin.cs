﻿using AccesoDatos.ClassLibrary;
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

                if (string.IsNullOrEmpty(correo) && !string.IsNullOrEmpty(clave))
                {
                    Usuario usuario = new Usuario();
                    usuario = Logica.ClassLibrary.LogicaUsuario.getUserXLogin(correo, clave);

                    if (usuario != null)
                    {
                        var dataUser = usuario.usu_correo + " " + usuario.usu_apellidos;
                        //interpolation
                        var dataUser2 = $"{usuario.usu_correo} {usuario.usu_apellidos}";

                        MessageBox.Show("Bienvenido al Sistema\n Rol:  "
                            +usuario.Rol.rol_descripcion
                            + "\n Usuario: ", "Sistema de Matriculacion Vehicular"
                            , MessageBoxButtons.OK
                            , MessageBoxIcon.Information);
                        Form1 form1 = new Form1();
                        form1.Show();
                        this.Hide();
                        
                    }

                }
                else
                {
                    MessageBox.Show("Error en usuario o clave", "Sistema de Matriculacion Vehicular", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

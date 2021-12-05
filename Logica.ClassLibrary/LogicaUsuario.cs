using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AccesoDatos;
using AccesoDatos.ClassLibrary;

namespace Logica.ClassLibrary
{
    public class LogicaUsuario
    {
        private static DcMatriculaDataContext dc = new DcMatriculaDataContext();
        public static List<Usuario> getAllaUsers()
        {
            try
            {
                var lista = dc.Usuario.Where(data => data.usu_status == 'A');
                return lista.ToList();
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario" + ex.Message);
            }


        }
        public static Usuario getAllaUsersXid(int idUsuario)
        {
            try
            {
                var usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                && data.usu_id.Equals(idUsuario)).FirstOrDefault();
                return usuario;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario" + ex.Message);
            }


        }
        public static Usuario getUserXLogin(string email, string clave)
        {
            try
            {
                var usuario = dc.Usuario.Where(data => data.usu_status == 'A'
                && data.usu_correo.Equals(email)
                && data.usu_password.Equals(clave)
                ).FirstOrDefault();

                return usuario;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al obtener usuario" + ex.Message);
            }


        }
        public static bool saveUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;
                dataUsuario.usu_add = DateTime.Now;
                dataUsuario.usu_status = 'A';


                dc.Usuario.InsertOnSubmit(dataUsuario);
                //commit a la base
                dc.SubmitChanges();

                result = true;

                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al guardar" + ex.Message);
            }


        }
        public static bool updateUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;
                dc.Usuario.InsertOnSubmit(dataUsuario);
                //commit a la base
                dc.SubmitChanges();

                result = true;

                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al modificar" + ex.Message);
            }


        }
        public static bool detleteUser(Usuario dataUsuario)
        {
            try
            {
                bool result = false;
                dataUsuario.usu_status = 'I';
                //commit a la base
                dc.SubmitChanges();


                result = true;

                return result;
            }
            catch (Exception ex)
            {

                throw new ArgumentException("Error al eliminar" + ex.Message);
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinal
{
    internal class UsuarioHandler : DbHandler
    {
        List<Usuario> listaUsuarios = new List<Usuario>();

        public List<Usuario> TraerUsuarios()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    cn.Open();
                    String listaUsuariosQuery = "SELECT * FROM USUARIO";
                    using (SqlCommand cmd = new SqlCommand(listaUsuariosQuery, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                while(reader.Read())
                                {
                                    Usuario usuario = new Usuario();

                                    usuario._id            = Convert.ToInt32(reader["ID"]);
                                    usuario._nombre        = Convert.ToString(reader["NOMBRE"]);
                                    usuario._apellido      = Convert.ToString(reader["APELLIDO"]);
                                    usuario._nombreUsuario = Convert.ToString(reader["NOMBREUSUARIO"]);
                                    usuario._contraseña    = Convert.ToString(reader["CONTRASEÑA"]);
                                    usuario._mail          = Convert.ToString(reader["MAIL"]);

                                    listaUsuarios.Add(usuario);
                                }
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex);
            }
            return listaUsuarios;
        }
    }
}

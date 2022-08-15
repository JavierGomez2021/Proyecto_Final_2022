using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class InicioHandler : DbHandler
    {
        public bool IniciarSesion(string usuario, string contraseña)
        {
            bool UsuarioValido = false;

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    cn.Open();
                    string usuarioValidoQuery = "SELECT * FROM USUARIO WHERE NOMBREUSUARIO = @NOMBREUSUARIO AND CONTRASEÑA = @CONTRASEÑA";

                    SqlParameter parametroNomUsuario = new SqlParameter();

                    parametroNomUsuario.ParameterName = "NOMBREUSUARIO";
                    parametroNomUsuario.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroNomUsuario.Value = usuario;

                    SqlParameter parametroContraseña = new SqlParameter();

                    parametroContraseña.ParameterName = "CONTRASEÑA";
                    parametroContraseña.SqlDbType = System.Data.SqlDbType.VarChar;
                    parametroContraseña.Value = contraseña;

                    using (SqlCommand cmd = new SqlCommand(usuarioValidoQuery, cn))
                    {
                        cmd.Parameters.Add(parametroNomUsuario);
                        cmd.Parameters.Add(parametroContraseña);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                UsuarioValido = true;
                            }
                            else
                            {
                                UsuarioValido = false;
                            }
                        }
                    }
                    cn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR:" + ex);
            }

            return UsuarioValido;
        }
    }
}

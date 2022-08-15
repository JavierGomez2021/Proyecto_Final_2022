using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductoHandler :DbHandler
    {
        public List<Producto> listaProductos = new List<Producto>();
        public List<Producto> TraerProductos()        {

            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    cn.Open();
                    String traerProductosQuery = "SELECT * FROM PRODUCTO";
                    using (SqlCommand cmd = new SqlCommand(traerProductosQuery, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Producto producto = new Producto();

                                    producto._id          = Convert.ToInt32(reader["ID"]);
                                    producto._descripcion = Convert.ToString(reader["DESCRIPCIONES"]);
                                    producto._costo       = Convert.ToDouble(reader["COSTO"]);
                                    producto._precioVenta = Convert.ToDouble(reader["PRECIOVENTA"]);
                                    producto._stock       = Convert.ToInt32(reader["STOCK"]);
                                    producto._idUsuario   = Convert.ToInt32(reader["IDUSUARIO"]);

                                    listaProductos.Add(producto);
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
            return listaProductos;
        }
    }
}

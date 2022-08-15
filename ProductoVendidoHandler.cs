using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class ProductoVendidoHandler : DbHandler
    {
        List<ProductoVendido> listaProdVendidos = new List<ProductoVendido>();

        public List<ProductoVendido> TraerProdVendidos()
        {
            try
            {            
                using (SqlConnection cn = new SqlConnection(ConnectionString))  
                {
                    cn.Open();

                    String listaProdVendidosQuery = "SELECT * FROM PRODUCTOVENDIDO";

                    using (SqlCommand cmd = new SqlCommand(listaProdVendidosQuery, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                while(reader.Read())
                                {
                                    ProductoVendido prodVendido = new ProductoVendido();

                                    prodVendido._id         = Convert.ToInt32(reader["ID"]);
                                    prodVendido._idProducto = Convert.ToInt32(reader["IDPRODUCTO"]);
                                    prodVendido._stock      = Convert.ToInt32(reader["STOCK"]);
                                    prodVendido._idVenta    = Convert.ToInt32(reader["IDVENTA"]);

                                    listaProdVendidos.Add(prodVendido);
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
            return listaProdVendidos;
        }
    }
}

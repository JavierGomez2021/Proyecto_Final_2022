using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ProyectoFinal
{
    public class VentasHandler : DbHandler
    {
        List<Venta> listaVentas = new List<Venta>();

        public List<Venta> TraerVenta()
        {
            try
            {
                using (SqlConnection cn = new SqlConnection(ConnectionString))
                {
                    cn.Open();
                    String listaVentaQuery = "SELECT * FROM VENTA";

                    using (SqlCommand cmd = new SqlCommand(listaVentaQuery, cn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if(reader.HasRows)
                            {
                                while(reader.Read())
                                {
                                    Venta v = new Venta();

                                    v._id          = Convert.ToInt32(reader["ID"]);
                                    v._comentarios = Convert.ToString(reader["COMENTARIOS"]);

                                    listaVentas.Add(v);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex);
            }  
            
            return listaVentas;
        }
    }
}

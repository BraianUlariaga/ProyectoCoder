using ProyectoCoder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.ADO.Net
{
    internal class ManejadorVenta
    {
        public static string connetionString = "Data Source=I5-6400-8GB-WIN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static List<Venta> ObtenerVentas(long idUsuario)
        {
            List<Venta> ventas = new List<Venta>();

            using (SqlConnection conn = new SqlConnection(connetionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Venta WHERE @IdUsuario = idUsuario", conn);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                conn.Open();

                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Venta ventaTemp = new Venta();
                        ventaTemp.Id = reader.GetInt64(0);
                        ventaTemp.Comentarios = reader.GetString(1);
                        ventaTemp.IdUsuario = reader.GetInt64(2);
                        ventas.Add(ventaTemp);
                    }
                }

                return ventas;

            }


        }
    }
}

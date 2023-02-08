using ProyectoCoder.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCoder.ADO.Net
{
    internal class ManejadorUsuario
    {
        public static string connetionString = "Data Source=I5-6400-8GB-WIN;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public static Usuario ObtenerUsuario(long id)
        {

            Usuario usuario = new Usuario();

            using (SqlConnection conn = new SqlConnection(connetionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE @Id=id", conn);
                comando.Parameters.AddWithValue("@id", id);
                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    Usuario usuario1 = new Usuario();
                    usuario.Id = reader.GetInt64(0);
                    usuario.Nombre = reader.GetString(1);
                    usuario.Apellido = reader.GetString(2);
                    usuario.NombreUsuario = reader.GetString(3);
                    usuario.Contraseña = reader.GetString(4);
                    usuario.Mail = reader.GetString(5);

                }
            }

            return usuario;
        }


        public static Usuario ObtenerUsuarioLogin(string usuario, string contraseña)
        {
            Usuario usuarioLogin = new Usuario();

            using (SqlConnection conn = new SqlConnection(connetionString))
            {
                SqlCommand comando = new SqlCommand("SELECT * FROM Usuario WHERE @NombreUsuario = NombreUsuario and @Contraseña = Contraseña", conn);
                comando.Parameters.AddWithValue("@NombreUsuario", usuario);
                comando.Parameters.AddWithValue("@Contraseña", contraseña);

                conn.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();

                    Usuario usuario1 = new Usuario();
                    usuario1.Id = reader.GetInt64(0);
                    usuario1.Nombre = reader.GetString(1);
                    usuario1.Apellido = reader.GetString(2);
                    usuario1.NombreUsuario = reader.GetString(3);
                    usuario1.Contraseña = reader.GetString(4);
                    usuario1.Mail = reader.GetString(5);

                    usuarioLogin = usuario1;
                }
            }

            return usuarioLogin;
        }
    }
}

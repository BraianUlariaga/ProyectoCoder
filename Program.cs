using ProyectoCoder.ADO.Net;
using ProyectoCoder.Models;

namespace ProyectoCoder
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" ** Usuario ** ");
            // Traer Usuario 
            Usuario usuario = ManejadorUsuario.ObtenerUsuario(1);
            Console.WriteLine($"Usuario Id: {usuario.Id}, Usuario: {usuario.Nombre}");

            Console.WriteLine("***");

            // Traer Productos
            List<Producto> productos = ManejadorProducto.ObtenerProductos(1);
            foreach (var item in productos)
            {
                Console.WriteLine($"Productos cargados por el usuario {item.IdUsuario}: {item.Descripciones}");
            }

            Console.WriteLine("***");

            Console.WriteLine(" ** Produtos vendidos ** ");

            // Traer Produtos vendidos
            List<Producto> productosVendidos = ManejadorProducto.ObtenerProductoVendido(1);
            foreach (var item in productosVendidos)
            {
                Console.WriteLine($"Productos Vendidos por Usuario Id {item.IdUsuario}: {item.Descripciones}");
            }


            Console.WriteLine(" ** Ventas ** ");

            // Traer Ventas 
            List<Venta> ventas = ManejadorVenta.ObtenerVentas(1);
            foreach (var item in ventas)
            {
                Console.WriteLine($"Ventas Usuario: {item.IdUsuario}, Id de la Venta: {item.Id}");
            }


            Console.WriteLine("** Inicio de sesi�n  ** ");

            // Inicio de sesi�n 
            Usuario usuarioLogin = ManejadorUsuario.ObtenerUsuarioLogin("tcasazza", "SoyTobiasCasazza");
            Console.WriteLine($"Usuario: {usuarioLogin.Nombre} \tApellido: {usuarioLogin.Apellido} \tMail: {usuarioLogin.Mail}");
        }
    }
}
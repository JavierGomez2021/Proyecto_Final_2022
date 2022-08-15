using ConsoleTables;

namespace ProyectoFinal
{
    public class ProbarObjeto
    {
        static void Main(string[] args)
        {
            string usuario;
            string contraseña;
            bool usuarioValido = false;
            string opcionMenu;
            string opcionFormato;
            int intentosValidarUsuario = 3;

            do
            {                
                Console.WriteLine("Ingrese su Usuario");
                usuario = Console.ReadLine();

                Console.WriteLine("Ingrese su Contraseña");
                contraseña = Console.ReadLine();

                InicioHandler Ih = new InicioHandler();

                usuarioValido = Ih.IniciarSesion(usuario, contraseña);

                if(usuarioValido == false)
                { 
                    intentosValidarUsuario = intentosValidarUsuario - 1;

                    if (intentosValidarUsuario != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("Usuario/Contraseña Invalidos, le quedan " + intentosValidarUsuario + " intentos");
                        Console.WriteLine(" ");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(" ");
                        Console.WriteLine("No le quedan mas intentos");
                        break;
                    }
                }
            } while (usuarioValido == false);

            if (usuarioValido)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Bienvenido al Sistema: " + usuario);

                do
                {   
                    ImprimirMenu();

                    opcionMenu = Console.ReadLine();

                    if (opcionMenu == "1")
                    {
                        ImprimirMenuFormato();

                        opcionFormato = Console.ReadLine();

                        if (opcionFormato == "1")
                        {
                            ImprimirProducto();
                        }
                        else if (opcionFormato == "2")
                        {
                            ImprimirProductoTabla();
                        }
                        else
                        {   
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opcion de Formato Incorrecta");
                        }
                    }
                    else if (opcionMenu == "2")
                    {
                        ImprimirMenuFormato();

                        opcionFormato = Console.ReadLine();

                        if (opcionFormato == "1")
                        {
                            ImprimirUsuario();
                        }
                        else if (opcionFormato == "2")
                        {
                            ImprimirUsuarioTabla();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opcion de Formato Incorrecta");
                        }
                    }
                    else if (opcionMenu == "3")
                    {
                        ImprimirMenuFormato();

                        opcionFormato = Console.ReadLine();

                        if (opcionFormato == "1")
                        {
                            ImprimirProductoVendido();
                        }
                        else if (opcionFormato == "2")
                        {
                            ImprimirProductoVendidoTabla();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opcion de Formato Incorrecta");
                        }
                    }
                    else if (opcionMenu == "4")
                    {
                        ImprimirMenuFormato();

                        opcionFormato = Console.ReadLine();

                        if (opcionFormato == "1")
                        {
                            ImprimirVenta();
                        }
                        else if (opcionFormato == "2")
                        {
                            ImprimirVentaTabla();
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Opcion de Formato Incorrecta");
                        }
                    }
                    else if (opcionMenu == "s" || opcionMenu == "S")
                    {
                        Console.Clear();
                        Console.WriteLine("Adios . . .");
                        break;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Opcion incorrecta!!");
                    }
                } while (opcionMenu != "s" && opcionMenu != "S");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Se cierra el Sistema");
            }
        }

        public static void ImprimirProducto()
        {
            ProductoHandler ph = new ProductoHandler();

            List<Producto> listaProductos = new List<Producto>();

            listaProductos = ph.TraerProductos();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("TABLA PRODUCTO");

            foreach (Producto p in listaProductos)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Id          : " + p._id);
                Console.WriteLine("Descrpcion  : " + p._descripcion);
                Console.WriteLine("Costo       : " + p._costo);
                Console.WriteLine("Precio Venta: " + p._precioVenta);
                Console.WriteLine("Stock       : " + p._stock);
                Console.WriteLine("Id Usuario  : " + p._idUsuario);
                Console.WriteLine("-----------------------------------");                
            }
        }
        public static void ImprimirUsuario()
        {
            UsuarioHandler Uh = new UsuarioHandler();

            List<Usuario> listaUsuario = new List<Usuario>();

            listaUsuario = Uh.TraerUsuarios();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("TABLA USUARIO");

            foreach (Usuario u in listaUsuario)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Id             : " + u._id);
                Console.WriteLine("Nombre         : " + u._nombre);
                Console.WriteLine("Apellido       : " + u._apellido);
                Console.WriteLine("Nombre Usuario : " + u._nombreUsuario);
                Console.WriteLine("Contraseña     : " + u._contraseña);
                Console.WriteLine("Mail           : " + u._mail);
                Console.WriteLine("-----------------------------------");

            }
        }
        public static void ImprimirProductoVendido()
        {
            ProductoVendidoHandler Pvh = new ProductoVendidoHandler();

            List<ProductoVendido> listaProdVendidos = new List<ProductoVendido>();

            listaProdVendidos = Pvh.TraerProdVendidos();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("TABLA PRODUCTO VENDIDO");

            foreach(ProductoVendido pv in listaProdVendidos)
            {
                 Console.WriteLine("-----------------------------------");
                 Console.WriteLine("Id             : " + pv._id);
                 Console.WriteLine("IdProducto     : " + pv._idProducto);
                 Console.WriteLine("Stock          : " + pv._stock);
                 Console.WriteLine("IdVenta        : " + pv._idVenta);
                 Console.WriteLine("-----------------------------------");
            }
        }
        public static void ImprimirVenta()
        {
            VentasHandler Vh = new VentasHandler();

            List<Venta> listaVentas = new List<Venta>();

            listaVentas = Vh.TraerVenta();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("TABLA VENTA");

            foreach (Venta v in listaVentas)
            {
                Console.WriteLine("-----------------------------------");
                Console.WriteLine("Id             : " + v._id);
                Console.WriteLine("Comentarios    : " + v._comentarios);
                Console.WriteLine("-----------------------------------");
            }
        }

        public static void ImprimirMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" ");
            Console.WriteLine("Seleccione la tabla que desea Imprimir o 'S' para salir.");
            Console.WriteLine(" ");
            Console.WriteLine("1 - PRODUCTO");
            Console.WriteLine("2 - USUARIO");
            Console.WriteLine("3 - PRODUCTO VENDIDO");
            Console.WriteLine("4 - VENTA");
            Console.WriteLine("S - SALIR");
            Console.WriteLine(" ");
        }
        public static void ImprimirMenuFormato()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Seleccione Formato de Impresion");
            Console.WriteLine("1 - LISTA");
            Console.WriteLine("2 - TABLA");
        }

        public static void ImprimirProductoTabla()
        {
            ProductoHandler ph = new ProductoHandler();

            List<Producto> listaProductos = new List<Producto>();

            listaProductos = ph.TraerProductos();
            
            var table = new ConsoleTable("ID", "DESCRIPCION", "COSTO","PRECIO VENTA", "STOCK", "ID USUARIO");
            
            foreach (Producto p in listaProductos)
            {
                table.AddRow(p._id, p._descripcion, p._costo, p._precioVenta, p._stock, p._idUsuario);                
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" -------------------------------------------------------------------------");
            Console.WriteLine("                              TABLA PRODUCTO                              ");
            Console.WriteLine(table.ToString());
        }
        public static void ImprimirUsuarioTabla()
        {
            UsuarioHandler Uh = new UsuarioHandler();

            List<Usuario> listaUsuario = new List<Usuario>();

            listaUsuario = Uh.TraerUsuarios();
            
            var table = new ConsoleTable("ID", "NOMBRE", "APELLIDO", "NOMBRE USUARIO", "CONTRASEÑA", "MAIL");

            foreach (Usuario u in listaUsuario)            
            {
                table.AddRow(u._id, u._nombre, u._apellido, u._nombreUsuario, u._contraseña, u._mail);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ---------------------------------------------------------------------------------------");
            Console.WriteLine("                                    TABLA USUARIO                                       ");
            Console.WriteLine(table.ToString());
        }
        public static void ImprimirProductoVendidoTabla()
        {
            ProductoVendidoHandler Pvh = new ProductoVendidoHandler();

            List<ProductoVendido> listaProdVendidos = new List<ProductoVendido>();

            listaProdVendidos = Pvh.TraerProdVendidos();
            
            var table = new ConsoleTable("ID", "ID PRODUCTO", "STOCK", "ID VENTA");

            foreach (ProductoVendido pv in listaProdVendidos)
            {
                table.AddRow(pv._id, pv._idProducto, pv._stock, pv._idVenta);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" ---------------------------------------");
            Console.WriteLine("         TABLA PRODUCTO VENDIDO         ");
            Console.WriteLine(table.ToString());
        }
        public static void ImprimirVentaTabla()
        {
            VentasHandler Vh = new VentasHandler();

            List<Venta> listaVentas = new List<Venta>();

            listaVentas = Vh.TraerVenta();
            
            var table = new ConsoleTable("ID", "COMENTARIOS");

            foreach (Venta v in listaVentas)
            {
                table.AddRow(v._id, v._comentarios);                
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" --------------------");
            Console.WriteLine("     TABLA VENTA     ");
            Console.WriteLine(table.ToString());
        }
    }
}



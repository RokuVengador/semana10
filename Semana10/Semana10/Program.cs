using Semana10.Models;
using Semana10.DAO;

CrudProductos CrudProductos = new CrudProductos();
Producto Producto = new Producto();

bool Continuar = true;
while (Continuar)
{
    Console.WriteLine("Bienvenido a tu CRUD favorito.");
    Console.WriteLine("Menu CRUD semana 10.");
    Console.WriteLine("Ingresa un numero entre 1 y 4.");
    Console.WriteLine("Pulse 1 para ingresar un producto");
    Console.WriteLine("Pulse 2 para actualizar un producto");
    Console.WriteLine("Pulse 3 para eliminar un producto");
    Console.WriteLine("Pulse 4 para listar productos\n");
    var Menu = Convert.ToInt32(Console.ReadLine());

    switch (Menu)
    {

        case 1:
            int bucle = 1;
            while (bucle == 1)
            {
                Console.WriteLine("Ingresa tu nombre: ");
                Producto.Nombre = Console.ReadLine();

                Console.WriteLine("Decribe el articulo: ");
                Producto.Descripción = Console.ReadLine();

                Console.WriteLine("Ingresa su precio: ");
                //en el dato precio uso el float.parse para covertir.
                Producto.Precio = float.Parse(Console.ReadLine());

                Console.WriteLine("Ingresa numero de stock: ");
                Producto.Stock = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Espera mientras se cargan los datos...");
                CrudProductos.AgregarProducto(Producto);
                Console.WriteLine("El producto se ingreso correctamente.");
                Console.WriteLine("Pulsa 1 para continuar insertando productos.");
                Console.WriteLine("Pulsa 0 para salir");
                bucle = Convert.ToInt32(Console.ReadLine());
            }
            break;
        case 2:
            Console.WriteLine("Actualizar datos");
            Console.WriteLine("Ingresa el ID del producto a actualizar");
            Console.WriteLine("NOTA: deve ser un numero de Id que tengas en tu BD.");
           
            var ProductoIndividiualUNO = CrudProductos.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            Console.WriteLine("Espera mientras se cargan los datos...");
            if (ProductoIndividiualUNO == null)
            {
                Console.WriteLine("El producto no existe");
            }
            else
            {
                Console.WriteLine($"Nombre: {ProductoIndividiualUNO.Nombre} , Descripcion: {ProductoIndividiualUNO.Descripción}");


                Console.WriteLine("Para actulizar nombre presiona 1");

                Console.WriteLine("Para actulizar la descripcion presiona 2");

                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    Console.WriteLine("Ingrese el nuevo nombre");
                    ProductoIndividiualUNO.Nombre = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Ingrese una nueva descripcion");
                    ProductoIndividiualUNO.Descripción = Console.ReadLine();
                }
                CrudProductos.ActualizarProducto(ProductoIndividiualUNO, Lector);
                Console.WriteLine("Actualizacion exitosa.");
            }
            break;
        case 3:
            Console.WriteLine("Ingresa un ID de un producto a eliminar");
            Console.WriteLine("NOTA: deve ser un numero de Id que tengas en tu BD");
           
            var ProductoIndividualDOS = CrudProductos.ProductoIndividual(Convert.ToInt32(Console.ReadLine()));
            if (ProductoIndividualDOS == null)
            {
                Console.WriteLine("Ese producto no existe no existe");
            }
            else
            {
                Console.WriteLine("#Eliminar producto");
                Console.WriteLine($"Nombre: {ProductoIndividualDOS.Nombre} , Descripcion: {ProductoIndividualDOS.Descripción}");
                
                Console.WriteLine("El producto selecccionado es correcro?");
                Console.WriteLine("presiona 1 si es correcto.");
                var Lector = Convert.ToInt32(Console.ReadLine());
                if (Lector == 1)
                {
                    var Id = Convert.ToInt32(ProductoIndividualDOS.Id);
                    Console.WriteLine(CrudProductos.EliminarUsuario(Id));
                }
                else
                {
                    Console.WriteLine("Inicia nuevamente");
                }

            }
            break;
        case 4:
            Console.WriteLine("Espera mientras se cargan los datos...");
            Console.WriteLine("La lista de tus productos es: ");
            var ListarProducto = CrudProductos.ListarProductos();
            foreach (var ActProd in ListarProducto)
            {
                Console.WriteLine($"{ActProd.Id} , {ActProd.Nombre} , {ActProd.Descripción}");
            }
            break;
    }
    Console.WriteLine("#Deseas seguir haciendo cambios?");
    Console.WriteLine("  Presiona      " + "s     " + "para continuar, o     " + "n    " + " para salir.");
    var cont = Console.ReadLine();
    if (cont.Equals("N"))
    {
        Continuar = false;
    }
}



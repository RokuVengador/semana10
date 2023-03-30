using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Semana10.Models;


namespace Semana10.DAO
{
    //capturas por teclado la nueva información que el usuario digite

    public class CrudProductos
    {

        public void AgregarProducto(Producto Parametrosproducto)
        {
            using (AlmacenContext db =
                new AlmacenContext())
            {
                Producto producto = new Producto();
                producto.Nombre = Parametrosproducto.Nombre;
                producto.Descripción = Parametrosproducto.Descripción;
                producto.Precio = Parametrosproducto.Precio;
                producto.Stock = Parametrosproducto.Stock;
                db.Add(producto);
                db.SaveChanges();
            }
        }
        public Producto ProductoIndividual(int id)
        {
            using (AlmacenContext bd = new AlmacenContext())
            {

                var buscar = bd.Productos.FirstOrDefault(x => x.Id == id);

                return buscar;
            }
        }

        public void ActualizarProducto(Producto ParamentroProducto, int Lector)
        {
            using (AlmacenContext db =
                new AlmacenContext())
            {

                var buscar = ProductoIndividual(ParamentroProducto.Id);
                if (buscar == null)
                {
                    Console.WriteLine("El id no existe");
                }
                else
                {
                    if (Lector == 1)
                    {
                        buscar.Nombre = ParamentroProducto.Nombre;
                    }
                    else
                    {
                        //Bug
                        buscar.Descripción = ParamentroProducto.Descripción;
                    }

                    //buscar.Edad = ParamentrosUsuario.Edad;
                    db.Update(buscar);
                    db.SaveChanges();

                }

            }

        }
        public string EliminarUsuario(int id)
        {
            using (AlmacenContext db =
                    new AlmacenContext())
            {
                var buscar = ProductoIndividual(id);
                if (buscar == null)
                {
                    return "El usuario no existe";
                }
                else
                {
                    db.Productos.Remove(buscar);
                    db.SaveChanges();
                    return "El usuario se elimino";
                }

            }
        }
        public List<Producto> ListarProductos()
        {
            using (AlmacenContext db =
                   new AlmacenContext())
            {
                return db.Productos.ToList();
            }

        }
    }

}

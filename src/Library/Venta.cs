using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public class Venta
    {
        public Dictionary<Producto, int> ProductosCantidad { get; set; }
        public double Total { get; set; }
        public DateTime Fecha { get; set; }
        public Cliente ClienteComprador { get; set; }
        public Usuario UsuarioVendedor { get; set; }

        public Venta(Dictionary<Producto, int> productosCantidad, double total, DateTime fecha, Cliente clienteComprador,
            Usuario usuarioVendedor)
        {
            ProductosCantidad = productosCantidad;
            Total = total;
            Fecha = fecha;
            ClienteComprador = clienteComprador;
            UsuarioVendedor = usuarioVendedor;
        }

        public void AgregarProducto(Producto producto, int cantidad)
        {
            ProductosCantidad.Add(producto, cantidad);
        }
    }
}
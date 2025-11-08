using System;
using System.Collections.Generic;
namespace ClassLibrary
{
    public class Usuario : Persona
    {
        public bool Suspendido { get; set; }
        public GenericContainer<Cliente> ListaClientesDeUsuario { get; set; }
        public GenericContainer<Venta> ListaVentas { get; set; }
        public GenericContainer<Cotizacion> ListaCotizaciones { get; set; }
        public GenericContainer<Interaccion> ListaInteracciones { get; set; }

        public Usuario(
            string nombre,
            string email,
            string apellido,
            bool suspendido,
            GenericContainer<Cliente>? listaClientesDeUsuario = null,
            GenericContainer<Venta>? listaVentas = null,
            GenericContainer<Cotizacion>? listaCotizaciones = null,
            GenericContainer<Interaccion>? listaInteracciones = null
        )
            : base(nombre, email, apellido)
        {
            Suspendido = suspendido;
            ListaClientesDeUsuario = listaClientesDeUsuario ?? new GenericContainer<Cliente>();
            ListaVentas = listaVentas ?? new GenericContainer<Venta>();
            ListaCotizaciones = listaCotizaciones ?? new GenericContainer<Cotizacion>();
            ListaInteracciones = listaInteracciones ?? new GenericContainer<Interaccion>();
        }

        public List<Cliente> VerClientes()
        {
            List<Cliente> clientes = new List<Cliente>();
            foreach (Cliente cliente in ListaClientesDeUsuario)
            {
                clientes.Add(cliente);
            }

            return clientes;
        }

        public List<Interaccion> VerInteraccionesCliente(Cliente cliente)
        {
            List<Interaccion> interacciones = new List<Interaccion>();
            foreach (Interaccion i in cliente.ListaInteraccion)
            {
                interacciones.Add(i);
            }

            return interacciones;
        }

        public List<Interaccion> VerInteraccionesCliente(Cliente cliente, string tipo)
        {
            List<Interaccion> interacciones = new List<Interaccion>();
            foreach (Interaccion i in cliente.ListaInteraccion)
            {
                if (i.GetType().Name == tipo)
                {
                    interacciones.Add(i);
                }
            }

            return interacciones;
        }

        public List<Interaccion> VerInteraccionesCliente(Cliente cliente, DateTime fecha)
        {
            List<Interaccion> interacciones = new List<Interaccion>();
            foreach (Interaccion i in cliente.ListaInteraccion)
            {
                if (i.Fecha == fecha)
                {
                    interacciones.Add(i);
                }
            }

            return interacciones;
        }

        public List<Interaccion> VerInteraccionesCliente(Cliente cliente, DateTime fecha, string tipo)
        {
            List<Interaccion> interacciones = new List<Interaccion>();
            foreach (Interaccion i in cliente.ListaInteraccion)
            {
                if (i.GetType().Name == tipo && i.Fecha == fecha)
                {
                    interacciones.Add(i);
                }
            }

            return interacciones;
        }

        public List<Cliente> VerClientesConPocaInteraccion()
        {
            List<Cliente> clientesPocaInteraccion = new List<Cliente>();
            foreach (Cliente cl in ListaClientesDeUsuario)
            {
                if (cl.ListaInteraccion.Count() <= 5)
                {
                    clientesPocaInteraccion.Add(cl);
                }
            }

            return clientesPocaInteraccion;
        }


        public List<Cliente> VerClientesEnVisto()
        {
            List<Cliente> clientesVistos = new List<Cliente>();
            foreach (Cliente cl in ListaClientesDeUsuario)
            {
                if (cl.UsuarioAsignado != null) // etiqueta visto
                {
                    clientesVistos.Add(cl);
                }
            }

            return clientesVistos;
        }

        public List<Venta> VerVentasPorPeriodo(DateTime fechaini, DateTime fechafin)
        {
            List<Venta> ventasPorFecha = new List<Venta>();
            foreach (Venta v in ListaVentas)
            {
                if (v.Fecha >= fechaini && v.Fecha <= fechafin)
                {
                    ventasPorFecha.Add(v);
                }
            }

            return ventasPorFecha;
        }

        public void RegistrarCotizacion(double total, DateTime fecha,
            DateTime fechaLimite, string descripcion)
        {
            Cotizacion cotizacion = new Cotizacion(total, fecha, fechaLimite, descripcion);
        }

        public void RegistrarVenta(Dictionary<Producto, int> productos, double total, DateTime fecha, Cliente cliente,
            Usuario usuario)
        {
            Venta venta = new Venta(productos, total, fecha, cliente, usuario);
            ListaVentas.Add(venta);
        }

        public void AgregarNotaAInteraccion(Interaccion interaccion, string nota)
        {
            foreach (Interaccion i in ListaInteracciones)
            {
                if (i.Equals(interaccion))
                {
                    i.Nota = nota;
                    break;
                }
            }
        }
    }
    
}
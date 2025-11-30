using System;
using System.Collections.Generic;
using ClassLibrary;
using Library.Excepciones;

namespace Library
{
    public class Fachada
    {
        private static Fachada _instancia;

        public static Fachada Instancia
        {
            get
            {
                if (_instancia == null)
                    _instancia = new Fachada();

                return _instancia;
            }
        }

        private Usuario user { get; set; }

        public void SetUsuario(Usuario unUsuario)
        {
            ArgumentNullException.ThrowIfNull(unUsuario);
           
            user = unUsuario;
        }

        private void VerificarUsuario()
        {
            if (user == null)
                throw new ArgumentNullException();
        }

        private Administrador VerificarAdministrador()
        {
            VerificarUsuario();

            if (user is Administrador admin)
                return admin;

            throw new PermisoDenegadoException("Se requieren permisos de administrador.");
        }

        private Vendedor VerificarVendedor()
        {
            VerificarUsuario();

            if (user is Vendedor vendedor)
                return vendedor;

            throw new PermisoDenegadoException("Se requieren permisos de vendedor.");
        }

        private static void VerificarString(string valor, string nombre)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException($"{nombre} no puede estar vacío.", nombre);
        }

        private static void VerificarNoNull(object obj, string nombre)
        {
            if (obj == null)
                throw new ArgumentNullException(nombre);
        }

        public void CrearCliente(string nombre, string apellido, string email, string telefono,
                                 string genero, DateTime fechaNacimiento, Usuario usuarioAsignado)
        {
            VerificarUsuario();
            VerificarString(nombre, nameof(nombre));
            VerificarString(apellido, nameof(apellido));
            VerificarString(email, nameof(email));
            VerificarString(telefono, nameof(telefono));
            VerificarString(genero, nameof(genero));
            VerificarNoNull(usuarioAsignado, nameof(usuarioAsignado));

            user.CrearCliente(nombre, apellido, email, telefono, genero, fechaNacimiento, usuarioAsignado);
        }

        public void EliminarCliente(Cliente cliente)
        {
            VerificarUsuario();
            VerificarNoNull(cliente, nameof(cliente));

            user.EliminarCliente(cliente);
        }

        public void ModificarCliente(Cliente cliente, string? nombre, string? apellido,
                                     string? telefono, string? correo,
                                     DateTime fechaNacimiento, string? genero)
        {
            VerificarUsuario();
            VerificarNoNull(cliente, nameof(cliente));

            user.ModificarCliente(cliente, nombre, apellido, telefono, correo, fechaNacimiento, genero);
        }

        public void AgregarEtiquetaACliente(Cliente cliente, string etiqueta)
        {
            VerificarUsuario();
            VerificarNoNull(cliente, nameof(cliente));
            VerificarString(etiqueta, nameof(etiqueta));

            user.AgregarEtiquetaACliente(cliente, etiqueta);
        }

        public void BuscarCliente(string criterio)
        {
            VerificarUsuario();
            VerificarString(criterio, nameof(criterio));

            user.BuscarCliente(criterio);
        }

        public List<Cliente> VerClientes()
        {
            VerificarUsuario();
            return user.VerClientes();
        }

        public void AgregarInteraccion(Cliente cliente, Interaccion interaccion)
        {
            VerificarUsuario();
            VerificarNoNull(cliente, nameof(cliente));
            VerificarNoNull(interaccion, nameof(interaccion));

            user.AgregarInteraccion(cliente, interaccion);
        }

        public void AgregarNota(Interaccion interaccion, string nota)
        {
            VerificarUsuario();
            VerificarNoNull(interaccion, nameof(interaccion));
            VerificarString(nota, nameof(nota));

            user.AgregarNota(interaccion, nota);
        }

        public void EliminarInteraccion(Interaccion interaccion, Cliente cliente)
        {
            VerificarUsuario();
            VerificarNoNull(interaccion, nameof(interaccion));
            VerificarNoNull(cliente, nameof(cliente));

            user.EliminarInteraccion(interaccion, cliente);
        }

        public List<Interaccion> VerInteraccionesCliente(Cliente cliente)
        {
            VerificarUsuario();
            VerificarNoNull(cliente, nameof(cliente));

            return user.VerInteraccionesCliente(cliente);
        }

        public List<Interaccion> VerInteraccionesCliente(Cliente cliente, string? tipo = null, DateTime? fecha = null)
        {
            VerificarUsuario();
            VerificarNoNull(cliente, nameof(cliente));

            return user.VerInteraccionesCliente(cliente, tipo, fecha);
        }

        public void RegistrarCotizacion(double total, DateTime fecha, DateTime fechaLimite, string descripcion)
        {
            VerificarUsuario();
            VerificarString(descripcion, nameof(descripcion));

            user.RegistrarCotizacion(total, fecha, fechaLimite, descripcion);
        }

        public Venta CrearVenta(Vendedor vendedor, Cliente cliente, Dictionary<Producto, int> productosCantidad, DateTime fecha)
        {
            VerificarUsuario();
            VerificarNoNull(vendedor, nameof(vendedor));
            VerificarNoNull(cliente, nameof(cliente));
            VerificarNoNull(productosCantidad, nameof(productosCantidad));

            return user.crearVenta(vendedor, cliente, productosCantidad, fecha);
        }

        public void RegistrarVenta(Venta venta)
        {
            VerificarUsuario();
            VerificarNoNull(venta, nameof(venta));

            user.RegistrarVenta(venta);
        }

        public List<Venta> ObtenerVentas()
        {
            VerificarUsuario();
            return user.ObtenerVentas();
        }

        public List<Venta> VerVentasPorPeriodo(DateTime fechaini, DateTime fechafin)
        {
            VerificarUsuario();
            return user.VerVentasPorPeriodo(fechaini, fechafin);
        }

        public void CrearUsuario(string nombre, string email, string apellido, string telefono)
        {
            var admin = VerificarAdministrador();

            VerificarString(nombre, nameof(nombre));
            VerificarString(apellido, nameof(apellido));
            VerificarString(email, nameof(email));
            VerificarString(telefono, nameof(telefono));

            admin.CrearUsuario(nombre, email, apellido, telefono);
        }

        public void EliminarUsuario(Usuario unUsuario)
        {
            var admin = VerificarAdministrador();
            VerificarNoNull(unUsuario, nameof(unUsuario));

            admin.EliminarUsuario(unUsuario);
        }

        public void SuspenderUsuario(Usuario unUsuario)
        {
            var admin = VerificarAdministrador();
            VerificarNoNull(unUsuario, nameof(unUsuario));

            admin.SuspenderUsuario(unUsuario);
        }

        public void RehabilitarUsuario(Usuario unUsuario)
        {
            var admin = VerificarAdministrador();
            VerificarNoNull(unUsuario, nameof(unUsuario));

            admin.ReahnilitarUsuario(unUsuario);
        }

        public void AsignarNuevoVendedor(Cliente cliente, Vendedor vendedorNuevo)
        {
            var vendedorActual = VerificarVendedor();

            VerificarNoNull(cliente, nameof(cliente));
            VerificarNoNull(vendedorNuevo, nameof(vendedorNuevo));

            vendedorActual.CambiarVendedorAsignado(cliente, vendedorNuevo);
        }

        public void VerPanelResumen()
        {
            VerificarUsuario();
            user.VerPanelResumen();
        }
    }
}

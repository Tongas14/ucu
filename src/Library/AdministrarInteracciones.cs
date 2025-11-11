using System.Collections.Generic;
using ClassLibrary;

namespace Library

{
    public class AdministrarInteracciones
    {
        private List<Interaccion> ListaInteracciones = new List<Interaccion>();
        private AdministrarClientes instancia = AdministrarClientes.Instancia;
        private static AdministrarInteracciones _instancia;
        public void AgregarInteraccion(Cliente unCliente, Interaccion unaInteraccion)
        {
            ListaInteracciones.Add(unaInteraccion);
        }
        public List<Interaccion> VerInteraccionesCliente()
        {
            return ListaInteracciones;
        }

        public void EliminarInteraccion(Interaccion interaccion)
        {
            ListaInteracciones.Remove(interaccion);
        }
        
        public void AgregarNota(Interaccion unaInteraccion, string nota)
        {
            unaInteraccion.AddNota(nota);
        }
        
        public void ActualizarInteraccionesRespondidas()
        {
            // Filtramos solo las interacciones que implementan IRespondible
            List<IRespondible> respondibles = new List<IRespondible>();

            foreach (Interaccion i in ListaInteracciones)
            {
                if (i is IRespondible r)
                {
                    respondibles.Add(r);
                }
            }

            // Ahora comparamos entre todas las posibles combinaciones
            foreach (IRespondible original in respondibles)
            {
                foreach (IRespondible posibleRespuesta in respondibles)
                {
                    if (original != posibleRespuesta && original.EsRespuestaDe(posibleRespuesta))
                    {
                        original.MarcarComoRespondido();
                    }
                }
            }
        }
        public void AgregarLlamada() { }
        public void AgregarReunion() { }
        public void AgregarEmails() { }
        public void AgregarMensajes() { }
    }
}
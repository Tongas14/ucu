using System;

namespace ClassLibrary
{
    public class Mensajes : Interaccion
    {
        public Mensajes(Persona remitente, Persona destinatario, DateTime fecha, string tema) : base(remitente, destinatario,
            fecha, tema)
        {
        
        }

        public void Enviar()
        {
        
        }
    }
}
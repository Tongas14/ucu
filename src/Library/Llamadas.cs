using System;

namespace ClassLibrary
{

    public class Llamadas : Interaccion
    {
        public Llamadas(Persona remitente, Persona destinatario, DateTime fecha, string tema) : base(remitente,
            destinatario,
            fecha, tema)
        {

        }
    }
}
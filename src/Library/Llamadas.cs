using System;

namespace ClassLibrary
{

    public class Llamadas : Interaccion
    {
        public string NumeroEmisor {get; set; }
        public string NumeroReceptor {get; set; }

        public Llamadas(Persona emisor, Persona receptor, DateTime fecha, string tema) : base(emisor,
            receptor, fecha, tema)
        {
            this.NumeroEmisor = emisor.Telefono;
            this.NumeroReceptor = receptor.Telefono;

        }
    }
}
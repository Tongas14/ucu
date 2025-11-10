using System;

namespace ClassLibrary
{
    public class Emails : Interaccion
    {
        public string DireccionEmisor { get; set; }
        public string DireccionReceptor { get; set; }
        public string Contenido { get; set; }

        public Emails(Persona emisor, Persona receptor, DateTime fecha, string tema, string contenido) : base(
            emisor, receptor, fecha, tema)
        {
            this.DireccionEmisor = emisor.Email;
            this.DireccionReceptor = receptor.Email;
            this.Contenido = contenido;
        }
        
    }
}


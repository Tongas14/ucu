using System;

namespace ClassLibrary
{
    public class Mensajes : Interaccion
    
    {
        public string NumeroEmisor { get; set; }
        public string NumeroReceptor { get; set; }
        public string Contenido { get; set; }
        public Mensajes(Persona emisor, Persona receptor, DateTime fecha, string tema, string contenido) : base(emisor, receptor,
            fecha, tema)
        {
            this.NumeroEmisor = emisor.Telefono;
            this.NumeroReceptor = receptor.Telefono;
            this.Contenido = contenido;
        }
        
    }
}
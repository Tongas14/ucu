using System;

namespace ClassLibrary
{
    public class Cotizacion
    {
        public double Total { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Descripcion { get; set; }

        public Cotizacion(double total, DateTime fechaInicio, DateTime fechaLimite, string descripcion)
        {
            this.Total = total;
            this.FechaInicio = fechaInicio;
            this.FechaLimite = fechaLimite;
            this.Descripcion = descripcion;
        }
    }
}

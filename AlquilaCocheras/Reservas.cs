//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AlquilaCocheras
{
    using System;
    using System.Collections.Generic;
    
    public partial class Reservas
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdCochera { get; set; }
        public System.DateTime FechaInicio { get; set; }
        public System.DateTime FechaFin { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public decimal CantidadHoras { get; set; }
        public decimal Precio { get; set; }
        public System.DateTime FechaCarga { get; set; }
        public short Puntuacion { get; set; }
    
        public virtual Cocheras Cocheras { get; set; }
        public virtual Usuarios Usuarios { get; set; }
    }
}

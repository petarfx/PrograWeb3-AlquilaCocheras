using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilaCocheras
{
    public partial class ReservaDTO
    {
        public int IdReserva { get; set; }
        public int IdCliente { get; set; }
        public int IdCochera { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public decimal CantidadHoras { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaCarga { get; set; }
        public double Puntuacion { get; set; }
        public string Ubicacion { get; set; }
        public string UsuarioReserva { get; set; }
        public string Horario2 { get; set; }
    }
}

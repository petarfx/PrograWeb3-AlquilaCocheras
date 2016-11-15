using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilaCocheras
{
    public class cocheraDTO
    {
        public int IdCochera { get; set; }
        public int IdPropietario { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public int Perfil { get; set; }
        public string Ubicacion { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string HoraInicio { get; set; }
        public string HoraFin { get; set; }
        public string Descripcion { get; set; }
        public decimal Latitud { get; set; }
        public decimal Longitud { get; set; }
        public double MetrosCuadrados { get; set; }
        public int TipoVehiculo { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
        public double Puntuacion { get; set; }
    }
}

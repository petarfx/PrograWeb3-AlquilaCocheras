using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;
using System.Configuration;


namespace AlquilaCocheras
{
    public class Views
    {
        //Por cada disponibilidad se deberá mostrar la siguiente información: precio, nombre y apellido 
        //del propietario, precio por hora, la foto, el mapa del lugar dondeestáubicado(utilizar laAPI de                                     
        //Google Maps) y la puntuación promedio.
      

        public List<cocheraDTO> ObtenerCochera(int idCochera)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from c in dc.Cocheras
                         join u in dc.Usuarios
                         on c.IdPropietario equals u.IdUsuario
                         where c.IdCochera == idCochera
                         
                         select new cocheraDTO
                         {
                             IdCochera = c.IdCochera,
                             Precio = c.Precio,
                             IdPropietario = c.IdPropietario,                            

                             FechaInicio = c.FechaInicio,
                             FechaFin = c.FechaFin, 
                             HoraInicio = c.HoraInicio,
                             HoraFin = c.HoraFin,

                             Ubicacion = c.Ubicacion,
                             Imagen = c.Imagen,
                             Latitud = c.Latitud,
                             Longitud = c.Longitud,
                             MetrosCuadrados = c.MetrosCuadrados,
                             TipoVehiculo = c.TipoVehiculo,
                             //Datos del propietario
                             Apellido = u.Apellido,
                             Nombre = u.Nombre
                         }).ToList();
            return query;
        }


        public List<cocheraDTO> VerificaDisponibilidad(int idCochera)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from c in dc.Cocheras                         
                         join r in dc.Reservas
                         on c.IdCochera equals r.IdCochera
                         and 
                         where c.IdCochera == idCochera

                         select new cocheraDTO
                         {
                             IdCochera = c.IdCochera,
                             Precio = c.Precio,
                             IdPropietario = c.IdPropietario,

                             FechaInicio = c.FechaInicio,
                             FechaFin = c.FechaFin,
                             HoraInicio = c.HoraInicio,
                             HoraFin = c.HoraFin,

                             Ubicacion = c.Ubicacion,
                             Imagen = c.Imagen,
                             Latitud = c.Latitud,
                             Longitud = c.Longitud,
                             MetrosCuadrados = c.MetrosCuadrados,
                             TipoVehiculo = c.TipoVehiculo,
                             //Datos del propietario
                             Apellido = u.Apellido,
                             Nombre = u.Nombre
                         }).ToList();
            return query;
        }




    }
}

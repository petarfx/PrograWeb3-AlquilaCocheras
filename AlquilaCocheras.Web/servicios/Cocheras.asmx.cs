using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using AlquilaCocheras;

namespace AlquilaCocheras.Web.servicios
{
    /// <summary>
    /// Descripción breve de Cocheras
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Cocheras : System.Web.Services.WebService
    {

        //[WebMethod]
        //public string HelloWorld()
        //{
        //    return "Hola a todos";
        //}

        [WebMethod]
        public List<cocheraDTO> ObtenerCocheras(string ubicacion, DateTime fechaInicio, DateTime fechaFin)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from c in dc.Cocheras
                         join u in dc.Usuarios
                         on c.IdPropietario equals u.IdUsuario
                         where ((c.Ubicacion.Contains(ubicacion) || ubicacion == null)
                         && (c.FechaInicio >= fechaInicio)
                         && (c.FechaFin <= fechaFin)
                         )
                         select new cocheraDTO
                         {
                             IdCochera = c.IdCochera,
                             IdPropietario = c.IdPropietario,
                             Ubicacion = c.Ubicacion,
                             FechaInicio = c.FechaInicio,
                             FechaFin = c.FechaFin,
                             //ApeYNom = u.Apellido + " " + u.Nombre,
                             Apellido = u.Apellido,
                             Nombre = u.Nombre,
                             Precio = c.Precio,
                             Imagen = c.Imagen
                         }).ToList();
            return query;
        }


        public List<cocheraDTO> ObtenerPromedio(int idCochera)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from r in dc.Reservas
                         where r.IdCochera == idCochera
                         group r by new { IdCochera = r.IdCochera } into grouped
                         select new cocheraDTO
                         {
                             IdCochera = grouped.Key.IdCochera,
                             Puntuacion = grouped.Average(x => x.Puntuacion)
                         }).ToList();
            return query;
        }

    }
}

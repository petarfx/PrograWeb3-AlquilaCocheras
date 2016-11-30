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

        public List<Reservas> VerificaDisponibilidad(int idCochera, DateTime fi, DateTime ff, string hi, string hf)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from c in dc.Cocheras
                         join u in dc.Usuarios
                         on c.IdPropietario equals u.IdUsuario
                         join r in dc.Reservas
                         on c.IdCochera equals r.IdCochera

                         where (
                         c.IdCochera == idCochera

                         //COCHERAS
                             //verifico que el rango de dia/hora ingresado esté dentro de los de la cochera
                             //&& (c.FechaInicio <= fi
                             //&& c.FechaFin >= ff
                             //&& Convert.ToInt32(Convert.ToDateTime(c.HoraInicio).ToShortTimeString().Substring(0, 2)) <= Convert.ToInt32(Convert.ToDateTime(hi).ToShortTimeString().Substring(0, 2))
                             //&& Convert.ToInt32(Convert.ToDateTime(c.HoraFin).ToShortTimeString().Substring(0, 2)) <= Convert.ToInt32(Convert.ToDateTime(hf).ToShortTimeString().Substring(0, 2))

                         && (
                         (fi <= r.FechaInicio && ff > r.FechaInicio && ff <= r.FechaFin)
                         || (fi <= r.FechaInicio && ff >= r.FechaFin)
                         || (fi >= r.FechaInicio && ff <= r.FechaFin)
                         || (fi >= r.FechaInicio && ff >= r.FechaFin && fi < r.FechaFin)
                         )


                        // &&
                             // (      //*8*   *10*  (12)  (16)
                             //     //1    hi  AA  hf  ZZ
                             //     (
                             //        (String.Compare(hi.Substring(0, 2), r.HoraInicio.Substring(0, 2)) <= 0)
                             //        && (String.Compare(hf.Substring(0, 2), r.HoraInicio.Substring(0, 2)) >= 0)
                             //        && (String.Compare(hf.Substring(0, 2), r.HoraFin.Substring(0, 2)) <= 0)
                             //    )
                             //    //2 hi  AA  ZZ  hf
                             //    ||
                             //    (
                             //        (String.Compare(hi.Substring(0, 2), r.HoraInicio.Substring(0, 2)) <= 0)
                             //        && (String.Compare(hf.Substring(0, 2), r.HoraFin.Substring(0, 2)) >= 0)
                             //    )
                             //    //3  AA hi  hf  ZZ
                             //    ||
                             //    (
                             //        (String.Compare(hi.Substring(0, 2), r.HoraInicio.Substring(0, 2)) >= 0)
                             //        && (String.Compare(hf.Substring(0, 2), r.HoraFin.Substring(0, 2)) <= 0)
                             //    )
                             //    //4 AA  hi  ZZ  hf
                             //    || (
                             //        (String.Compare(hi.Substring(0, 2), r.HoraInicio.Substring(0, 2)) >= 0)
                             //        && (String.Compare(hf.Substring(0, 2), r.HoraFin.Substring(0, 2)) >= 0)
                             //        && (String.Compare(hi.Substring(0, 2), r.HoraFin.Substring(0, 2)) < 0)
                             //    )
                             //)

                        )
                         select r
                         ).ToList();
            return query;
        }


        public List<Usuarios> obtenerUsuario(int idUsuario)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from u in dc.Usuarios
                         where
                         u.IdUsuario == idUsuario
                         select u
                         ).ToList();
            return query;
        }

        public List<ReservaDTO> propietarioReservas(int idUsuario, DateTime fi, DateTime ff)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from r in dc.Reservas

                         join c in dc.Cocheras
                         on r.IdCochera equals c.IdCochera

                         join ures in dc.Usuarios
                         on r.IdCliente equals ures.IdUsuario

                         where c.IdPropietario == idUsuario
                         && r.FechaInicio >= fi
                         && r.FechaFin <= ff
                         select new ReservaDTO
                         {
                             FechaInicio = r.FechaInicio,
                             FechaFin = r.FechaFin,
                             Ubicacion = c.Ubicacion,
                             CantidadHoras = r.CantidadHoras,
                             Puntuacion = r.Puntuacion,
                             UsuarioReserva = ures.Nombre + " " + ures.Apellido,
                             Precio = r.Precio
                         }).ToList();
            return query;
        }

        public List<ReservaDTO> clienteReservas(int idUsuario)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from r in dc.Reservas

                         join u in dc.Usuarios
                         on r.IdCliente equals u.IdUsuario

                         where u.IdUsuario == idUsuario
                         select new ReservaDTO
                         {
                             IdReserva = r.IdReserva,
                             IdCochera = r.IdCochera,
                             FechaInicio = r.FechaInicio,
                             FechaFin = r.FechaFin,
                             Horario2 = r.HoraInicio + "-" + r.HoraFin,
                             Precio = r.Precio,
                             Puntuacion = r.Puntuacion
                         }).ToList();
            return query;
        }

        public int puntuarReserva(int idReserva, short Puntuacion)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from r in dc.Reservas
                         where r.IdReserva == idReserva
                         select r
                         ).SingleOrDefault();
            if (query != null)
            {
                query.Puntuacion = Puntuacion;
                dc.SaveChanges();
                return 1;
            }
            return 0;
        }


        public int clienteReservasSinPuntuar(int idUsuario)
        {

            DateTime fechaHoy = DateTime.Today;

            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from r in dc.Reservas

                         join u in dc.Usuarios
                         on r.IdCliente equals u.IdUsuario

                         where u.IdUsuario == idUsuario
                         && r.Puntuacion == 0
                         && r.FechaInicio < fechaHoy
                         select r).Count();
            return query;
        }


        public bool ReservaHorario(int idCochera, string hora, DateTime fecha)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from r in dc.Reservas
                         where r.IdCochera == idCochera
                         && (String.Compare(r.HoraInicio.Substring(0, 2), hora) <= 0
                         && String.Compare(r.HoraFin.Substring(0, 2), hora) >= 0)
                         && (r.FechaInicio <= fecha
                         && r.FechaFin >= fecha)
                         select r).Count();
            if (query > 0)
                return true;
            else
                return false;
        }

        public List<Reservas> ReservaDia(int idCochera, DateTime fecha)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from r in dc.Reservas
                         where r.IdCochera == idCochera
                         && (r.FechaInicio <= fecha
                         && r.FechaFin >= fecha)
                         select r).ToList();
            return query;
        }


    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------
using System.Linq;
namespace AlquilaCocheras
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        public Usuarios()
        {
            this.Cocheras = new HashSet<Cocheras>();
            this.Reservas = new HashSet<Reservas>();
        }
    
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public short Perfil { get; set; }
    
        public virtual ICollection<Cocheras> Cocheras { get; set; }
        public virtual ICollection<Reservas> Reservas { get; set; }


        public List<Usuarios> validaMailDup(string user)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from u in dc.Usuarios
                         where u.Email == user
                         select u).ToList();

            return query;
        }


    }
}

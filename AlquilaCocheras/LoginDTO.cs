using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlquilaCocheras
{
    public class LoginDTO
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
        public string Contrasenia { get; set; }
        public int Perfil { get; set; }

        public List<LoginDTO> validaLogin(string user, string pass)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            var query = (from u in dc.Usuarios
                         where u.Email == user

                         select new LoginDTO
                         {
                             Nombre = u.Nombre,
                             Apellido = u.Apellido,
                             Perfil = u.Perfil
                         }).ToList();

            return query;
        }
       
    }   
    
}

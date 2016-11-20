using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlquilaCocheras.Web.propietarios
{
    public partial class perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<LoginDTO> su = (List<LoginDTO>)Session["UsuarioLogueado"];
                Views usu = new Views();
                List<Usuarios> up = usu.obtenerUsuario(su.First().IdUsuario);
                if (up.Count > 0)
                {
                    txtNombre.Text = up.First().Nombre;
                    txtApellido.Text = up.First().Apellido;
                    txtEmail.Text = up.First().Email;
                    rblPerfil.SelectedValue = up.First().Perfil.ToString();
                    txtContrasenia.Text = up.First().Contrasenia;
                    txtConfContrasenia.Text = up.First().Contrasenia;
                }
            }
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            Usuarios u = new Usuarios();
            u.IdUsuario =  ((List<LoginDTO>)Session["UsuarioLogueado"]).First().IdUsuario;
            u.Nombre = txtNombre.Text.Trim();
            u.Apellido = txtApellido.Text.Trim();
            u.Email = txtEmail.Text;
            u.Perfil = (short)Convert.ToInt32(rblPerfil.SelectedValue);
            u.Contrasenia = txtContrasenia.Text.Trim();

            dc.Usuarios.Add(u);
            dc.Entry(u).State = System.Data.Entity.EntityState.Modified;
            dc.SaveChanges();

            lblResultado.Text = "Operacion Exitosa";
        }
    }
}
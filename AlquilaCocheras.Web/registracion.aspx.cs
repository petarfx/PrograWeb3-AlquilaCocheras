using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlquilaCocheras.Web
{
    public partial class registracion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            if (rblPerfil.SelectedValue != "")
            {
                Usuarios user = new Usuarios();
                if (user.validaMailDup(txtEmail.Text.Trim()).Count > 0) //Mail duplicado
                {
                    lblResultado.Text = "No se pudo completar la registración, existe otro usuario con el email ingresado.";
                    txtEmail.Focus();
                }
                else //Todo bien
                {
                    TP_20162CEntities dc = new TP_20162CEntities();
                    user.Nombre = txtNombre.Text.Trim();
                    user.Apellido = txtApellido.Text.Trim();
                    user.Contrasenia = txtContrasenia.Text.Trim();
                    user.Email = txtEmail.Text.Trim();
                    user.Perfil = (short)Convert.ToInt32(rblPerfil.SelectedItem.Value);
                    dc.Usuarios.Add(user);
                    dc.SaveChanges();
                    
                    lblResultado.Text = "Registración exitosa, diríjase al <a href=\"login.aspx\">login</a>";
                }
            }
            else
            {
                lblResultado.Text = "Ingrese el perfil";
            }
        }
    }
}
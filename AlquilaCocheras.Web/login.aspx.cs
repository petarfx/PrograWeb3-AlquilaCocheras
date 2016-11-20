using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using AlquilaCocheras;

namespace AlquilaCocheras.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["idcochera"] != null)
                {

                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;

            LoginDTO logval = new LoginDTO();
            List<LoginDTO> x = logval.validaLogin(txtEmail.Text, txtContrasenia.Text);

            if (x.Count > 0)
            {
                
                Session["ROL"] = x.First().Perfil;
                Session["UsuarioLogueado"] = x;

                if (x.First().Perfil.ToString() == ConfigurationManager.AppSettings["PerfilCliente"].ToString())
                {
                    if (Request.QueryString["idcochera"] == null)
                        Response.Redirect(ConfigurationManager.AppSettings["ClienteReservarCochera"].ToString());
                    else
                        Response.Redirect(ConfigurationManager.AppSettings["ClienteConfirmarCochera"].ToString() + "?idcochera=" + Request.QueryString["idcochera"].ToString());
                }
                else
                {
                    Response.Redirect("propietarios/reservas.aspx");
                }

            }
            else
            {
                Session["ROL"] = null;
                lblResultado.Text = "Usuario y/o Contraseña inválidos";
            }

        }

    }
}
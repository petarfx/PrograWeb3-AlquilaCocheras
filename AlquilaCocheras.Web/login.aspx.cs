using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using System.Configuration;

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
            if (txtEmail.Text == "cliente@gmail.com" && txtContrasenia.Text == "Password1")
            {
                //Cliente OK
                Session["ROL"] = "C";
                if (Request.QueryString["idcochera"] == null)
                    Response.Redirect(ConfigurationManager.AppSettings["ClienteReservarCochera"].ToString());         
                else                
                    Response.Redirect(ConfigurationManager.AppSettings["ClienteConfirmarCochera"].ToString() + "?idcochera=" + Request.QueryString["idcochera"].ToString());
            }
            else if (txtEmail.Text == "propietario@gmail.com" && txtContrasenia.Text == "Password1")
            {
                //Propietario OK
                Session["ROL"] = "P";
                Response.Redirect("propietarios/reservas.aspx");
            }
            else
            {
                Session["ROL"] = null;
                lblResultado.Text = "Usuario y/o Contraseña inválidos";
            }
        }

    }
}
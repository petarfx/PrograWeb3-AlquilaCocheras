using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlquilaCocheras.Web.MasterPages
{
    public partial class Clientes : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["ROL"] != null && Session["ROL"].ToString() != ConfigurationManager.AppSettings["PerfilCliente"].ToString())
                {
                    if (Session["ROL"].ToString() == ConfigurationManager.AppSettings["PerfilPropietario"].ToString()) //PROPIETARIO
                        Response.Redirect(ConfigurationManager.AppSettings["PropietarioInicio"].ToString());
                    else //ANONIMO
                    {
                        Session["ROL"] = null;
                        if (Request.QueryString == null)
                            Response.Redirect("../login.aspx");
                        else
                            if (Request.QueryString["idcochera"] != null)
                                Response.Redirect("../login.aspx?idCochera=" + Request.QueryString["idCochera"].ToString());
                    }
                }
                //CLIENTE (NO HACE NADA)
            }
        }
    }
}
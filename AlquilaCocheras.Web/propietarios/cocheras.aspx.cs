using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlquilaCocheras.Web.propietarios
{
    public partial class cocheras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Para que siempre pueda editar la fecha de inicio
                esEdicion.Value = "true";
            }

        }

        protected void btnCrearCochera_Click(object sender, EventArgs e)
        {            
            //Abre la Modal
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "showDiv('wnOk', 'Cochera Alta');", true);
            
            //Muestra un Alert
            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Operación exitosa')", true);
        }
    }
}
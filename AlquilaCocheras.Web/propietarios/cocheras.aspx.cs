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
    }
}
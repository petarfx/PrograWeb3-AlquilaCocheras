using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

namespace AlquilaCocheras.Web.propietarios
{
    public partial class reservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Para que siempre pueda editar la fecha de inicio
                esEdicion.Value = "true";
            }
        }

        protected void gvCocheras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblFechaInicio = (Label)e.Row.FindControl("lblFechaInicio");
            // Si es una reserva futura
            if (lblFechaInicio != null && Convert.ToDateTime(lblFechaInicio.Text) > DateTime.Today)
                e.Row.BackColor = Color.AliceBlue;
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            //Haria algo
            DataTable dt = new DataTable();
        }
    }
}
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
            Label lblFechaFin = (Label)e.Row.FindControl("lblFechaFin");
            // Si es una reserva futura
            if (lblFechaInicio != null && lblFechaFin != null)
            {
                if (Convert.ToDateTime(lblFechaInicio.Text) > DateTime.Today)
                    e.Row.BackColor = Color.OrangeRed;

                lblFechaInicio.Text = lblFechaInicio.Text.ToString().Substring(0, 10);
                lblFechaFin.Text = lblFechaFin.Text.ToString().Substring(0, 10);
            }
        }

        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            List<LoginDTO> user = (List<LoginDTO>)Session["UsuarioLogueado"];
            Views vr = new Views();
            gvReservas.DataSource = vr.propietarioReservas(user.First().IdUsuario, Convert.ToDateTime(txtFechaInicio.Text.Trim()), Convert.ToDateTime(txtFechaFin.Text.Trim()));
            gvReservas.DataBind();
        }
    }
}
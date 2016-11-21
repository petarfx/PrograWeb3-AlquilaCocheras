using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;
using AlquilaCocheras;

namespace AlquilaCocheras.Web.clientes
{
    public partial class reservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargarGrilla();
            }
        }


        public void cargarGrilla()
        {
            Views vr = new Views();
            List<LoginDTO> su = (List<LoginDTO>)Session["UsuarioLogueado"];
            gvReservas.DataSource = vr.clienteReservas(su.First().IdUsuario);
            gvReservas.DataBind();
        }

        protected void gvReservas_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblid = (Label)e.Row.FindControl("lblid");
            if (lblid != null)
            {
                LinkButton lnkPuntuar = (LinkButton)e.Row.FindControl("lnkPuntuar");
                Label lblFechaInicio = (Label)e.Row.FindControl("lblFechaInicio");
                Label lblFechaFin = (Label)e.Row.FindControl("lblFechaFin");
                Label lblPuntuacion = (Label)e.Row.FindControl("lblPuntuacion");


                // Si ya tiene puntaje o es una reserva futura
                if (lblPuntuacion != null && lblPuntuacion.Text != "0" || Convert.ToDateTime(lblFechaInicio.Text) > DateTime.Today)
                    lnkPuntuar.Visible = false; //No lo muestro
                else
                    lnkPuntuar.Visible = true; // Lo muestro

                if (Convert.ToDateTime(lblFechaFin.Text) < DateTime.Today)
                    e.Row.BackColor = Color.DimGray;

                lblFechaInicio.Text = Convert.ToDateTime(lblFechaInicio.Text.ToString()).ToShortDateString();
                lblFechaFin.Text = Convert.ToDateTime(lblFechaFin.Text.ToString()).ToShortDateString();

                Label lblNroFila = (Label)e.Row.FindControl("lblNroFila");
                lblNroFila.Text = (e.Row.RowIndex + 1).ToString();

            }
        }

        protected void gvReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblid = (Label)gvReservas.SelectedRow.FindControl("lblid");
            if (lblid != null)
            {
                Label lblNroFila = (Label)gvReservas.SelectedRow.FindControl("lblNroFila");
                lblReservaSeleccionada.Text = string.Format("Reserva Seleccionada Nro: {0}", lblNroFila.Text);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "showModal('miModal', 'hdIdReserva', '" + lblid.Text + "');", true);
                ViewState["idReserva"] = lblid.Text;
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                Views vr = new Views();

                int i = vr.puntuarReserva(Convert.ToInt32(ViewState["idReserva"]), (short)Convert.ToInt32(ddlPuntuacion.SelectedValue));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
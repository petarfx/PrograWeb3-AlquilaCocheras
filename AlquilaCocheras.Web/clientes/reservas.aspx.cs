using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Drawing;

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

        /*FechaInicio" DataField="FechaInicio" />
        <asp:BoundField HeaderText="FechaFin" DataField="FechaFin" />
        <asp:BoundField HeaderText="Horario" DataField="Horario" />
        <asp:BoundField HeaderText="PrecioTotal" DataField="PrecioTotal" />
        <asp:BoundField HeaderText="Puntuacion*/

        public void cargarGrilla()
        { //Haria el get a la base, lo asigno a un datatable, y lo bindeo a la grilla
            DataTable dt = new DataTable();
            dt.Columns.Add("idReserva");
            dt.Columns.Add("FechaInicio");
            dt.Columns.Add("FechaFin");
            dt.Columns.Add("Horario");
            dt.Columns.Add("PrecioTotal");
            dt.Columns.Add("Puntuacion");
            dt.Columns.Add("Seleccionar");

            dt.Rows.Add();
            dt.Rows[0]["idReserva"] = "123";
            dt.Rows[0]["FechaInicio"] = "15/03/2016";
            dt.Rows[0]["FechaFin"] = "15/04/2016";
            dt.Rows[0]["Horario"] = "12";
            dt.Rows[0]["PrecioTotal"] = "1500";
            dt.Rows[0]["Puntuacion"] = "4";

            dt.Rows.Add();
            dt.Rows[1]["idReserva"] = "124";
            dt.Rows[1]["FechaInicio"] = "01/11/2016";
            dt.Rows[1]["FechaFin"] = "15/12/2016";
            dt.Rows[1]["Horario"] = "24";
            dt.Rows[1]["PrecioTotal"] = "1800";
            dt.Rows[1]["Puntuacion"] = "";

            dt.Rows.Add();
            dt.Rows[2]["idReserva"] = "125";
            dt.Rows[2]["FechaInicio"] = "01/09/2016";
            dt.Rows[2]["FechaFin"] = "15/10/2016";
            dt.Rows[2]["Horario"] = "18";
            dt.Rows[2]["PrecioTotal"] = "1600";
            dt.Rows[2]["Puntuacion"] = "";

            gvReservas.DataSource = dt;
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
                if (lblPuntuacion != null && lblPuntuacion.Text != "" || Convert.ToDateTime(lblFechaInicio.Text) > DateTime.Today) 
                    lnkPuntuar.Visible = false; //No lo muestro
                else
                    lnkPuntuar.Visible = true; // Lo muestro

                if (Convert.ToDateTime(lblFechaFin.Text) < DateTime.Today)
                    e.Row.BackColor = Color.LightGray;
            }
        }

        protected void gvReservas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Label lblid = (Label)gvReservas.SelectedRow.FindControl("lblid");
            if (lblid != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "show", "showModal('miModal', 'hdIdReserva', '" + lblid.Text + "');", true);
                //ViewState["idReserva"] = lblid.Text;
            }
        }
    }
}
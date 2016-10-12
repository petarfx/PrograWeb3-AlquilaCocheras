using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace AlquilaCocheras.Web
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void OnInit(EventArgs e)
        {
            //find the button control within the user control
            Button button = (Button)ucBuscador.FindControl("btnFiltrar");
            //wire up event handler
            button.Click += new EventHandler(button_Click);
            base.OnInit(e);
        }

        void button_Click(object sender, EventArgs e)
        {
            ucBuscador.myResultado = "";
            gvCocheras.DataSource = null;
            gvCocheras.DataBind();
            if (ucBuscador.myUbicacion == "SAN JUSTO")
            {
                ucBuscador.myResultado = "No se encontraron resultados";
            }
            else if (ucBuscador.myUbicacion == "HAEDO")
            {
                cargarGrilla();
            }
            else
                ucBuscador.myResultado = "Ubicacion desconocida";
        }

        public void cargarGrilla()
        { //Haria el get a la base, lo asigno a un datatable, y lo bindeo a la grilla
            DataTable dt = new DataTable();
            dt.Columns.Add("idCochera");
            dt.Columns.Add("Precio");
            dt.Columns.Add("ApeyNom");
            dt.Columns.Add("PrecioTotal");
            dt.Columns.Add("Foto");
            dt.Columns.Add("Mapa");
            dt.Columns.Add("Puntuacion");
            //dt.Columns.Add("Seleccionar");
            dt.Rows.Add();
            dt.Rows[0]["idCochera"] = "123";
            dt.Rows[0]["Precio"] = "20";
            dt.Rows[0]["ApeyNom"] = "Juan Perez";
            dt.Rows[0]["PrecioTotal"] = "800";
            dt.Rows[0]["Foto"] = "";
            dt.Rows[0]["Mapa"] = "";
            dt.Rows[0]["Puntuacion"] = "4";
            //dt.Rows[0]["Seleccionar"] = "Seleccionar";

            gvCocheras.DataSource = dt;
            gvCocheras.DataBind();
        }
        protected void gvCocheras_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Label lblid = (Label)e.Row.FindControl("lblid");
            if (lblid != null)
            {
                HyperLink aConfirmar = (HyperLink)e.Row.FindControl("aConfirmar");
                aConfirmar.NavigateUrl = "/clientes/confirmar-reserva.aspx?idcochera=" + lblid.Text;
            }
        }

        protected void gvCocheras_PreRender(object sender, EventArgs e)
        {
            try
            {
                GridView dgr = (System.Web.UI.WebControls.GridView)sender;
                if (dgr != null)
                {
                    GridViewRow PagerRow = dgr.BottomPagerRow;
                    if (PagerRow != null)
                        PagerRow.Visible = true;
                }
            }
            catch (Exception ex)
            {
               //error
            }
        }
    }
}
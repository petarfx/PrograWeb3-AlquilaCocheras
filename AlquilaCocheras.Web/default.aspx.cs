using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using AlquilaCocheras;
//using System.Web.UI.HtmlControls;

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
            //if (ucBuscador.myUbicacion == "SAN JUSTO")
            //{
            //    ucBuscador.myResultado = "No se encontraron resultados";
            //}
            //else if (ucBuscador.myUbicacion == "HAEDO")
            //{
            cargarGrilla();

            //string script = "$(function() { $('html, body').animate({scrollTop: $('#gvCocheras').offset().top}, 2000); });";
            string script = "$('html, body').animate({scrollTop:$('#divGrilla').position().top}, 'slow')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", script, true);
            //}
            //else
            //    ucBuscador.myResultado = "Ubicacion desconocida";
        }

        public void cargarGrilla()
        {
            //Fecha Inicio
            DateTime FI = ucBuscador.myFechaInicio.Trim() == string.Empty ? Convert.ToDateTime(Helper.dateNULL) : Convert.ToDateTime(ucBuscador.myFechaInicio);

            //Fecha Fin
            DateTime FF = ucBuscador.myFechaFin.Trim() == string.Empty ? Convert.ToDateTime(Helper.dateFar) : Convert.ToDateTime(ucBuscador.myFechaFin);

            servicios.Cocheras ws = new servicios.Cocheras();
            
            gvCocheras.DataSource = ws.ObtenerCocheras(ucBuscador.myUbicacion, FI, FF).ToList();
            gvCocheras.DataBind();
        }
        protected void gvCocheras_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            Label lblid = (Label)e.Row.FindControl("lblid");
            if (lblid != null)
            {
                HyperLink aConfirmar = (HyperLink)e.Row.FindControl("aConfirmar");
                aConfirmar.NavigateUrl = "/clientes/confirmar-reserva.aspx?idcochera=" + lblid.Text;
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "mapa", "initMap();", true);


                Label FotoURL = (Label)e.Row.FindControl("lblFotoURL");
                if (FotoURL != null && FotoURL.Text.Trim() != "")
                {
                    Image imgFoto = (Image)e.Row.FindControl("imgFoto");
                    Random rnd = new Random();
                    int nro = rnd.Next(0, 10000000);
                    imgFoto.ImageUrl = FotoURL.Text.ToString() + "?hash=" + nro;
                }

                Label lblPuntuacion = (Label)e.Row.FindControl("lblPuntuacion");
                servicios.Cocheras ws = new servicios.Cocheras();

                var xxx = ws.ObtenerPromedio(Convert.ToInt32(lblid.Text)).ToList();

                if (xxx.Count > 0)
                    lblPuntuacion.Text = xxx.FirstOrDefault().Puntuacion.ToString();

                //HtmlGenericControl divmapa = (HtmlGenericControl)e.Row.FindControl("map");
                //divmapa.ID = "map" + lblid.ToString();

                //Label lblLatitud = (Label)e.Row.FindControl("lblLatitud");
                //Label lblLongitud = (Label)e.Row.FindControl("lblLongitud");

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "mapagrilla", "loadMapGrid('" + lblLatitud.Text + "','" + lblLongitud.Text + "','" + divmapa.ID + "');", true);
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
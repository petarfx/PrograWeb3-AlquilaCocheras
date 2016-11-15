using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using AlquilaCocheras;

namespace AlquilaCocheras.Web.clientes
{
    public partial class reservar : System.Web.UI.Page
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
            cargarGrilla();
            string script = "$('html, body').animate({scrollTop:$('#divGrilla').position().top}, 'slow')";
            ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "script", script, true);
        }


        #region procedimientos
        public void cargarGrilla()
        {
            //Fecha Inicio
            DateTime FI = ucBuscador.myFechaInicio.Trim() == string.Empty ? Convert.ToDateTime(Helper.dateNULL) : Convert.ToDateTime(ucBuscador.myFechaInicio);

            //Fecha Fin
            DateTime FF = ucBuscador.myFechaFin.Trim() == string.Empty ? Convert.ToDateTime(Helper.dateFar) : Convert.ToDateTime(ucBuscador.myFechaFin);

            servicios.Cocheras ws = new servicios.Cocheras();

            var xxx = ws.ObtenerCocheras(ucBuscador.myUbicacion, FI, FF).ToList();

            gvCocheras.DataSource = xxx;
            gvCocheras.DataBind();
        }
        #endregion

        #region grilla_eventos
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
        #endregion
    }
}
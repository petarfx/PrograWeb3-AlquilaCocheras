using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using AlquilaCocheras;
using System.Web.UI.HtmlControls;

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

            
            
            //usando el webservice
            ServiceReference.CocherasSoapClient servicio = new ServiceReference.CocherasSoapClient();
            //gvCocheras.DataSource = servicio.ObtenerCocheras(ucBuscador.myUbicacion, FI, FF).ToList();
            //gvCocheras.DataBind();

            #region validoLugaresDisponibles
            //obtengo tods las cocheras para los parametros indicados
            List<AlquilaCocheras.ServiceReference.cocheraDTO> lc = (List<AlquilaCocheras.ServiceReference.cocheraDTO>)servicio.ObtenerCocheras(ucBuscador.myUbicacion, FI, FF).ToList();

            int cHoraDesde;
            int cHoraHasta;
            DateTime cFechaInicio;
            DateTime cFechaFin;
            bool tieneReserva;
            List<AlquilaCocheras.ServiceReference.cocheraDTO> lDisponibles = new List<AlquilaCocheras.ServiceReference.cocheraDTO>();

            foreach (AlquilaCocheras.ServiceReference.cocheraDTO li in lc)
            {
                //datosCochera
                cHoraHasta = Convert.ToInt32(li.HoraFin.Substring(0, 2));
                cFechaInicio = li.FechaInicio;
                cFechaFin = li.FechaFin;
                tieneReserva = true;
                do
                {
                    cHoraDesde = Convert.ToInt32(li.HoraInicio.Substring(0, 2));


                    //consulto x dia
                    Views vdia = new Views();
                    List<Reservas> rd = vdia.ReservaDia(li.IdCochera, cFechaInicio);
                    if (rd.Count() > 0)
                    {
                        while (cHoraDesde <= cHoraHasta && tieneReserva)
                        {
                            Views v = new Views();
                            if (v.ReservaHorario(li.IdCochera, cHoraDesde.ToString("00.##"), cFechaInicio))
                                cHoraDesde++;
                            else
                                tieneReserva = false;
                        }

                        cFechaInicio = cFechaInicio.AddDays(1);
                    }
                    else
                        tieneReserva = false;
                } while (cFechaInicio <= cFechaFin && tieneReserva);


                if (!tieneReserva)
                    lDisponibles.Add(li);

            }

            gvCocheras.DataSource = lDisponibles;
            gvCocheras.DataBind();
            #endregion 
            
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


                Label lblLatitud = (Label)e.Row.FindControl("lblLatitud");
                Label lblLongitud = (Label)e.Row.FindControl("lblLongitud");

                var divId = string.Format("map_{0}", e.Row.RowIndex.ToString());
                var mapPanel = e.Row.Cells[8].FindControl("mapPanel") as Panel;

                var div = new HtmlGenericControl("div");
                div.Attributes.Add("id", divId);
                div.Attributes.Add("style", "width:200px; height:200px");
                mapPanel.Controls.Add(div);


                var script = new HtmlGenericControl("script");
                script.InnerHtml = @"
                $('document').ready(function() {
                var myLatLng = { lat: parseFloat(" + lblLatitud.Text + "), lng: parseFloat(" + lblLongitud.Text + ") };";
                script.InnerHtml += @"
                 var map = new google.maps.Map(document.getElementById('" + divId + "'), {zoom: 14,center: myLatLng}); });";

                script.Attributes.Add("class", "mapdiv");
                mapPanel.Controls.Add(script);


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
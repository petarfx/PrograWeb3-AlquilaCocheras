using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlquilaCocheras.Web.clientes
{
    public partial class confirmar_reserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            { }
            if (Request.QueryString["idcochera"] != null)
            {
                Views vc = new Views();
                List<cocheraDTO> cochera = vc.ObtenerCochera(Convert.ToInt32(Request.QueryString["idcochera"]));

                if (cochera.Count > 0)
                {
                   
                    txtFechaInicio.Text = cochera.First().FechaInicio.ToShortDateString();
                    txtFechaFin.Text = cochera.First().FechaFin.ToShortDateString();
                    txtHorarioInicio.Text = cochera.First().HoraInicio;
                    txtHorarioFin.Text = cochera.First().HoraFin;
                    lblPrecioHora.Text = cochera.First().Precio.ToString();
                    //lblPrecioTotal.Text = "$ 1800";
                    lblUbicacion.Text = cochera.First().Ubicacion;

                    Random rnd = new Random();
                    int nro = rnd.Next(0, 10000000);
                    imgFoto.ImageUrl = cochera.First().Imagen + "?hash=" + nro;


                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "mapa", "mapAlone('" + cochera.First().Latitud + "','" + cochera.First().Longitud + "','map');", true);
                    //ScriptManager.RegisterStartupScript(this, this.GetType(), "mapa", "mapAlone();", true);
                }
                                
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {



            //LimpiaControles
            ScriptManager.RegisterStartupScript(this, this.GetType(), "clearAll", "LimpiaControles();", true);
            lblResultado.Text = "Operación exitosa";
        }
    }
}
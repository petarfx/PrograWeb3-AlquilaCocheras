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
            if (!IsPostBack)
            {
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
                        hfLat.Value = cochera.First().Latitud.ToString();
                        hfLon.Value = cochera.First().Longitud.ToString();

                        Random rnd = new Random();
                        int nro = rnd.Next(0, 10000000);
                        imgFoto.ImageUrl = cochera.First().Imagen + "?hash=" + nro;

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "mapa", "loadMap('" + hfLat.Value + "','" + hfLon.Value + "');", true);
                    }
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            Views vd = new Views();
            //if (vd.VerificaDisponibilidad(Convert.ToInt32(Request.QueryString["idCochera"].ToString()), Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text), txtHorarioInicio.Text, txtHorarioFin.Text).Count > 0)
            //{
                TP_20162CEntities dc = new TP_20162CEntities();

                Reservas r = new Reservas();
                r.IdCochera = Convert.ToInt32(Request.QueryString["idCochera"].ToString());
                r.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                r.FechaFin = Convert.ToDateTime(txtFechaFin.Text);
                r.HoraInicio = txtHorarioInicio.Text;
                r.HoraFin = txtHorarioFin.Text;
                r.Precio = Convert.ToDecimal(lblPrecioTotal.Text);

                dc.Reservas.Add(r);
                dc.SaveChanges();
                //LimpiaControles
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clearAll", "LimpiaControles();", true);
                lblResultado.Text = "Operación exitosa";
            //}
            //else
            //    lblResultado.Text = "No hay disponibilidad para los dias/horarios ingresados, por favor verifique los datos";            
        }
    }
}
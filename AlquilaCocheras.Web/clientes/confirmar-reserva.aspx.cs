using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AlquilaCocheras;
using System.Globalization;

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
            List<LoginDTO> user = (List<LoginDTO>)Session["UsuarioLogueado"];

            Views vd = new Views();

            List<Reservas> lr= vd.VerificaDisponibilidad(Convert.ToInt32(Request.QueryString["idCochera"].ToString()), Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text), Convert.ToDateTime(txtHorarioInicio.Text).ToShortTimeString().Substring(0, 5), Convert.ToDateTime(txtHorarioFin.Text).ToShortTimeString().Substring(0, 5));

            if (vd.VerificaDisponibilidad(Convert.ToInt32(Request.QueryString["idCochera"].ToString()), Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text), Convert.ToDateTime(txtHorarioInicio.Text).ToShortTimeString().Substring(0, 5), Convert.ToDateTime(txtHorarioFin.Text).ToShortTimeString().Substring(0, 5)).Count == 0)
            {
                TP_20162CEntities dc = new TP_20162CEntities();

                Reservas r = new Reservas();
                r.IdCliente = user.First().IdUsuario;
                r.IdCochera = Convert.ToInt32(Request.QueryString["idCochera"].ToString());
                r.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                r.FechaFin = Convert.ToDateTime(txtFechaFin.Text);
                r.HoraInicio = Convert.ToDateTime(txtHorarioInicio.Text).ToShortTimeString().Substring(0,5);
                r.HoraFin = Convert.ToDateTime(txtHorarioFin.Text).ToShortTimeString().Substring(0, 5);
                r.CantidadHoras = Convert.ToDecimal((((Convert.ToDateTime(txtFechaFin.Text) - Convert.ToDateTime(txtFechaInicio.Text)).TotalDays) + 1) * Convert.ToInt32((Convert.ToInt32(Convert.ToDateTime(txtHorarioFin.Text).ToShortTimeString().Substring(0, 2)) - Convert.ToInt32(Convert.ToDateTime(txtHorarioInicio.Text).ToShortTimeString().Substring(0, 2)))));
                r.Precio = Convert.ToDecimal(hfPrecioTotal.Value);
                r.FechaCarga = DateTime.Now;

                dc.Reservas.Add(r);
                dc.SaveChanges();
                //LimpiaControles
                ScriptManager.RegisterStartupScript(this, this.GetType(), "clearAll", "LimpiaControles();", true);
                lblResultado.Text = "Operación exitosa";
            }
            else
                lblResultado.Text = "No hay disponibilidad para los dias/horarios ingresados, por favor verifique los datos";            
        }
    }
}
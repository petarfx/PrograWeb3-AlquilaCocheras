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
                    ObtenerCocheras();
                }
            }
        }



        public void ObtenerCocheras()
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
                lblUbicacion.Text = cochera.First().Ubicacion;
                hfLat.Value = cochera.First().Latitud.ToString();
                hfLon.Value = cochera.First().Longitud.ToString();

                Random rnd = new Random();
                int nro = rnd.Next(0, 10000000);
                imgFoto.ImageUrl = cochera.First().Imagen + "?hash=" + nro;

                calculaPrecioTotal();

                ScriptManager.RegisterStartupScript(this, this.GetType(), "mapa", "loadMap('" + hfLat.Value + "','" + hfLon.Value + "');", true);
            }
        }

        public void calculaPrecioTotal()
        {
            TimeSpan ts = Convert.ToDateTime(txtFechaFin.Text) - Convert.ToDateTime(txtFechaInicio.Text);
            int dias = ts.Days;
            int horas = Convert.ToInt32(txtHorarioFin.Text.ToString().Substring(0, 2)) - Convert.ToInt32(txtHorarioInicio.Text.ToString().Substring(0, 2));
            int horas_totales = horas * dias;
            decimal precio_total = horas_totales * Convert.ToDecimal(lblPrecioHora.Text);
            lblPrecioTotal.Text = precio_total.ToString();
            hfPrecioTotal.Value = precio_total.ToString();
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {

            if (hfPrecioTotal.Value != null)
            {
                List<LoginDTO> user = (List<LoginDTO>)Session["UsuarioLogueado"];

                Views vd = new Views();


                //Si la cantidad de reesrvas sin puntuar para el cliente es mayor a 2.. no puede hacer reservas
                //Se toman reservas en las que por lo menos haya transcurrido un dia
                if (vd.clienteReservasSinPuntuar(user.First().IdUsuario) <= 2)
                {

                    List<Reservas> lr = vd.VerificaDisponibilidad(Convert.ToInt32(Request.QueryString["idCochera"].ToString()), Convert.ToDateTime(txtFechaInicio.Text), Convert.ToDateTime(txtFechaFin.Text), Convert.ToDateTime(txtHorarioInicio.Text).ToShortTimeString().Substring(0, 5), Convert.ToDateTime(txtHorarioFin.Text).ToShortTimeString().Substring(0, 5));

                    int fvalido = 0;

                    int BDDhi;
                    int BDDhf;
                    int intHoraInicio = Convert.ToInt32(txtHorarioInicio.Text.ToString().Substring(0, 2));
                    int intHoraFin = Convert.ToInt32(txtHorarioFin.Text.ToString().Substring(0, 2));
                    foreach (Reservas li in lr)
                    {

                        BDDhi = Convert.ToInt32(li.HoraInicio.ToString().Substring(0, 2));
                        BDDhf = Convert.ToInt32(li.HoraFin.ToString().Substring(0, 2));

                        //1    hi  AA  hf  ZZ
                        if (!(
                            (intHoraInicio <= BDDhi
                            && intHoraFin > BDDhi
                            && intHoraFin <= BDDhf)

                            //2 hi  AA  ZZ  hf
                            ||
                            (
                            (intHoraInicio <= BDDhi
                            && intHoraFin >= BDDhf)
                            )
                            ||
                            //3  AA hi  hf  ZZ
                            (intHoraInicio >= BDDhi
                            && intHoraFin <= BDDhf)
                            ||
                            //4 AA  hi  ZZ  hf
                            (intHoraInicio >= BDDhi
                            && intHoraFin >= BDDhf
                            && intHoraInicio < BDDhf)
                            ))
                        {
                            //lr.Remove(li);
                            fvalido++; //Es valido
                        }
                    }



                    if (lr.Count == fvalido) //No hay superposiciones.. se inserta
                    {
                        TP_20162CEntities dc = new TP_20162CEntities();

                        Reservas r = new Reservas();
                        r.IdCliente = user.First().IdUsuario;
                        r.IdCochera = Convert.ToInt32(Request.QueryString["idCochera"].ToString());
                        r.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                        r.FechaFin = Convert.ToDateTime(txtFechaFin.Text);
                        r.HoraInicio = Convert.ToDateTime(txtHorarioInicio.Text).ToShortTimeString().Substring(0, 5);
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
                else
                    lblResultado.Text = "Debe puntuar las reservas anteriores antes de realizar una nueva reserva";
            }
            else
                lblResultado.Text = "Controle que las fechas y los horarios tengan el formato correcto";
        }
    }
}
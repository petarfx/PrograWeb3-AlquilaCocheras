using System;
using System.Collections.Generic;
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
                //Si tuviera los datos en la bd hago un get por idcochera para obtener todos los datos..
                #region datosPruebaVisualizar
                txtFechaInicio.Text = "10/05/2016";
                txtFechaFin.Text = "20/05/2016";
                txtHorarioInicio.Text = "08:00";
                txtHorarioFin.Text = "17:00";
                lblPrecioHora.Text = "20";
                lblPrecioTotal.Text = "$ 1800";
                lblUbicacion.Text = "HAEDO";
                #endregion
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
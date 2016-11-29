using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using AlquilaCocheras;

namespace AlquilaCocheras.Web.propietarios
{
    public partial class cocheras : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Para que siempre pueda editar la fecha de inicio
                esEdicion.Value = "true";
            }
        }

        protected void btnCrearCochera_Click(object sender, EventArgs e)
        {
            TP_20162CEntities dc = new TP_20162CEntities();
            List<LoginDTO> user = (List<LoginDTO>)Session["UsuarioLogueado"];

            foreach (ListItem li in lbTipoVehiculo.Items)
            {
                if (li.Selected)
                {                    
                    Cocheras objc = new Cocheras();
                    objc.IdPropietario = user.First().IdUsuario;
                    objc.Ubicacion = txtUbicacion.Text.Trim();
                    objc.FechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
                    objc.FechaFin = Convert.ToDateTime(txtFechaFin.Text);
                    objc.HoraInicio = txtHorarioInicio.Text.Trim();
                    objc.HoraFin = txtHorarioFin.Text.Trim();
                    objc.Descripcion = "(" + li.Text + ")-" + txtDescripcion.Text.Trim();
                    objc.Latitud = Convert.ToDecimal(txtLatitud.Text);
                    objc.Longitud = Convert.ToDecimal(txtLongitud.Text);
                    objc.TipoVehiculo = (short)Convert.ToInt32(li.Value);
                    objc.MetrosCuadrados = Convert.ToInt32(txtMetrosCuadrados.Text.Trim());
                    objc.Precio = Convert.ToDecimal(txtPrecioHora.Text.Trim());
                    objc.Imagen = fuFoto.FileName;

                    dc.Cocheras.Add(objc);
                    dc.SaveChanges();

                    if (fuFoto.HasFile)
                    {
                        string directorio = Server.MapPath(System.Configuration.ConfigurationManager.AppSettings["pathFotosCocheras"].ToString());
                        string FileNameNEW = "cochera" + objc.IdCochera.ToString() + ".png";
                        string archivoNEW = directorio + FileNameNEW;
                        fuFoto.SaveAs(archivoNEW);

                        //Actualizo el archivo en la base con el id del ultimo insertado
                        objc.IdCochera = objc.IdCochera;
                        objc.Imagen = "/imagenes/" + FileNameNEW;
                        dc.Cocheras.Add(objc);

                        dc.Entry(objc).State = System.Data.Entity.EntityState.Modified;

                        dc.SaveChanges();
                    } 
                }
            }
            
            //LimpiaControles
            ScriptManager.RegisterStartupScript(this, this.GetType(), "clearAll", "LimpiaControles();", true);
            
            lblResultado.Text = "Operacion Exitosa";

        }
    }
}
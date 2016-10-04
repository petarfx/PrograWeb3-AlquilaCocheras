using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            LinkButton button = (LinkButton)ucBuscador.FindControl("btnFiltrar");
            //wire up event handler
            button.Click += new EventHandler(button_Click);
            base.OnInit(e);
        }

        void button_Click(object sender, EventArgs e)
        {
            ucBuscador.myResultado = "";
            if (ucBuscador.myUbicacion == "SAN JUSTO")
            {
                ucBuscador.myResultado = "No se encontraron resultados";
            }
            if (ucBuscador.myUbicacion == "HAEDO")
            {
                //Haria el get a la base, lo asigno a un datatable, y lo bindeo a la grilla
            }
            
        }

    }
}
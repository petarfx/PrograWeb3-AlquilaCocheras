using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlquilaCocheras.Web
{
    public partial class ucBuscador : System.Web.UI.UserControl
    {
        //"label1"
        public string mylabel1
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
            
    //"txtUbicacion"    
        public string myUbicacion
        {
            get { return txtUbicacion.Text; }
            set { txtUbicacion.Text = value; }
        }
        //"label2"
        public string mylabel2
        {
            get { return label2.Text; }
            set { label2.Text = value; }
        }
    //"txtFechaInicio"
        public string myFechaInicio
        {
            get { return txtFechaInicio.Text; }
            set { txtFechaInicio.Text = value; }
        }
    //"txtFechaFin"
        public string myFechaFin
        {
            get { return txtFechaFin.Text; }
            set { txtFechaFin.Text = value; }
        }
    //"btnFiltrar"
        public Button myFiltrar
        {
            get { return btnFiltrar; }
            //set { btnFiltrar.Text = value; }
        }
    //"lblResultado"
        public string myResultado
        {
            get { return lblResultado.Text; }
            set { lblResultado.Text = value; }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AlquilaCocheras.Web
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                        
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            lblResultado.Text = string.Empty;
            if (txtEmail.Text == "cliente@gmail.com" && txtContrasenia.Text == "Password1")
            {
                //Cliente OK
                Response.Redirect("clientes/reservas.aspx");
            }
            else if (txtEmail.Text == "propietario@gmail.com" && txtContrasenia.Text == "Password1")
            {
                //Propietario OK
                Response.Redirect("propietarios/reservas.aspx");
            }
            else
            {
                lblResultado.Text = "Usuario y/o Contraseña inválidos";
            }
        }

    }
}
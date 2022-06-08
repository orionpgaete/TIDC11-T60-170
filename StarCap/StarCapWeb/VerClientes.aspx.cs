﻿using StarCapModel;
using StarCapModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StarCapWeb
{
    public partial class VerClientes : System.Web.UI.Page
    {
        private IClientesDAL clienteDAL = new ClientesDALObjetos();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargaGrilla();
            }
        }

        private void cargaGrilla()
        {
            List<Cliente> clientes = clienteDAL.Obtener();
            this.grillaClientes.DataSource = clientes;
            this.grillaClientes.DataBind();
        }

        protected void grillaClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "eliminar")
            {
                //significa que el usuario apreto el boton eliminar
                //por tanto, tengo que eliminar el cliente
                string rut = Convert.ToString(e.CommandArgument);
                clienteDAL.Eliminar(rut);
                cargaGrilla();
            }
        }
    }
}
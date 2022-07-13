using EventosModel;
using EventosModel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EventosWEB
{
    public partial class MostrarAsistente : System.Web.UI.Page
    {
        private IAsistentesDAL asistentesDAL = new AsistenteDALDB();

        private void cargaGrilla(List<Asistente> asistentes)
        {
            this.grillaAsistente.DataSource = asistentes;
            this.grillaAsistente.DataBind();
        }

        private void cargaGrilla()
        {
            List<Asistente> asistentes;
            if (this.todosChk.Checked)
            {
                asistentes = this.asistentesDAL.ObtenerAsistentes();
            }
            else
            {
                asistentes = this.asistentesDAL.ObtenerAsistentes(this.estadoDDL.SelectedItem.Value);
            }
            this.cargaGrilla(asistentes);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.cargaGrilla();
            }
        }

        protected void estadoDDL_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.cargaGrilla();
        }

        protected void todosChk_CheckedChanged(object sender, EventArgs e)
        {
            this.estadoDDL.Enabled = !this.todosChk.Checked;
            this.cargaGrilla();
        }

        protected void grillaAsistente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if(e.CommandName == "eliminar")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                this.asistentesDAL.EliminarAsistente(id);
                this.cargaGrilla();
            }
        }
    }
}
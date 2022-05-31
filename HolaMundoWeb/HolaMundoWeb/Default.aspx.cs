using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HolaMundoWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void saludarBtn_Click(object sender, EventArgs e)
        {
            string nombre = this.nombreTxt.Text.Trim();

            this.mensajeH1.InnerHtml = "Hola "+ nombre + " , para de faltar a clases";
        }
    }
}
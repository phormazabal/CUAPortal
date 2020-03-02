using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.BO;
using PortalPrivado.DAO;
namespace PortalPrivado.Web
{
    public partial class Vinculado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                String cadena;
                String[] master = Utilidades.Seguridad.DesEncriptarSap(Request.QueryString["r"], out cadena);
                HttpContext context = HttpContext.Current;
                String Nombre = (String)context.Items["Nombre"];
                String RutMaster = master[3];
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
                HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                hdtipo.Value = "V";
                String RutVincu = (String)context.Items["RutVincu"];
                lbVinculado.Text = master[7];
                Paciente pac = new Paciente();
                PacienteDao pacDao = new PacienteDao();
                pac = pacDao.GetPaciente(RutMaster);
                Literal1.Text = " " + pac.Nombre + " " + pac.Apellidos;
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Paciente vinculado >";
                
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }
    }
}
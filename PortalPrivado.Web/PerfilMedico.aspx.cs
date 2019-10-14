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
    public partial class PerfilMedico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpContext context;
                context = HttpContext.Current;
                Medicos medico = new Medicos();
                List<Agenda> agenda = new List<Agenda>();
                medico = (Medicos)context.Items["Medico"];
                agenda = (List<Agenda>)context.Items["lstbusqueda"];
                //ViewState["Medico"] = medico;
                ViewState["lstbusqueda"] = agenda;
                String Fecha = (String)context.Items["Fecha"];
                String dia = Fecha.Substring(0, 2) + "/" + Fecha.Substring(2,2) + "/" + Fecha.Substring(4, 4);
                String hora = Fecha.Substring(8, 2) + ":" + Fecha.Substring(10, 2);
                lbActividadDoc.Text = medico.Value[0].ActividadDocente;
                lbArea.Text = medico.Value[0].AreaInvestigacion;
                lbAreaInteres.Text = medico.Value[0].AreaInteres;
                lbDetalle.Text = medico.Value[0].MiniBiografia;
                lbEspecialidad.Text = "";
                lbIdiomas.Text = medico.Value[0].IdiomasAtencion;
                lbSubEsp.Text = "";
                lbUbicacion.Text = medico.Value[0].UbicacionConsulta;
                imgDr.ImageUrl = medico.Value[0].oImagenes.Url;
                lbFecha.Text = dia;
                lbHora.Text = hora;
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            HttpContext context;
            context = HttpContext.Current;
            List<Agenda> agendas = new List<Agenda>();
            agendas = (List<Agenda>)ViewState["lstbusqueda"];
            context.Items.Add("lstbusqueda", agendas);
            Server.Transfer("Reserva2.aspx");
        }
    }
}
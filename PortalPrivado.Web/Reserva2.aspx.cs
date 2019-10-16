using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.DAO;
using PortalPrivado.BO;
namespace PortalPrivado.Web
{
    public partial class Reserva2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpContext context;
                context = HttpContext.Current;
                List<Agenda> agendas = new List<Agenda>();
                agendas = (List<Agenda>)context.Items["lstbusqueda"];
                MedicoDao oMedicoDao = new MedicoDao();
                Medicos oMedico = new Medicos();
                oMedico = oMedicoDao.GetMedico(agendas[0].RutMed);
                ViewState["Medico"] = oMedico;
                ViewState["Fecha"] = agendas[0].Fecha;
                ViewState["lstbusqueda"] = agendas;
                MedicoImagenes oImg = new MedicoImagenes();
                oImg = oMedico.Value[0].oImagenes;
                ImgDr.ImageUrl = oImg.Url;
                lbNombre.Text = oMedico.Value[0].Nombres + " " + oMedico.Value[0].Apellidos;
                rpEspecialidades.DataSource = agendas;
                rpEspecialidades.DataBind();
            }
        }

        protected void lkVerPerfil_Click(object sender, EventArgs e)
        {
            HttpContext context;
            context = HttpContext.Current;
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["Medico"];
            String Fecha = (String)ViewState["Fecha"];
            List<Agenda> agendas = new List<Agenda>();
            agendas = (List<Agenda>)ViewState["lstbusqueda"];
            context.Items.Add("Medico", medico);
            context.Items.Add("Fecha",Fecha);
            context.Items.Add("lstbusqueda",agendas);
            Server.Transfer("PerfilMedico.aspx");
        }
        protected void hpVerAgenda(object sender, EventArgs e)
        {
            
            HttpContext context;
            context = HttpContext.Current;
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["Medico"];
            String Fecha = (String)ViewState["Fecha"];
            List<Agenda> agendas = new List<Agenda>();
            agendas = (List<Agenda>)ViewState["lstbusqueda"];
            context.Items.Add("Medico", medico);
            context.Items.Add("Fecha", Fecha);
            context.Items.Add("lstbusqueda", agendas);
            Server.Transfer("DetalleAgenda.aspx");
        }
    }
}
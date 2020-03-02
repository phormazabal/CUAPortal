using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.DAO;
using PortalPrivado.BO;
namespace PortalPrivado.Web.publica
{
    public partial class Agendas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["vma"] == null)
                {
                    List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                    Medicos oMedico = new Medicos();
                    HttpContext context = HttpContext.Current;
                    lstbusqueda = (List<BO.Agenda>)context.Items["Agendas"];
                    oMedico = (Medicos)context.Items["Medico"];
                    ViewState["medico"] = oMedico;
                    ViewState["Fecha"] = lstbusqueda[1].Fecha;
                    ViewState["Agenda"] = lstbusqueda[1];
                    ViewState["Agendas"] = lstbusqueda;
                    ViewState["IdEspecialidad"] = lstbusqueda[0].Id_especialidad;
                    ViewState["Especialidad"] = lstbusqueda[0].Especialidad;
                    ViewState["IdEspecialidad1"] = lstbusqueda[1].Id_especialidad;
                    ViewState["Especialidad1"] = lstbusqueda[1].Especialidad;
                    lbNombre.Text = oMedico.Value[0].Nombres + " " + oMedico.Value[0].Apellidos;
                    lbEspecialidad1.Text = lstbusqueda[0].Especialidad;
                    lbEspecialidad2.Text = lstbusqueda[1].Especialidad;
                    imgDoctor.ImageUrl = oMedico.Value[0].oImagenes.Url;
                    ViewState["AgendaMed"] = lstbusqueda;
                }
                else
                {
                    AgendaDao AgendaDao = new AgendaDao();
                    String vma = Request.QueryString["vma"];
                    List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                    lstbusqueda = AgendaDao.GetAgenda("",vma);
                    MedicoDao oMedicoDao = new MedicoDao();
                    Medicos oMedico = new Medicos();
                    oMedico = oMedicoDao.GetMedico(lstbusqueda[0].RutMed);
                    ViewState["medico"] = oMedico;
                    ViewState["Fecha"] = lstbusqueda[1].Fecha;
                    ViewState["Agenda"] = lstbusqueda[1];
                    ViewState["Agendas"] = lstbusqueda;
                    ViewState["IdEspecialidad"] = lstbusqueda[0].Id_especialidad;
                    ViewState["Especialidad"] = lstbusqueda[0].Especialidad;
                    ViewState["IdEspecialidad1"] = lstbusqueda[1].Id_especialidad;
                    ViewState["Especialidad1"] = lstbusqueda[1].Especialidad;
                    lbNombre.Text = oMedico.Value[0].Nombres + " " + oMedico.Value[0].Apellidos;
                    lbEspecialidad1.Text = lstbusqueda[0].Especialidad;
                    lbEspecialidad2.Text = lstbusqueda[1].Especialidad;
                    imgDoctor.ImageUrl = oMedico.Value[0].oImagenes.Url;
                    ViewState["AgendaMed"] = lstbusqueda;
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
           
        }

        protected void lnkEsp1_Click(object sender, EventArgs e)
        {
            HttpContext context;
            context = HttpContext.Current;
            AgendaDao AgendaDao = new AgendaDao();
            List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
            lstbusqueda = (List<BO.Agenda>)ViewState["AgendaMed"];            
            Medicos oMedico = new Medicos();
            oMedico = (Medicos)ViewState["medico"];
            context.Items.Add("Medico", oMedico);
            context.Items.Add("Fecha", lstbusqueda[0].Fecha);
            context.Items.Add("Agenda", lstbusqueda[0]);
            Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
            Context.Items.Add("Especialidad", ViewState["Especialidad"]);            
            context.Items.Add("Agendas", ViewState["Agendas"]);
            context.Items.Add("origen", "1");
            Server.Transfer("DetallePublic.aspx");
        }

        protected void lnkEsp2_Click(object sender, EventArgs e)
        {
            HttpContext context;
            context = HttpContext.Current;
            AgendaDao AgendaDao = new AgendaDao();
            List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
            lstbusqueda = (List<BO.Agenda>)ViewState["AgendaMed"];
            Medicos oMedico = new Medicos();
            oMedico = (Medicos)ViewState["medico"];
            context.Items.Add("Medico", oMedico);
            context.Items.Add("Fecha", lstbusqueda[1].Fecha);
            context.Items.Add("Agenda", lstbusqueda[1]);
            Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad1"]);
            Context.Items.Add("Especialidad", ViewState["Especialidad1"]);
            context.Items.Add("Agendas", ViewState["Agendas"]);
            context.Items.Add("origen", "1");    
            Server.Transfer("DetallePublic.aspx");
        }

        protected void lkVerPerfil_Click(object sender, EventArgs e)
        {
            HttpContext context;
            context = HttpContext.Current;
            context.Items.Add("Medico", (Medicos)ViewState["medico"]);
            context.Items.Add("Fecha", (String)ViewState["Fecha"]);
            context.Items.Add("Agenda", (BO.Agenda)ViewState["Agenda"]);
            Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
            Context.Items.Add("Especialidad", ViewState["Especialidad"]);
            Context.Items.Add("IdEspecialidad1", ViewState["IdEspecialidad"]);
            Context.Items.Add("Especialidad1", ViewState["Especialidad1"]);
            context.Items.Add("origen", "5");
            Server.Transfer("PerfilPublic.aspx");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.BO;
using PortalPrivado.DAO;
namespace PortalPrivado.Web.publica
{
    public partial class Especialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id"] == null)
                {
                    Label1.Attributes.Add("onclick", "javascript:ActivarPostClickAceptar();" + Page.ClientScript.GetPostBackEventReference(this.Label1, string.Empty) + ";");
                    LinkButton3_ModalPopupExtender.Hide();
                    HttpContext context = HttpContext.Current;
                    List<Medicos> lstMedicos = new List<Medicos>();
                    lstMedicos = (List<Medicos>)context.Items["Medicos"];
                    ViewState["lstMedicos"] = lstMedicos;
                    lbEspecialidad.Text = (String)context.Items["Especialidad"];
                    List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                    ViewState["Agendas"] = (List<BO.Agenda>)context.Items["Agendas"];
                    ViewState["Medicos"] = lstMedicos;
                    hdIdEspcialidad.Value = string.Format("{0,10:G}", Convert.ToInt32((String)context.Items["IdEspecialidad"])).Trim();
                    MedicoDao medicoDao = new MedicoDao();
                    List<BO.Especialidad> lstSub = new List<BO.Especialidad>();
                    lstSub = medicoDao.lstSubEsp(hdIdEspcialidad.Value);
                    if (lstSub.Count > 1)
                    {
                        dpSub.DataSource = lstSub;
                        dpSub.DataValueField = "CodEsp";
                        dpSub.DataTextField = "Glosa";
                    }
                    else
                    {
                        lbFiltros.Visible = false;
                        dpSub.Visible = false;
                    }
                    dpSub.DataBind();
                    lbCantidad.Text = " " + lstMedicos.Count.ToString() + " ";
                    DataList2.DataSource = lstMedicos;
                    DataList2.DataBind();
                    ViewState["lstmedicos"] = lstMedicos;
                }
                else
                {
                    String idEspecialidad = Request.QueryString["Id"];
                    String Especialidad = Request.QueryString["Especialidad"];
                    AgendaDao AgendaDao = new AgendaDao();
                    List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                    List<Medicos> lstMedicos = new List<Medicos>();
                    MedicoDao oMedicoDao = new MedicoDao();
                    CultureInfo ci = new CultureInfo("Es-Es");
                    lstbusqueda = AgendaDao.GetAgenda(idEspecialidad, "");
                    for (int i = 0; i < lstbusqueda.Count; i++)
                    {
                        Medicos medico = new Medicos();
                        medico = oMedicoDao.GetMedico(lstbusqueda[i].RutMed);
                        medico.FechaServ = lstbusqueda[i].Fecha;
                        DateTime FechaPaso = DateTime.Parse(lstbusqueda[i].Fecha.Substring(0, 2) + "/" + lstbusqueda[i].Fecha.Substring(2, 2) + "/" + lstbusqueda[i].Fecha.Substring(4, 4));
                        medico.Fecha = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(FechaPaso.DayOfWeek)) + " " + FechaPaso.ToString("dd/MM/yyyy")
                            + " " + lstbusqueda[i].Fecha.Substring(8, 2) + ":" + lstbusqueda[i].Fecha.Substring(10, 2) + " hrs";
                        medico.Especialidad = lstbusqueda[i].Especialidad;
                        medico.IdEspecialidad = lstbusqueda[i].Id_especialidad;
                        medico.IdMedico = lstbusqueda[i].Id_medico;
                        lstMedicos.Add(medico);
                    }
                    ViewState["lstMedicos"] = lstMedicos;
                    lbEspecialidad.Text = Especialidad;
                    ViewState["Agendas"] = lstbusqueda;
                    ViewState["Medicos"] = lstMedicos;
                    hdIdEspcialidad.Value = string.Format("{0,10:G}", Convert.ToInt32(idEspecialidad)).Trim();
                    List<BO.Especialidad> lstSub = new List<BO.Especialidad>();
                    lstSub = oMedicoDao.lstSubEsp(hdIdEspcialidad.Value);
                    if (lstSub.Count > 1)
                    {
                        dpSub.DataSource = lstSub;
                        dpSub.DataValueField = "CodEsp";
                        dpSub.DataTextField = "Glosa";
                    }
                    else
                    {
                        lbFiltros.Visible = false;
                        dpSub.Visible = false;
                    }
                    dpSub.DataBind();
                    lbCantidad.Text = " " + lstMedicos.Count.ToString() + " ";
                    DataList2.DataSource = lstMedicos;
                    DataList2.DataBind();
                    ViewState["lstmedicos"] = lstMedicos;
                }
            }
           
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
            Context.Items.Add("Agendas", ViewState["Agendas"]);
            Context.Items.Add("Especialidad", lbEspecialidad.Text);
            Context.Items.Add("Medicos", ViewState["lstMedicos"]);
            Context.Items.Add("medico", ViewState["medico"]);
            Context.Items.Add("origen", "4a");
            Context.Items.Add("Agenda", ViewState["Agenda"]);
            Context.Items.Add("Cita", ViewState["Cita"]);
            Server.Transfer("Confirmacion.aspx");
        }

        protected void DataList2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            HttpContext context = HttpContext.Current;            
            HiddenField hdId = (HiddenField)e.Item.FindControl("hdIdMed");
            String IdMedico = hdId.Value;
            List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
            lstbusqueda = (List<BO.Agenda>)ViewState["Agendas"];
            BO.Agenda agenda = new BO.Agenda();            
            List<Medicos> lstMedicos = new List<Medicos>();
            lstMedicos = (List<Medicos>)ViewState["Medicos"];
            Medicos medico = new Medicos();
            String particularidad;
            medico = lstMedicos.Find(x => x.IdMedico == IdMedico);
            MedicoDao medDao = new MedicoDao();
            switch (e.CommandName)
            {
                case "ReservaDirecta":                    
                    List<DispoDiaria> lst = new List<DispoDiaria>();
                    lst = medDao.GetDisponibilidadDiaria(Convert.ToInt32(IdMedico.TrimEnd(' ')).ToString(), medico.FechaServ.Substring(0, 8), medico.IdEspecialidad);                   
                    Cita cita = new Cita();
                    cita.Utratamiento = lst[0].Utratamiento;
                    cita.Horareserva = medico.FechaServ.Substring(8, 4);
                    cita.Medico = IdMedico;
                    cita.Especialidad = medico.IdEspecialidad;                   
                    cita.Codorigen = "1";                    
                    cita.Fecreserva = medico.FechaServ.Substring(0, 8);                    
                    BO.Agenda agendas = new BO.Agenda();
                    agendas.NombreMed = medico.Value[0].Nombres;
                    agendas.Apepat = medico.Value[0].Apellidos;
                    agendas.Especialidad = lbEspecialidad.Text;
                    if (medDao.GetParti(medico.IdEspecialidad, medico.IdMedico.Trim(' '), out particularidad))
                    {
                        ViewState["IdEspecialidad"] = hdIdEspcialidad.Value;
                        ViewState["Agendas"] = lstbusqueda;
                        ViewState["medico"] = medico;
                        ViewState["Agenda"] = agendas;
                        ViewState["Cita"] = cita;
                        lbParti.Text = particularidad;
                        pnPop.Visible = true;
                        //LinkButton3_ModalPopupExtender.Show();
                    }
                    else
                    {
                        Context.Items.Add("IdEspecialidad", hdIdEspcialidad.Value);
                        Context.Items.Add("Agendas", lstbusqueda);
                        Context.Items.Add("Especialidad", lbEspecialidad.Text);
                        context.Items.Add("Medicos", ViewState["lstMedicos"]);
                        context.Items.Add("medico", medico);
                        context.Items.Add("origen", "4a");
                        context.Items.Add("Agenda", agendas);
                        context.Items.Add("Cita", cita);
                        Server.Transfer("Confirmacion.aspx");
                    }
                    break;
                case "VerAgenda":

                    agenda = lstbusqueda.Find(x => x.Id_medico == IdMedico);
                    //oMedico = lstMedicos.Find(x => x.IdMedico == IdMedico);
                        //oMedicoDao.GetMedico(agenda.RutMed);
                    context.Items.Add("IdEspecialidad", hdIdEspcialidad.Value);
                    Context.Items.Add("Agendas", lstbusqueda);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Medico", medico);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("origen", "4");
                    Server.Transfer("DetallePublic.aspx");
                    break;
                case "VerPerfil":
                    agenda = lstbusqueda.Find(x => x.Id_medico == IdMedico);
                    //oMedico = oMedicoDao.GetMedico(agenda.RutMed);
                    context.Items.Add("IdEspecialidad", hdIdEspcialidad.Value);
                    Context.Items.Add("Agendas", lstbusqueda);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Medico", medico);                    
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("origen", "4");
                    Server.Transfer("PerfilPublic.aspx");
                    break;
            }
        }
        protected void DataList2_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            AgendaDao oAgendaDao = new AgendaDao();
            List<Medicos> lstMedicos = new List<Medicos>();
            List<BO.Agenda> lstAgenda = new List<BO.Agenda>();           
            lstMedicos = (List<Medicos>)ViewState["lstmedicos"];
            CultureInfo ci = new CultureInfo("Es-Es");
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            for (int i = e.StartRowIndex; i < (e.StartRowIndex + e.MaximumRows) && i < lstMedicos.Count; i++)
            {
                String IdMedico = Convert.ToInt32(lstMedicos[i].IdMedico).ToString();
                lstAgenda = oAgendaDao.GetAgenda("", IdMedico);
                DateTime FechaPaso = DateTime.Parse(lstAgenda[0].Fecha.Substring(0, 2) + "/" + lstAgenda[0].Fecha.Substring(2, 2) + "/" + lstAgenda[0].Fecha.Substring(4, 4));
                lstMedicos[i].Fecha = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(FechaPaso.DayOfWeek)) + " " + FechaPaso.ToString("dd/MM/yyyy")
                    + " " + lstAgenda[0].Fecha.Substring(8, 2) + ":" + lstAgenda[0].Fecha.Substring(10, 2) + " hrs";
                lstMedicos[i].FechaServ = lstAgenda[0].Fecha;
                lstMedicos[i].Especialidad = lstAgenda[0].Especialidad; 
            }
            //ViewState["Medicos"] = lstMedicos;          
            DataList2.DataSource = lstMedicos;
            DataList2.DataBind();
            //DataPager1.DataBind();
           
        }
        protected void dpSub_SelectedIndexChanged(object sender, EventArgs e)
        {           
            MedicoDao medDao = new MedicoDao();
            AgendaDao oAgenda = new AgendaDao();
            CultureInfo ci = new CultureInfo("Es-Es");
            List<String> lst = new List<String>();
            List<BO.Agenda> lstAgenda = new List<BO.Agenda>();
            lst = medDao.lstMedSub(dpSub.SelectedValue);
            List<Medicos> lstMedicos = new List<Medicos>();
            lstMedicos = (List<Medicos>)ViewState["Medicos"];
            if (!dpSub.SelectedValue.Equals("0") || (lst.Count != 0))
            {                
                List<Medicos> lstMedicosSub = new List<Medicos>();               
                for (int i = 0; i < lst.Count; i++)
                {
                    Medicos medico = new Medicos();
                    medico = lstMedicos.Find(x => x.Value[0].Rut.Equals(lst[i].ToLower()));                    
                    if (medico != null)
                    {
                        lstAgenda = oAgenda.GetAgenda("", Convert.ToInt32(medico.IdMedico).ToString());
                        medico.FechaServ = lstAgenda[0].Fecha;
                        DateTime FechaPaso = DateTime.Parse(lstAgenda[0].Fecha.Substring(0, 2) + "/" + lstAgenda[0].Fecha.Substring(2, 2) + "/" + lstAgenda[0].Fecha.Substring(4, 4));
                        medico.Fecha = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(FechaPaso.DayOfWeek)) + " " + FechaPaso.ToString("dd/MM/yyyy")
                            + " " + lstAgenda[0].Fecha.Substring(8, 2) + ":" + lstAgenda[0].Fecha.Substring(10, 2) + " hrs";
                        medico.Especialidad = lstAgenda[0].Especialidad;
                        lstMedicosSub.Add(medico);
                    }
                }                
                DataList2.DataSource = lstMedicosSub;
                DataList2.DataBind();
                //DataPager1.DataBind();
            }
            else
            {
                DataList2.DataSource = lstMedicos;
                DataList2.DataBind();
                //DataPager1.DataBind();
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("buscar.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            pnPop.Visible = false;
            LinkButton3_ModalPopupExtender.Hide();
        }
    }
}
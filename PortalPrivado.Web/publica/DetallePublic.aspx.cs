using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.DAO;
using PortalPrivado.BO;
using System.Globalization;

namespace PortalPrivado.Web.publica
{
    public partial class DetallePublic : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Label1.Attributes.Add("onclick", "javascript:ActivarPostClickAceptar();" + Page.ClientScript.GetPostBackEventReference(this.Label1, string.Empty) + ";");
                //LinkButton3_ModalPopupExtender.Hide();
                HttpContext context;
                context = HttpContext.Current;
                BO.Agenda agendas = new BO.Agenda();
                if (Request.QueryString["vma"] == null)
                {
                    agendas = (BO.Agenda)context.Items["Agenda"];
                    ViewState["origen"] = (String)context.Items["origen"];
                    ViewState["IdEspecialidad"] = (String)context.Items["IdEspecialidad"];
                    ViewState["Especialidad"] = (String)context.Items["Especialidad"];
                    List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                    lstbusqueda = (List<BO.Agenda>)context.Items["Agendas"];
                    ViewState["Agendas"] = lstbusqueda;
                    List<Medicos> lstMedicos = (List<Medicos>)context.Items["Medicos"];
                    ViewState["lstMedicos"] = lstMedicos;
                    Medicos medico = new Medicos();                    
                    medico = (Medicos)context.Items["Medico"];
                    ViewState["lstmedicos"] = lstbusqueda;
                    DateTime fechaAgenda =  DateTime.Parse(medico.FechaServ.Substring(0, 2) + "-" + medico.FechaServ.Substring(2, 2) + "-" + medico.FechaServ.Substring(4, 4));
                                            //DateTime.Parse(agendas.Fecha.Substring(0, 2) + "-" + agendas.Fecha.Substring(2, 2) + "-" + agendas.Fecha.Substring(4, 4));
                    CultureInfo ci = new CultureInfo("Es-Es");
                    lbFecha.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(fechaAgenda.DayOfWeek) + " " + fechaAgenda.Day) + " de " +
                        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetMonthName(fechaAgenda.Month) + " " + fechaAgenda.Year);
                    MedicoDao oMedicoDao = new MedicoDao();
                    ViewState["medico"] = medico;
                    ViewState["Agenda"] = agendas;
                    ImgDr.ImageUrl = medico.Value[0].oImagenes.Url;
                    lbNombre.Text = medico.Value[0].Nombres + " " + medico.Value[0].Apellidos;
                    String fecha = medico.FechaServ.Substring(0, 8);
                    ViewState["Fecha"] = medico.FechaServ;
                    List<DispoDiaria> lstDis = new List<DispoDiaria>();
                    lstDis = oMedicoDao.GetDisponibilidadDiaria(medico.Value[0].VMA, fecha, agendas.Id_especialidad);
                    dlDisHora.DataSource = lstDis;
                    dlDisHora.DataBind();
                    List<String> lstMes = new List<string>();
                    lstMes = oMedicoDao.GetDisponibilidadMensual("01" + medico.FechaServ.Substring(2, 6), medico.Value[0].VMA);
                    calendar.VisibleDate = new DateTime(int.Parse(lstMes[0].Substring(4, 4)), int.Parse(lstMes[0].Substring(2, 2)), 01);
                    calendar.SelectedDate = new DateTime(int.Parse(medico.FechaServ.Substring(4, 4)),
                           int.Parse(medico.FechaServ.Substring(2, 2)), int.Parse(medico.FechaServ.Substring(0, 2)));                    
                    ViewState["Mes"] = lstMes;
                    lbEspecialidad.Text = medico.Especialidad;// agendas.Especialidad;
                }
                else
                {
                    AgendaDao AgendaDao = new AgendaDao();                    
                    String vma = Request.QueryString["vma"];
                    List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                    lstbusqueda = AgendaDao.GetAgenda("", vma);
                    agendas = lstbusqueda[0];
                    MedicoDao oMedicoDao = new MedicoDao();
                    Medicos oMedico = new Medicos();
                    oMedico = oMedicoDao.GetMedico(lstbusqueda[0].RutMed);
                    ViewState["origen"] = "3";
                    ViewState["IdEspecialidad"] = lstbusqueda[0].Id_especialidad;
                    ViewState["Especialidad"] = lstbusqueda[0].Especialidad;
                    ViewState["Agendas"] = lstbusqueda;                    
                    ViewState["lstmedicos"] = lstbusqueda;
                    DateTime fechaAgenda = DateTime.Parse(agendas.Fecha.Substring(0, 2) + "-" + agendas.Fecha.Substring(2, 2) + "-" + agendas.Fecha.Substring(4, 4));
                    CultureInfo ci = new CultureInfo("Es-Es");
                    lbFecha.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(fechaAgenda.DayOfWeek) + " " + fechaAgenda.Day) + " de " +
                        CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetMonthName(fechaAgenda.Month) + " " + fechaAgenda.Year);
                    
                    ViewState["medico"] = oMedico;
                    ViewState["Agenda"] = agendas;
                    ImgDr.ImageUrl = oMedico.Value[0].oImagenes.Url;
                    lbNombre.Text = oMedico.Value[0].Nombres + " " + oMedico.Value[0].Apellidos;
                    String fecha = agendas.Fecha.Substring(0, 8);
                    ViewState["Fecha"] = agendas.Fecha;
                    List<DispoDiaria> lstDis = new List<DispoDiaria>();
                    lstDis = oMedicoDao.GetDisponibilidadDiaria(oMedico.Value[0].VMA, fecha, agendas.Id_especialidad);
                    dlDisHora.DataSource = lstDis;
                    dlDisHora.DataBind();
                    List<String> lstMes = new List<string>();
                    lstMes = oMedicoDao.GetDisponibilidadMensual("01" + agendas.Fecha.Substring(2, 6), oMedico.Value[0].VMA);
                    calendar.VisibleDate = new DateTime(int.Parse(lstMes[0].Substring(4, 4)), int.Parse(lstMes[0].Substring(2, 2)), 01);
                    calendar.SelectedDate = new DateTime(int.Parse(agendas.Fecha.Substring(4, 4)),
                           int.Parse(agendas.Fecha.Substring(2, 2)), int.Parse(agendas.Fecha.Substring(0, 2))); 
                    
                    ViewState["Mes"] = lstMes;
                    lbEspecialidad.Text = agendas.Especialidad;
                }
            }
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            
            List<String> lstMes = new List<string>();
            lstMes = (List<String>)ViewState["Mes"];
            e.Cell.BorderColor = System.Drawing.Color.Silver;
            for (int i = 0; i < lstMes.Count; i++)
            {
                if (e.Day.Date == new DateTime(int.Parse(lstMes[i].Substring(4, 4)),
                    int.Parse(lstMes[i].Substring(2, 2)), int.Parse(lstMes[i].Substring(0, 2))))
                {
                    e.Day.IsSelectable = true;
                    if (e.Day.Date != calendar.SelectedDate)
                        e.Cell.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
                }
            }
            if (e.Day.IsOtherMonth)
            {/* Si el día es de otro mes */
                e.Cell.Text = string.Empty;
                e.Cell.BackColor = System.Drawing.Color.FromArgb(232, 232, 232);
            }
        }
        protected void calendar_select(object sender, DayRenderEventArgs e)
        {

        }

        protected void calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {

            DateTime fecha = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            if (e.NewDate >= fecha)
            {
                MedicoDao oMedicoDao = new MedicoDao();
                Medicos medico = new Medicos();
                medico = (Medicos)ViewState["medico"];
                List<String> lstMes = new List<string>();
                lstMes = oMedicoDao.GetDisponibilidadMensual("01" + e.NewDate.ToString("MMyyyy"), medico.Value[0].VMA);               
                ViewState["Mes"] = lstMes;
            }
            else
            {
                calendar.VisibleDate = e.PreviousDate;
            }

        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            MedicoDao oMedicoDao = new MedicoDao();
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["medico"];
            List<DispoDiaria> lstDis = new List<DispoDiaria>();
            BO.Agenda agendas = new BO.Agenda();
            agendas = (BO.Agenda)ViewState["Agenda"];
            String fecha = calendar.SelectedDate.ToString("ddMMyyyy");
            DateTime fechaAgenda = calendar.SelectedDate;
            CultureInfo ci = new CultureInfo("Es-Es");
            lbFecha.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(fechaAgenda.DayOfWeek) + " " + fechaAgenda.Day) + " de " +
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetMonthName(fechaAgenda.Month) + " " + fechaAgenda.Year);
            lstDis = oMedicoDao.GetDisponibilidadDiaria(medico.Value[0].VMA, fecha, agendas.Id_especialidad);
            dlDisHora.DataSource = lstDis;
            dlDisHora.DataBind();
        }

        protected void dlDisHora_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            MedicoDao medicoDao = new MedicoDao();
            if (e.CommandName.Equals("R"))
            {
                Label lbHora = (Label)e.Item.FindControl("lbHora");
                HiddenField Uttrat = (HiddenField)e.Item.FindControl("hdUt");
                Cita cita = new Cita();
                Paciente pac = new Paciente();
                PacienteDao pacDao = new PacienteDao();
                BO.Agenda agendas = new BO.Agenda();
                agendas = (BO.Agenda)ViewState["Agenda"];
                String particularidad;
                cita.Utratamiento = Uttrat.Value;
                cita.Horareserva = lbHora.Text.Substring(0, 5);
                cita.Medico = agendas.Id_medico;
                cita.Especialidad = agendas.Id_especialidad;
                cita.Codorigen = (String)ViewState["origen"];                
                cita.Fecreserva = calendar.SelectedDate.ToString("ddMMyyyy");
                HttpContext context = HttpContext.Current;
                String origen = (String)ViewState["origen"];
                if (medicoDao.GetParti(agendas.Id_especialidad, agendas.Id_medico.Trim(' '), out particularidad))
                {
                    lbParti.Text = particularidad;
                    ViewState["Cita"] = cita;
                    ViewState["Agenda"] = agendas;
                    Panel1.Visible = true;
                    //LinkButton3_ModalPopupExtender.Show();

                }
                else
                {
                    //if (origen.Equals("1"))
                    //{
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    //}
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("origen", origen);
                    context.Items.Add("Agenda", agendas);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Confirmacion.aspx");
                }
            }
        }

        protected void lkVerPerfil_Click(object sender, EventArgs e)
        {

            HttpContext context = HttpContext.Current;
            String Fecha = (String)ViewState["Fecha"];
            string origen = (string)ViewState["origen"];
            BO.Agenda agendas = new BO.Agenda();
            agendas = (BO.Agenda)ViewState["Agenda"];
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["medico"];

            switch (origen)
            {
                case "1":
                    context.Items.Add("Medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("Agenda", (BO.Agenda)ViewState["Agenda"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("PerfilPublic.aspx");
                    break;
                case "2":                    
                    context.Items.Add("Medico", medico);
                    context.Items.Add("Fecha", Fecha);
                    context.Items.Add("Agenda", agendas);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("origen", "2");
                    Server.Transfer("PerfilPublic.aspx");
                    break;
                case "3":
                    context.Items.Add("Medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("Agenda", (BO.Agenda)ViewState["Agenda"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("origen", "3");
                    Server.Transfer("PerfilPublic.aspx");
                    break;
                case "4":
                    context.Items.Add("Medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("Agenda", (BO.Agenda)ViewState["Agenda"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "4d");
                    Server.Transfer("PerfilPublic.aspx");
                    break;
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string origen = (string)ViewState["origen"];           
            HttpContext context = HttpContext.Current;
            switch (origen)
            {
                case "1":                    
                    Medicos oMedico = new Medicos();
                    List<BO.Agenda> lst = new List<BO.Agenda>();
                    lst = (List<BO.Agenda>)ViewState["lstMedicos"];
                    oMedico = (Medicos)ViewState["medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("Agendas.aspx");
                    break;
                case "4":
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "4");
                    Server.Transfer("Especialidad.aspx");
                    break;
                case "2":               
                    Server.Transfer("Agenda.aspx");
                    break;                
                default:
                    Server.Transfer("Buscar.aspx");
                    break;
            }

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            //LinkButton3_ModalPopupExtender.Hide();
            Panel1.Visible = false;
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            String origen = (String)ViewState["origen"];
            Context.Items.Add("Agendas", ViewState["Agendas"]);
            Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
            Context.Items.Add("Especialidad", ViewState["Especialidad"]);
            context.Items.Add("Medicos", ViewState["lstMedicos"]);
            context.Items.Add("medico", (Medicos)ViewState["medico"]);
            context.Items.Add("Fecha", (String)ViewState["Fecha"]);
            context.Items.Add("Rut", (String)ViewState["Rut"]);
            context.Items.Add("origen", origen);
            context.Items.Add("Agenda", ViewState["Agenda"]);
            context.Items.Add("Cita", ViewState["Cita"]);
            Server.Transfer("Confirmacion.aspx");
        }
    }
}
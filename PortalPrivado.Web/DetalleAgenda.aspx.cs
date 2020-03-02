using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.BO;
using PortalPrivado.DAO;
namespace PortalPrivado.Web
{
    public partial class DetalleAgenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Label1.Attributes.Add("onclick", "javascript:ActivarPostClickAceptar();" + Page.ClientScript.GetPostBackEventReference(this.Label1, string.Empty) + ";");
                //LinkButton3_ModalPopupExtender.Hide();
                String cadena;
                String[] master = Utilidades.Seguridad.DesEncriptarSap(Request.QueryString["r"], out cadena);
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                HttpContext context;
                context = HttpContext.Current;
                Agenda agendas = new Agenda();
                agendas = (Agenda)context.Items["Agenda"];                
                ViewState["origen"] = (String)context.Items["origen"];
                ViewState["Rut"] = (String)context.Items["Rut"];
                ViewState["IdEspecialidad"] = (String)context.Items["IdEspecialidad"];
                ViewState["Especialidad"] = (String)context.Items["Especialidad"];
                List<Agenda> lstbusqueda = new List<Agenda>();
                lstbusqueda = (List<Agenda>)context.Items["Agendas"];
                ViewState["Agendas"] = lstbusqueda;
                List<Medicos> lstMedicos = (List<Medicos>)context.Items["Medicos"];
                ViewState["lstMedicos"] = lstMedicos;
                Medicos medico = new Medicos();
                medico = (Medicos)context.Items["Medico"];
                hdMaster.Value = Request.QueryString["r"];
                if (master.Length > 6)
                {
                    HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                    hdtipo.Value = "V";
                }
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Reserva de hora > Detalle Agenda >" ;    
                ViewState["lstmedicos"] = lstbusqueda;
                DateTime fechaAgenda = DateTime.Parse(agendas.Fecha.Substring(0, 2) + "-" + agendas.Fecha.Substring(2, 2) + "-" + agendas.Fecha.Substring(4, 4));
                CultureInfo ci = new CultureInfo("Es-Es");
                lbFecha.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(fechaAgenda.DayOfWeek) + " " + fechaAgenda.Day) + " de " +
                    CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetMonthName(fechaAgenda.Month) + " " + fechaAgenda.Year);
                MedicoDao oMedicoDao = new MedicoDao();
                ViewState["medico"] = medico;
                ViewState["Agenda"] = agendas;
                ImgDr.ImageUrl = medico.Value[0].oImagenes.Url;
                lbNombre.Text = medico.Value[0].Nombres + " " + medico.Value[0].Apellidos;
                String fecha = agendas.Fecha.Substring(0, 8);
                ViewState["Fecha"] = agendas.Fecha;
                List<DispoDiaria> lstDis = new List<DispoDiaria>();
                lstDis = oMedicoDao.GetDisponibilidadDiaria(medico.Value[0].VMA, fecha, agendas.Id_especialidad);
                dlDisHora.DataSource = lstDis;
                dlDisHora.DataBind();
                List<String> lstMes = new List<string>();
                lstMes = oMedicoDao.GetDisponibilidadMensual("01" + agendas.Fecha.Substring(2,6), medico.Value[0].VMA);
                calendar.VisibleDate  = new DateTime(int.Parse(lstMes[0].Substring(4,4)), int.Parse(lstMes[0].Substring(2, 2)), 01);
                calendar.SelectedDate = new DateTime(int.Parse(agendas.Fecha.Substring(4, 4)),
                       int.Parse(agendas.Fecha.Substring(2, 2)), int.Parse(agendas.Fecha.Substring(0, 2)));
                ViewState["Mes"] = lstMes;
                lbEspecialidad.Text = agendas.Especialidad;
                PacienteDao oPaciente = new PacienteDao();
                

            }
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            //MedicoDao oMedicoDao = new MedicoDao();
            List<String> lstMes = new List<string>();
            //Medicos medico = new Medicos();
            //medico = (Medicos)ViewState["medico"];
            lstMes = (List<String>)ViewState["Mes"];
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
            Agenda agendas = new Agenda();
            agendas = (Agenda)ViewState["Agenda"];
            String fecha = calendar.SelectedDate.ToString("ddMMyyyy");
            DateTime fechaAgenda = calendar.SelectedDate;
            CultureInfo ci = new CultureInfo("Es-Es");
            lbFecha.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(fechaAgenda.DayOfWeek) + " " + fechaAgenda.Day) + " de " +
                CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetMonthName(fechaAgenda.Month) + " " + fechaAgenda.Year) ;
            lstDis = oMedicoDao.GetDisponibilidadDiaria(medico.Value[0].VMA, fecha, agendas.Id_especialidad);
            dlDisHora.DataSource = lstDis;
            dlDisHora.DataBind();
        }

        protected void dlDisHora_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            MedicoDao medicoDao = new MedicoDao();
            if (e.CommandName.Equals("R"))
            { 
                Agenda agendas = new Agenda();
                agendas = (Agenda)ViewState["Agenda"];
                String particularidad;
                Label lbHora = (Label)e.Item.FindControl("lbHora");
                HiddenField Uttrat = (HiddenField)e.Item.FindControl("hdUt");
                Cita cita = new Cita();
                Paciente pac = new Paciente();
                PacienteDao pacDao = new PacienteDao();
                cita.Utratamiento = Uttrat.Value;
                cita.Horareserva = lbHora.Text.Substring(0, 5);
                cita.Medico = agendas.Id_medico;
                cita.Especialidad = agendas.Id_especialidad;
                cita.Rutpac = (String)ViewState["Rut"];
                cita.Rutsol = (String)ViewState["Rut"];
                pac = pacDao.GetPaciente(cita.Rutpac);
                cita.Codorigen = (String)ViewState["origen"];
                cita.Nompac = pac.Nombre;
                cita.Apepatpac = pac.Apellidos;
                cita.Fecreserva = calendar.SelectedDate.ToString("ddMMyyyy");
                cita.Mail = pac.Email;
                cita.Telefono = pac.Telefono1;
                HttpContext context = HttpContext.Current;
                String origen = (String)ViewState["origen"];
                if (medicoDao.GetParti(agendas.Id_especialidad, agendas.Id_medico.Trim(' '), out particularidad))
                {
                    lbParti.Text = particularidad;
                    ViewState["Cita"] = cita;
                    ViewState["Agenda"] = agendas;
                    pnModal.Visible = true;
                    
                    
                }
                else
                {
                    if (origen.Equals("2"))
                    {
                        Context.Items.Add("Agendas", ViewState["Agendas"]);
                        Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                        Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                        context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    }
                    HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("Rut", (String)ViewState["Rut"]);
                    context.Items.Add("origen", origen);
                    context.Items.Add("Agenda", agendas);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Confirmacion.aspx?r=" + hdMaster.Value);
                }
            }
        }

        protected void lkVerPerfil_Click(object sender, EventArgs e)
        {

            HttpContext context = HttpContext.Current;
            String Fecha = (String)ViewState["Fecha"];
            string origen = (string)ViewState["origen"];
            Agenda agendas = new Agenda();
            agendas = (Agenda)ViewState["Agenda"];
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["medico"];
            
            switch (origen)
            {
                case "1":
                    context.Items.Add("Medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("Agenda", (Agenda)ViewState["Agenda"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("PerfilMedico.aspx");
                    break;
                case "2":
                    context.Items.Add("Rut", (String)ViewState["Rut"]);
                    context.Items.Add("Medico", medico);
                    context.Items.Add("Fecha", Fecha);
                    context.Items.Add("Agenda", agendas);
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "0");
                    Server.Transfer("PerfilMedico.aspx");
                    break;
            }
           
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string origen = (string)ViewState["origen"];
            HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            HttpContext context = HttpContext.Current;
            switch (origen)
            {
                case "1":
                    Server.Transfer("ReservaHora.aspx?r=" + hdMaster.Value);
                    break;
                case "2":
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);                   
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "2");
                    Server.Transfer("Especialidad.aspx?r=" + hdMaster.Value);
                    break;
                default:
                    Server.Transfer("ReservaHora.aspx?r=" + hdMaster.Value);
                    break;
            }
           
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            pnModal.Visible = false;
            
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            HttpContext context = HttpContext.Current;
            String origen = (String)ViewState["origen"];
            if (origen.Equals("2"))
            {
                Context.Items.Add("Agendas", ViewState["Agendas"]);
                Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                context.Items.Add("Medicos", ViewState["lstMedicos"]);
            }            
            context.Items.Add("medico", (Medicos)ViewState["medico"]);
            context.Items.Add("Fecha", (String)ViewState["Fecha"]);
            context.Items.Add("Rut", (String)ViewState["Rut"]);
            context.Items.Add("origen", origen);
            context.Items.Add("Agenda", ViewState["Agenda"]);
            context.Items.Add("Cita", ViewState["Cita"]);
            Server.Transfer("Confirmacion.aspx?r=" + hdMaster.Value);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

        }
    }
}
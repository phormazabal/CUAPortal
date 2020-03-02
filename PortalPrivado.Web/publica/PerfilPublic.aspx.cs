using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.BO;
using PortalPrivado.DAO;
namespace PortalPrivado.Web.publica
{
    public partial class PerfilPublic : System.Web.UI.Page
    {
        /// <summary>
        /// test
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpContext context = HttpContext.Current;
                Medicos medico = new Medicos();
                BO.Agenda agenda = new BO.Agenda();
                medico = (Medicos)context.Items["Medico"];
                agenda = (BO.Agenda)context.Items["Agenda"];
                String Fecha = medico.FechaServ;//agenda.Fecha;
                String origen = (String)context.Items["origen"];
                ViewState["origen"] = origen;
                List<Medicos> lstMedicos = (List<Medicos>)context.Items["Medicos"];
                ViewState["lstMedicos"] = lstMedicos;
                ViewState["Especialidad"] = (String)context.Items["Especialidad"];
                ViewState["IdEspecialidad"] = (String)context.Items["IdEspecialidad"];
                ViewState["Agenda"] = agenda;
                ViewState["medico"] = medico;
                ViewState["Fecha"] = Fecha;
                //ViewState["Agendas"] = context.Items["Agendas"];
                String dia = Fecha.Substring(0, 2) + "/" + Fecha.Substring(2, 2) + "/" + Fecha.Substring(4, 4);
                String hora = Fecha.Substring(8, 2) + ":" + Fecha.Substring(10, 2);
                if (origen.Equals("5"))
                {
                    ViewState["Especialidad1"] = (String)context.Items["Especialidad1"];
                    ViewState["IdEspecialidad1"] = (String)context.Items["IdEspecialidad1"];
                    Panel1.Visible = true;
                    lbEspecialidadR.Text = (String)context.Items["Especialidad"];
                    lbEspecialidadR.Visible = true;
                    lbEspecialidadR1.Text = (String)context.Items["Especialidad1"];
                    lbHora1.Text = hora;
                    lbFecha1.Text = dia;
                }               
                List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                lstbusqueda = (List<BO.Agenda>)context.Items["Agendas"];
                ViewState["Agendas"] = lstbusqueda;                
                lbActividadDoc.Text = medico.Value[0].ActividadDocente;
                lbArea.Text = medico.Value[0].AreaInvestigacion;
                lbAreaInteres.Text = medico.Value[0].AreaInteres;
                lbDetalle.Text = medico.Value[0].MiniBiografia;
                lbEspecialidad.Text = (String)context.Items["Especialidad"] + " " + (String)context.Items["Especialidad1"];
                lbIdiomas.Text = medico.Value[0].IdiomasAtencion;
                lbSubEsp.Text = "";
                lbUbicacion.Text = medico.Value[0].UbicacionConsulta;
                imgDr.ImageUrl = medico.Value[0].oImagenes.Url;
                lbFecha.Text = dia;
                lbHora.Text = hora;
                lbNombre.Text = medico.Value[0].Nombres + " " + medico.Value[0].Apellidos;
            }
        }

        protected void lkReservar_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(lbFecha.Text);
            BO.Agenda agenda = new BO.Agenda();
            agenda = (BO.Agenda)ViewState["Agenda"];
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["medico"];
            List<DispoDiaria> lstDiaria = new List<DispoDiaria>();
            MedicoDao oMedDao = new MedicoDao();
            lstDiaria = oMedDao.GetDisponibilidadDiaria(medico.Value[0].VMA, agenda.Fecha, agenda.Id_especialidad);
            String Uttrat = lstDiaria[0].Utratamiento;
            Cita cita = new Cita();
            Paciente pac = new Paciente();
            PacienteDao pacDao = new PacienteDao();
            cita.Utratamiento = Uttrat;
            cita.Horareserva = lbHora.Text.Substring(0, 5);
            cita.Medico = agenda.Id_medico;
            cita.Especialidad = agenda.Id_especialidad;
            cita.Codorigen = "1";
            cita.Fecreserva = fecha.ToString("ddMMyyyy");
            cita.Mail = pac.Email;
            cita.Telefono = pac.Telefono1;
            HttpContext context = HttpContext.Current;
            String origen = (String)ViewState["origen"];
            switch (ViewState["origen"])
            {
                case "3":                    
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("origen", "3P");
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Confirmacion.aspx");
                    break;
                case "2":                    
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("origen", origen);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Confirmacion.aspx");
                    break;
                case "4":                   
                    context.Items.Add("Cita", cita);
                    context.Items.Add("IdEspecialidad", (String)ViewState["IdEspecialidad"]);
                    context.Items.Add("Especialidad", (String)ViewState["Especialidad"]);
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Agenda", (BO.Agenda)ViewState["Agenda"]);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("origen", "4p");
                    Server.Transfer("Confirmacion.aspx");
                    break;
                case "4d":
                    context.Items.Add("Cita", cita);
                    context.Items.Add("IdEspecialidad", (String)ViewState["IdEspecialidad"]);
                    context.Items.Add("Especialidad", (String)ViewState["Especialidad"]);
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Agenda", (BO.Agenda)ViewState["Agenda"]);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("origen", "4d");
                    Server.Transfer("Confirmacion.aspx");
                    break;

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string origen = (string)ViewState["origen"];
            HttpContext context = HttpContext.Current;           
            BO.Agenda agenda = new BO.Agenda();
            Medicos oMedico = new Medicos();
            switch (origen)
            {
                case "0":

                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", agenda.Fecha);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "2");
                    Server.Transfer("DetalleAgenda.aspx");
                    break;
                case "3":
                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", agenda.Fecha);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "3");
                    Server.Transfer("DetallePublic.aspx");
                    break;
                case "4":
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "4");
                    Server.Transfer("Especialidad.aspx");
                    break;
                case "4d":
                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", agenda.Fecha);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "4");
                    Server.Transfer("DetallePublic.aspx");
                    break;

            }

        }

        protected void lkReservar2_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(lbFecha.Text);
            BO.Agenda agenda = new BO.Agenda();
            agenda = (BO.Agenda)ViewState["Agenda"];
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["medico"];
            List<DispoDiaria> lstDiaria = new List<DispoDiaria>();
            MedicoDao oMedDao = new MedicoDao();
            lstDiaria = oMedDao.GetDisponibilidadDiaria(medico.Value[0].VMA, agenda.Fecha, agenda.Id_especialidad);
            String Uttrat = lstDiaria[0].Utratamiento;
            Cita cita = new Cita();
            Paciente pac = new Paciente();
            PacienteDao pacDao = new PacienteDao();
            cita.Utratamiento = Uttrat;
            cita.Horareserva = lbHora.Text.Substring(0, 5);
            cita.Medico = agenda.Id_medico;
            cita.Especialidad = agenda.Id_especialidad;
            cita.Codorigen = "1";
            cita.Fecreserva = fecha.ToString("ddMMyyyy");
            cita.Mail = pac.Email;
            cita.Telefono = pac.Telefono1;
            HttpContext context = HttpContext.Current;

            String origen = (String)ViewState["origen"];
            switch (ViewState["origen"])
            {
                case "0":
                    origen = "01";
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("origen", origen);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Confirmacion.aspx");
                    break;
                case "1":
                    origen = "02";
                    context.Items.Add("Cita", cita);
                    context.Items.Add("IdEspecialidad", (String)ViewState["IdEspecialidad1"]);
                    context.Items.Add("Especialidad", (String)ViewState["Especialidad1"]);
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Agenda", (BO.Agenda)ViewState["Agenda"]);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("Confirmacion.aspx");
                    break;

            }
        }
    }
}
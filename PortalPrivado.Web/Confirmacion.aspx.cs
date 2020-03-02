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
    public partial class Confirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpContext context = HttpContext.Current;
                PacienteDao oPaciente = new PacienteDao();
                Agenda agendas = new Agenda();
                Cita cita = new Cita();
                Medicos medico = new Medicos();
                List<Medicos> lstMedicos = (List<Medicos>)context.Items["Medicos"];
                ViewState["lstMedicos"] = lstMedicos;
                String Fecha = (String)context.Items["Fecha"];
                medico = (Medicos)context.Items["medico"];
                string origen = (string)context.Items["origen"];
                ViewState["origen"] = origen;
                agendas = (Agenda)context.Items["Agenda"];
                cita = (Cita)context.Items["Cita"];
                ViewState["Agenda"] = agendas;
                ViewState["origen"] = (String)context.Items["origen"];
                ViewState["Rut"] = (String)context.Items["Rut"];
                ViewState["IdEspecialidad"] = (String)context.Items["IdEspecialidad"];
                ViewState["Especialidad"] = (String)context.Items["Especialidad"];
                List<Agenda> lstbusqueda = new List<Agenda>();
                lstbusqueda = (List<Agenda>)context.Items["Agendas"];
                ViewState["Agendas"] = lstbusqueda;  
                String cadena;
                String[] master = Utilidades.Seguridad.DesEncriptarSap(Request.QueryString["r"], out cadena);
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
                String Rut;
                String RutMaster = master[3];
                if (master.Length > 6)
                {
                    Rut = master[6];
                    
                    HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                    hdtipo.Value = "V";
                }
                else
                {
                    Rut = master[3];
                }
                lbNombreMed.Text = agendas.NombreMed + " " + agendas.Apepat + " " + agendas.Apemat;
                lbFecha.Text = cita.Fecreserva.Substring(0, 2) + "/" + cita.Fecreserva.Substring(2, 2) + "/" +
                    cita.Fecreserva.Substring(4, 4);
                if (cita.Horareserva.Length == 4)
                    lbHora.Text = cita.Horareserva.Substring(0, 2) + ":" + cita.Horareserva.Substring(2, 2);
                else
                    lbHora.Text = cita.Horareserva;
                lbEspecialidad.Text = agendas.Especialidad;
                lbPaciente.Text = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(cita.Nompac + " " + cita.Apepatpac);
                ViewState["IdEspecialidad"] = cita.Especialidad;
                ViewState["token"] = hdMaster.Value;
                ViewState["Rut"] = cita.Rutpac;
                ViewState["Agenda"] = agendas;
                ViewState["Cita"] = cita;
                ViewState["NombreMedico"] = lbNombreMed.Text;
                ViewState["Fecha"] = Fecha;
                ViewState["medico"] = medico;
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Reserva de hora > Confirmación >";               
            }
        }

        protected void btnReservar_Click(object sender, EventArgs e)
        {
            PacienteDao PacDao = new PacienteDao();
            PortalPrivado.BO.Reserva reserva = new PortalPrivado.BO.Reserva();
            Cita cita = new Cita();
            cita = (Cita)ViewState["Cita"];
            if (cita.Horareserva.Length == 5)
                cita.Horareserva = cita.Horareserva.Remove(2,1) + "00";
            reserva = PacDao.SetCita(cita);
            if (reserva.Codreserva.Equals("0"))
            {
                pnModal.Visible = true;
              
            }
            else
            {

                try
                {
                    Utilidades.Comunicacion comunicacion = new Utilidades.Comunicacion();
                    String html = String.Format(Recursos.Html, cita.Nompac + " " + cita.Apepatpac, reserva.Codreserva, lbFecha.Text, lbHora.Text, lbEspecialidad.Text, lbNombreMed.Text);
                    comunicacion.sendEmail(html, cita.Mail);
                    HttpContext context = HttpContext.Current;
                    context.Items.Add("NombreMed", (String)ViewState["NombreMedico"]);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Reserva.aspx?r=" + (String)ViewState["token"]);
                }
                catch (Exception)
                {
                    HttpContext context = HttpContext.Current;
                    context.Items.Add("NombreMed", (String)ViewState["NombreMedico"]);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Reserva.aspx?r=" + (String)ViewState["token"]);
                }
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string origen = (string)ViewState["origen"];
            HttpContext context = HttpContext.Current;
            switch (origen)
            {               
                case "01":
                    String Fecha = (String)ViewState["Fecha"];
                    Agenda agendas = new Agenda();
                    agendas = (Agenda)ViewState["Agenda"];
                    Medicos medico = new Medicos();
                    medico = (Medicos)ViewState["medico"];
                    context.Items.Add("Medico", medico);
                    context.Items.Add("Fecha", Fecha);
                    context.Items.Add("Agenda", agendas);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("PerfilMedico.aspx?r=" + (String)ViewState["token"]);
                    break;
                case "1":
                    context.Items.Add("Medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("Agenda", (Agenda)ViewState["Agenda"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("DetalleAgenda.aspx?r=" + (String)ViewState["token"]);
                    break;
                case "2":
                    context.Items.Add("IdEspecialidad", (String)ViewState["IdEspecialidad"]);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Agenda", (Agenda)ViewState["Agenda"]);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "2");
                    Server.Transfer("DetalleAgenda.aspx?r=" + (String)ViewState["token"]);
                    break;
                case "2a":
                    context.Items.Add("IdEspecialidad", (String)ViewState["IdEspecialidad"]);                   
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("Rut", ViewState["Rut"]); 
                    context.Items.Add("origen", "2"); 
                    Server.Transfer("Especialidad.aspx?r=" + (String)ViewState["token"]);
                    break;
            }
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Server.Transfer("ReservaHora.aspx?r=" + (String)ViewState["token"]);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            pnModal.Visible = false;
            
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }
    }
}
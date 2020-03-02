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
    public partial class Confirmacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpContext context;
                context = HttpContext.Current;
                BO.Agenda agendas = new BO.Agenda();
                Cita cita = new Cita();
                Medicos medico = new Medicos();
                List<Medicos> lstMedicos = (List<Medicos>)context.Items["Medicos"];
                ViewState["lstMedicos"] = lstMedicos;
                String Fecha = (String)context.Items["Fecha"];
                medico = (Medicos)context.Items["medico"];
                ViewState["Medico"] = medico;
                string origen = (string)context.Items["origen"];
                ViewState["origen"] = origen;
                agendas = (BO.Agenda)context.Items["Agenda"];
                cita = (Cita)context.Items["Cita"];
                ViewState["Agenda"] = agendas;
                ViewState["origen"] = (String)context.Items["origen"];
                ViewState["IdEspecialidad"] = (String)context.Items["IdEspecialidad"];
                ViewState["Especialidad"] = (String)context.Items["Especialidad"];                
                List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                lstbusqueda = (List<BO.Agenda>)context.Items["Agendas"];
                ViewState["Agendas"] = lstbusqueda;
                lbNombre.Text = medico.Value[0].Nombres + " " + medico.Value[0].Apellidos;
                imgDoc.ImageUrl = medico.Value[0].oImagenes.Url;
                lbEspecialidad.Text = agendas.Especialidad;
                lbFecha.Text = cita.Fecreserva.Substring(0, 2) + "/" + cita.Fecreserva.Substring(2, 2) + "/" +
                    cita.Fecreserva.Substring(4, 4);
                if (cita.Horareserva.Length == 4)
                    lbHora.Text = cita.Horareserva.Substring(0, 2) + ":" + cita.Horareserva.Substring(2, 2);
                else
                    lbHora.Text = cita.Horareserva;
                ViewState["Cita"] = cita;
            }
        }

        protected void lkReservar_Click(object sender, EventArgs e)
        {
            HttpContext context;
            context = HttpContext.Current;
            Cita cita = new Cita();
            BO.Reserva reserva = new BO.Reserva();
            PacienteDao pac = new PacienteDao();
            cita = (Cita)ViewState["Cita"];
            cita.Nompac = txtNombre.Text;
            cita.Apepatpac = txtApellidos.Text;
            cita.Rutpac = txtRut.Text;
            cita.Rutsol = txtRut.Text;
            cita.Telefono = txtTelefono.Text;
            cita.Mail = txtEmail.Text;
            if (cita.Horareserva.Length == 5)
                cita.Horareserva = cita.Horareserva.Remove(2, 1) + "00";
            reserva = pac.SetCita(cita);
            if (reserva.Codreserva.Equals("0"))
            {
                pnModal.Visible = true;
            }
            else
            {
                Utilidades.Comunicacion comunicacion = new Utilidades.Comunicacion();
                String html = String.Format(Recursos.Html, cita.Nompac + " " + cita.Apepatpac, reserva.Codreserva, lbFecha.Text, lbHora.Text, lbEspecialidad.Text, lbNombre.Text);
                try
                {
                    comunicacion.sendEmail(html, cita.Mail);
                    context.Items.Add("Cita", cita);
                    context.Items.Add("Medico", (Medicos)ViewState["Medico"]);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    Server.Transfer("CitaAgenda.aspx");
                }
                catch (Exception ex)
                {
                    //context.Items.Add("Cita", cita);
                    //context.Items.Add("Medico", (Medicos)ViewState["Medico"]);
                    //context.Items.Add("Especialidad", lbEspecialidad.Text);
                    Server.Transfer("CitaAgenda.aspx");
                }
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
                case "1":
                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["Medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", agenda.Fecha);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("DetallePublic.aspx");
                    break;

                case "2":
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "2");
                    Server.Transfer("Especialidad.aspx?r=");
                    break;
                case "3P":
                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["Medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", agenda.Fecha);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "3");
                    Server.Transfer("PerfilPublic.aspx");
                    break;
                case "3":
                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["Medico"];
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
                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["Medico"];
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
                case "4a":
                    Context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "4");
                    Server.Transfer("Especialidad.aspx");
                    break;
                case "4p":
                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["Medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", agenda.Fecha);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "4");
                    Server.Transfer("PerfilPublic.aspx");
                    break;
                case "4d":
                    agenda = (BO.Agenda)ViewState["Agenda"];
                    oMedico = (Medicos)ViewState["Medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", agenda.Fecha);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
                    Context.Items.Add("Especialidad", ViewState["Especialidad"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("origen", "4d");
                    Server.Transfer("PerfilPublic.aspx");
                    break;
            }

        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            pnModal.Visible = false;

        }
        //protected void LinkButton2_Click(object sender, EventArgs e)
        //{
        //    String a = "";
        //}
    }
}
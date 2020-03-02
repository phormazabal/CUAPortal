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
                HttpContext context = HttpContext.Current;
                String cadena;
                String[] decript = Utilidades.Seguridad.DesEncriptarSap(Request.QueryString["r"], out cadena);
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
                String RutMaster = decript[3];
                if (decript.Length < 6)
                {
                    ViewState["Rut"] = decript[3];

                }
                else
                {
                    ViewState["Rut"] = decript[6];
                    HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                    hdtipo.Value = "V";
                }
                Medicos medico = new Medicos();
                Agenda agenda = new Agenda();
                medico = (Medicos)context.Items["Medico"];
                agenda = (Agenda)context.Items["Agenda"];
                String Fecha = agenda.Fecha;
                ViewState["origen"] = (String)context.Items["origen"];
                List<Medicos> lstMedicos = (List<Medicos>)context.Items["Medicos"];
                ViewState["lstMedicos"] = lstMedicos;
                ViewState["Especialidad"] = (String)context.Items["Especialidad"];
                ViewState["IdEspecialidad"] = (String)context.Items["IdEspecialidad"];
                ViewState["Rut"] = (String)context.Items["Rut"];               
                ViewState["Agenda"] = agenda;
                ViewState["medico"] = medico;                
                ViewState["Fecha"] = Fecha;
                List<Agenda> lstbusqueda = new List<Agenda>();
                lstbusqueda = (List<Agenda>)context.Items["Agendas"];
                ViewState["Agendas"] = lstbusqueda;
                String dia = Fecha.Substring(0, 2) + "/" + Fecha.Substring(2,2) + "/" + Fecha.Substring(4, 4);
                String hora = Fecha.Substring(8, 2) + ":" + Fecha.Substring(10, 2);
                lbActividadDoc.Text = medico.Value[0].ActividadDocente;
                lbArea.Text = medico.Value[0].AreaInvestigacion;
                lbAreaInteres.Text = medico.Value[0].AreaInteres;
                lbDetalle.Text = medico.Value[0].MiniBiografia;
                lbEspecialidad.Text = (String)context.Items["Especialidad"];
                lbIdiomas.Text = medico.Value[0].IdiomasAtencion;
                lbSubEsp.Text = "";
                lbUbicacion.Text = medico.Value[0].UbicacionConsulta;
                imgDr.ImageUrl = medico.Value[0].oImagenes.Url;
                lbFecha.Text = dia;
                lbHora.Text = hora;
                lbNombre.Text = medico.Value[0].Nombres + " " + medico.Value[0].Apellidos;
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Reserva de hora > Perfil Médico >";
               
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string origen = (string)ViewState["origen"];            
            HttpContext context = HttpContext.Current;
            HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            Agenda agenda = new Agenda();
            Medicos oMedico = new Medicos();
            switch (origen)
            {
                case "0":
                    
                    agenda = (Agenda)ViewState["Agenda"];                   
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
                    Server.Transfer("DetalleAgenda.aspx?r=" + hdMaster.Value);
                    break;
                case "1":                   
                    agenda = (Agenda)ViewState["Agenda"];                   
                    oMedico = (Medicos)ViewState["medico"];
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", agenda.Fecha);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("DetalleAgenda.aspx?r=" + hdMaster.Value);
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
            }
        }

        protected void lkReservar_Click(object sender, EventArgs e)
        {
            DateTime fecha = DateTime.Parse(lbFecha.Text);
            Agenda agenda = new Agenda();
            agenda = (Agenda)ViewState["Agenda"];
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
            cita.Rutpac = (String)ViewState["Rut"];
            cita.Rutsol = (String)ViewState["Rut"];
            pac = pacDao.GetPaciente(cita.Rutpac);
            cita.Codorigen = "1";
            cita.Nompac = pac.Nombre;
            cita.Apepatpac = pac.Apellidos;
            cita.Fecreserva = fecha.ToString("ddMMyyyy");
            cita.Mail = pac.Email;
            cita.Telefono = pac.Telefono1;
            HttpContext context = HttpContext.Current;
            HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            String origen;
            switch (ViewState["origen"])
            {
                case "1":
                    origen = "01";
                    context.Items.Add("Fecha", (String)ViewState["Fecha"]);
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("origen", origen);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Confirmacion.aspx?r=" + hdMaster.Value);
                    break;
                case "2":
                    origen = "02";
                    context.Items.Add("Cita", cita);
                    context.Items.Add("IdEspecialidad", (String)ViewState["IdEspecialidad"]);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("medico", (Medicos)ViewState["medico"]);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Agenda", (Agenda)ViewState["Agenda"]);
                    context.Items.Add("Agendas", ViewState["Agendas"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "2");
                    Server.Transfer("Confirmacion.aspx?r=" + hdMaster.Value);
                    break;
            }
            
            //HttpContext context = HttpContext.Current;
            //String origen = (String)ViewState["origen"];
            //Context.Items.Add("Agendas", ViewState["Agendas"]);
            //Context.Items.Add("IdEspecialidad", ViewState["IdEspecialidad"]);
            //Context.Items.Add("Especialidad", ViewState["Especialidad"]);
            //HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            //context.Items.Add("Medicos", ViewState["lstMedicos"]);
            //context.Items.Add("medico", (Medicos)ViewState["medico"]);
            //context.Items.Add("Fecha", (String)ViewState["Fecha"]);
            //context.Items.Add("Rut", (String)ViewState["Rut"]);
            //context.Items.Add("origen", "2a");
            //context.Items.Add("Agenda", ViewState["Agendas"]);
            //context.Items.Add("Cita", cita);
            //Server.Transfer("Confirmacion.aspx?r=" + hdMaster.Value);
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }
    }
}
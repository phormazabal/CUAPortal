using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.DAO;
using PortalPrivado.BO;
using System.Data.Linq.SqlClient;
using System.Globalization;
namespace PortalPrivado.Web
{
    public partial class ReservaHora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["r"] != null)
                {
                    String cadena;
                    ReservaDao oReserva = new ReservaDao();
                    PacienteDao oPaciente = new PacienteDao();
                    List<Busqueda> lstBusqueda = new List<Busqueda>();
                    lstBusqueda = oReserva.GetBusqueda();
                    dpBusqueda.DataSource = lstBusqueda;
                    dpBusqueda.DataValueField = "Id";
                    dpBusqueda.DataTextField = "Glosa";
                    dpBusqueda.DataBind();
                    dpBusqueda.Focus();                    
                    HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                    hdMaster.Value = Request.QueryString["r"];   
                    string[] decript = Utilidades.Seguridad.DesEncriptarSap(hdMaster.Value, out cadena);
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
                    Literal litPag = (Literal)Master.FindControl("litPag1");
                    litPag.Text = "Reserva de hora >";
                }

            }
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            String parametro = Utilidades.Seguridad.Encriptar(dpBusqueda.SelectedValue);
            String[] Classificacion = dpBusqueda.SelectedValue.Split('|');
            HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            HttpContext context;
            context = HttpContext.Current;
            if (Classificacion[1].Equals("M"))
            {
                AgendaDao AgendaDao = new AgendaDao();
                List<Agenda> lstbusqueda = new List<Agenda>();
                lstbusqueda = (List<Agenda>)ViewState["AgendaMed"];//AgendaDao.GetAgenda("", Classificacion[0]);

                if (lstbusqueda.Count > 1)
                {
                    //Server.Transfer("Reserva2.aspx");
                    MedicoDao oMedicoDao = new MedicoDao();
                    Medicos oMedico = new Medicos();                    
                    oMedico = oMedicoDao.GetMedico(lstbusqueda[dpEspejo.SelectedIndex].RutMed);
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", lstbusqueda[dpEspejo.SelectedIndex].Fecha);
                    context.Items.Add("Agenda", lstbusqueda[dpEspejo.SelectedIndex]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("DetalleAgenda.aspx?r=" + hdMaster.Value);
                }
                else
                {
                    MedicoDao oMedicoDao = new MedicoDao();
                    Medicos oMedico = new Medicos();
                    oMedico = oMedicoDao.GetMedico(lstbusqueda[0].RutMed);
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", lstbusqueda[0].Fecha);
                    context.Items.Add("Agenda", lstbusqueda[0]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "1");
                    Server.Transfer("DetalleAgenda.aspx?r=" + hdMaster.Value);
                }
            }
            else
            {
                AgendaDao AgendaDao = new AgendaDao();
                List<Agenda> lstbusqueda = new List<Agenda>();
                List<Medicos> lstMedicos = new List<Medicos>();
                MedicoDao oMedicoDao = new MedicoDao();
                CultureInfo ci = new CultureInfo("Es-Es");
                lstbusqueda = (List<Agenda>)ViewState["Agendas"];
                    //AgendaDao.GetAgenda(Classificacion[0], "");
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
                    if (medico.Value.Count != 0)
                        lstMedicos.Add(medico);
                }
                Context.Items.Add("IdEspecialidad", Classificacion[0]);
                Context.Items.Add("Agendas", lstbusqueda);
                Context.Items.Add("Especialidad", dpBusqueda.SelectedItem.Text);
                context.Items.Add("Medicos", lstMedicos);
                context.Items.Add("Rut", ViewState["Rut"]);
                context.Items.Add("origen", "2");
                Server.Transfer("Especialidad.aspx?r=" + hdMaster.Value);
            }
        }

        protected void dpBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] Classificacion = dpBusqueda.SelectedValue.Split('|');
            if (Classificacion[1].Equals("M"))
            {
                AgendaDao AgendaDao = new AgendaDao();
                List<Agenda> lstbusqueda = new List<Agenda>();
                lstbusqueda = AgendaDao.GetAgenda("", Classificacion[0]);
                ViewState["AgendaMed"] = lstbusqueda;
                if (lstbusqueda.Count > 1)
                {
                    lbEspejo.Visible = true;
                    dpEspejo.Visible = true;
                    btnAceptar.Visible = true;
                    btnaceptarSimple.Visible = false;
                    dpEspejo.DataSource = lstbusqueda;
                    dpEspejo.DataValueField = "Id_especialidad";
                    dpEspejo.DataTextField = "Especialidad";
                    dpEspejo.DataBind();
                }
                else
                {
                    btnaceptarSimple.Visible = true;
                    btnAceptar.Visible = false;
                    lbEspejo.Visible = false;
                    dpEspejo.Visible = false;
                }
            }
            else
            {
                btnaceptarSimple.Visible = true;
                btnAceptar.Visible = false;
                lbEspejo.Visible = false;
                dpEspejo.Visible = false;
                AgendaDao AgendaDao = new AgendaDao();
                //List<Agenda> lstbusqueda = new List<Agenda>();
                //lstbusqueda = AgendaDao.GetAgenda(Classificacion[0], "");
                ViewState["Agendas"] = AgendaDao.GetAgenda(Classificacion[0], "");
                //HttpContext context;
                //context = HttpContext.Current;

            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }

        //protected void btnaceptarSimple_Click(object sender, EventArgs e)
        //{

        //}
    }
}
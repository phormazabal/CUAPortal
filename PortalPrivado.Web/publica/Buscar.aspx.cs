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
    public partial class Buscar : System.Web.UI.Page
    {
        //version
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ReservaDao oReserva = new ReservaDao();
                List<Busqueda> lstBusqueda = new List<Busqueda>();
                lstBusqueda = oReserva.GetBusqueda();
                dpBusqueda.DataSource = lstBusqueda;
                dpBusqueda.DataValueField = "Id";
                dpBusqueda.DataTextField = "Glosa";
                dpBusqueda.DataBind();
                dpBusqueda.Focus();
            }
        }

        protected void dpBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            String[] Classificacion = dpBusqueda.SelectedValue.Split('|');
            if (Classificacion[1].Equals("M"))
            {
                AgendaDao AgendaDao = new AgendaDao();
                List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
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
                //AgendaDao AgendaDao = new AgendaDao();               
                //ViewState["Agendas"] = AgendaDao.GetAgenda(Classificacion[0], "");  
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            String parametro = Utilidades.Seguridad.Encriptar(dpBusqueda.SelectedValue);
            String[] Classificacion = dpBusqueda.SelectedValue.Split('|');            
            HttpContext context;
            context = HttpContext.Current;
            if (Classificacion[1].Equals("M"))
            {
                AgendaDao AgendaDao = new AgendaDao();
                List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                lstbusqueda = AgendaDao.GetAgenda("", Classificacion[0]);
                //(List<BO.Agenda>)ViewState["AgendaMed"];

                if (lstbusqueda.Count > 1)
                {
                    //Server.Transfer("Reserva2.aspx");
                    MedicoDao oMedicoDao = new MedicoDao();
                    Medicos oMedico = new Medicos();
                    oMedico = oMedicoDao.GetMedico(lstbusqueda[dpEspejo.SelectedIndex].RutMed);
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", lstbusqueda[dpEspejo.SelectedIndex].Fecha);
                    context.Items.Add("Agenda", lstbusqueda[dpEspejo.SelectedIndex]);
                    context.Items.Add("IdEspecialidad", lstbusqueda[dpEspejo.SelectedIndex].Id_especialidad);
                    context.Items.Add("Especialidad", lstbusqueda[dpEspejo.SelectedIndex].Especialidad);
                    context.Items.Add("origen", "3");
                    Server.Transfer("DetallePublic.aspx");
                }
                else
                {
                    MedicoDao oMedicoDao = new MedicoDao();
                    Medicos oMedico = new Medicos();
                    oMedico = oMedicoDao.GetMedico(lstbusqueda[0].RutMed);
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Fecha", lstbusqueda[0].Fecha);
                    context.Items.Add("Agenda", lstbusqueda[0]);
                    context.Items.Add("IdEspecialidad", lstbusqueda[0].Id_especialidad);
                    context.Items.Add("Especialidad", lstbusqueda[0].Especialidad);
                    context.Items.Add("origen", "3");
                    Server.Transfer("DetallePublic.aspx");
                }
            }
            else
            {
                AgendaDao AgendaDao = new AgendaDao();
                List<BO.Agenda> lstbusqueda = new List<BO.Agenda>();
                List<Medicos> lstMedicos = new List<Medicos>();
                MedicoDao oMedicoDao = new MedicoDao();
                CultureInfo ci = new CultureInfo("Es-Es");
                lstbusqueda = AgendaDao.GetAgenda(Classificacion[0], "");
                for (int i = 0; i < lstbusqueda.Count; i++)
                {
                    Medicos medico = new Medicos();
                    medico = oMedicoDao.GetMedico(lstbusqueda[i].RutMed);
                    medico.FechaServ = lstbusqueda[i].Fecha;
                    if (lstbusqueda[i].Fecha != null)
                    {
                        DateTime FechaPaso = DateTime.Parse(lstbusqueda[i].Fecha.Substring(0, 2) + "/" + lstbusqueda[i].Fecha.Substring(2, 2) + "/" + lstbusqueda[i].Fecha.Substring(4, 4));
                        medico.Fecha = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(ci.DateTimeFormat.GetDayName(FechaPaso.DayOfWeek)) + " " + FechaPaso.ToString("dd/MM/yyyy")
                            + " " + lstbusqueda[i].Fecha.Substring(8, 2) + ":" + lstbusqueda[i].Fecha.Substring(10, 2) + " hrs";
                    }
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
                context.Items.Add("origen", "4");
                Server.Transfer("Especialidad.aspx");
            }
        }
    }
}
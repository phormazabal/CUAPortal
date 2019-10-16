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
    public partial class DetalleAgenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpContext context;
                context = HttpContext.Current;
                List<Agenda> agendas = new List<Agenda>();
                agendas = (List<Agenda>)context.Items["lstbusqueda"];               
                MedicoDao oMedicoDao = new MedicoDao();
                Medicos medico = new Medicos();
                medico = (Medicos)context.Items["Medico"];
                ViewState["medico"] = medico;
                ViewState["lstbusqueda"] = agendas;
                ImgDr.ImageUrl = medico.Value[0].oImagenes.Url;
                lbNombre.Text = medico.Value[0].Nombres + " " + medico.Value[0].Apellidos;
                String fecha = agendas[0].Fecha.Substring(0, 8);
                List<DispoDiaria> lstDis = new List<DispoDiaria>();
                lstDis = oMedicoDao.GetDisponibilidadDiaria(medico.Value[0].VMA, fecha, agendas[0].Id_especialidad);
                dlDisHora.DataSource = lstDis;
                dlDisHora.DataBind();
                List<String> lstMes = new List<string>();
                lstMes = oMedicoDao.GetDisponibilidadMensual("01" + agendas[0].Fecha.Substring(2,6), medico.Value[0].VMA);
                calendar.VisibleDate  = new DateTime(int.Parse(lstMes[0].Substring(4,4)), int.Parse(lstMes[0].Substring(2, 2)), 01);
                calendar.SelectedDate = new DateTime(int.Parse(agendas[0].Fecha.Substring(4, 4)),
                       int.Parse(agendas[0].Fecha.Substring(2, 2)), int.Parse(agendas[0].Fecha.Substring(0, 2)));
                ViewState["Mes"] = lstMes;
                lbEspecialidad.Text = agendas[0].Especialidad;


            }
        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {
            MedicoDao oMedicoDao = new MedicoDao();
            List<String> lstMes = new List<string>();
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["medico"];
            lstMes = (List<String>)ViewState["Mes"];
            for (int i = 0; i < lstMes.Count; i++)
            {
                if (e.Day.Date == new DateTime(int.Parse(lstMes[i].Substring(4, 4)), 
                    int.Parse(lstMes[i].Substring(2, 2)), int.Parse(lstMes[i].Substring(0, 2))))
                {
                    e.Cell.BackColor = System.Drawing.Color.Azure;
                    e.Day.IsSelectable = true;
                }
            }
        }
        protected void calendar_select(object sender, DayRenderEventArgs e)
        {
           
        }

        protected void calendar_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            MedicoDao oMedicoDao = new MedicoDao();
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["medico"];
            List<String> lstMes = new List<string>();
            lstMes = oMedicoDao.GetDisponibilidadMensual("01" + e.NewDate.ToString("MMyyyy"), medico.Value[0].VMA);
            ViewState["Mes"] = lstMes;
        }

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            MedicoDao oMedicoDao = new MedicoDao();
            Medicos medico = new Medicos();
            medico = (Medicos)ViewState["medico"];
            List<DispoDiaria> lstDis = new List<DispoDiaria>();
            List<Agenda> agendas = new List<Agenda>();
            agendas = (List<Agenda>)ViewState["lstbusqueda"];
            String fecha = calendar.SelectedDate.ToString("ddMMyyyy");
            lstDis = oMedicoDao.GetDisponibilidadDiaria(medico.Value[0].VMA, fecha, agendas[0].Id_especialidad);
            dlDisHora.DataSource = lstDis;
            dlDisHora.DataBind();
        }
    }
}
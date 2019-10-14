using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.DAO;
using PortalPrivado.BO;
using System.Data.Linq.SqlClient;

namespace PortalPrivado.Web
{
    public partial class ReservaHora : System.Web.UI.Page
    {
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
            }
        } 
        protected void btnAceptar_Click(object sender, EventArgs e)
        {            
            String parametro = Utilidades.Seguridad.Encriptar(dpBusqueda.SelectedValue);
            String[] Classificacion = dpBusqueda.SelectedValue.Split('|');
            if (Classificacion[1].Equals("M"))
            {
                AgendaDao AgendaDao = new AgendaDao();
                List<Agenda> lstbusqueda = new List<Agenda>();
                lstbusqueda = AgendaDao.GetAgenda("", Classificacion[0]);
                HttpContext context;
                context = HttpContext.Current;
                context.Items.Add("lstbusqueda", lstbusqueda);
                Server.Transfer("Reserva2.aspx");
            }
                //Response.Redirect("Reserva2.aspx?param=" + parametro);
        }
    }
}
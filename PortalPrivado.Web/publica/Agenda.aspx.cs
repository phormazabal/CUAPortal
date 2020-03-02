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
    public partial class Agenda : System.Web.UI.Page
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
                dpBusqueda.Focus();
                aAnular.HRef = Recursos.UrlAgendaPublica + "anular-hora";
            }
        }

        protected void dpBusqueda_SelectedIndexChanged(object sender, EventArgs e)
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
                if (lstbusqueda.Count > 1)
                {
                    buscar.HRef = Recursos.UrlAgendaPublica +  "busqueda-reserva/?pagina=Agendas.aspx&vma=" + Classificacion[0];
                }
                else
                {
                    
                    buscar.HRef = Recursos.UrlAgendaPublica + "busqueda-reserva/?pagina=DetallePublic.aspx&vma=" + Classificacion[0];
                }
            }
            else
            {
                
                buscar.HRef = Recursos.UrlAgendaPublica + "busqueda-reserva/?pagina=Especialidad.aspx&id=" + Classificacion[0] + "&Especialidad=" + dpBusqueda.SelectedItem.Text;
            }
        }

        protected void lkAceptar_Click(object sender, EventArgs e)
        {
            
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.clinicauandes.cl");
        }

        protected void buscar_ServerClick(object sender, EventArgs e)
        {
            Response.Redirect("http://www.clinicauandes.cl");
        }
    }
}
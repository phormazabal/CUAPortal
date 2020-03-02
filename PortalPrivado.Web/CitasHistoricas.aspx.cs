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
    public partial class CitasHistoricas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
                PacienteDao oPaciente = new PacienteDao();
                ReservaDao reservaDao = new ReservaDao();
                String Rut;
                String cadena;
                string[] decript = Utilidades.Seguridad.DesEncriptarSap(hdMaster.Value, out cadena);
                String RutMaster = decript[3];
                if (decript.Length > 6)
                {
                    Rut = decript[6];
                   
                    HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                    hdtipo.Value = "V";
                }
                else
                {
                    Rut = decript[3];
                }
                ViewState["Rut"] = Rut;
                List<Cita> lst = new List<Cita>();
                lst = reservaDao.GetCitaHistorica(Rut, "01012013", DateTime.Now.AddDays(-1).ToString("ddMMyyyy"));
                ViewState["lstHistorico"] = lst;
                grdHistorico.DataSource = lst;
                grdHistorico.DataBind();
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Cita Histórica >";
               
            }
        }
        protected void grdHistorico_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {            
            ReservaDao reservaDao = new ReservaDao();
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            List<Cita> lst = new List<Cita>();
            lst = (List<Cita>)ViewState["lstHistorico"];
            grdHistorico.DataSource = lst;
            grdHistorico.DataBind();
        }
       
    }
}
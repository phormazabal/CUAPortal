using PortalPrivado.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PortalPrivado.Web
{
    public partial class Activa : System.Web.UI.Page
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
                List<BO.Cita> lst = new List<BO.Cita>();
                lst = reservaDao.GetCitaHistorica(Rut, DateTime.Now.ToString("ddMMyyyy"), "31122999");
                ViewState["lstHistorico"] = lst;
                grdHistorico.DataSource = lst;                
                grdHistorico.DataBind();
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Citas Activas >";               
            }
        }

        protected void grdHistorico_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "A":
                    List<BO.Cita> lst = new List<BO.Cita>();
                    lst = (List<BO.Cita>)ViewState["lstHistorico"];                    
                    ViewState["CodCita"] = lst[e.Item.DataItemIndex].CodCita;
                    pnAnular.Visible = true;
                    //LinkButton3_ModalPopupExtender.Show();                   
                    break;
            }
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            ReservaDao reservaDao = new ReservaDao();
            reservaDao.delCita((String)ViewState["CodCita"]);            
            grdHistorico.DataSource = reservaDao.GetCitaHistorica((String)ViewState["Rut"], DateTime.Now.ToString("ddMMyyyy"), "31122999");
            grdHistorico.DataBind();
            pnAnular.Visible = false;
            //LinkButton3_ModalPopupExtender.Hide();
        }

        protected void grdHistorico_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            ReservaDao reservaDao = new ReservaDao();
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            List<BO.Cita> lst = new List<BO.Cita>();
            lst = (List<BO.Cita>)ViewState["lstHistorico"];
            grdHistorico.DataSource = lst;
            grdHistorico.DataBind();
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            pnAnular.Visible = false;
            //LinkButton3_ModalPopupExtender.Hide();
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            pnAnular.Visible = false;
            //LinkButton3_ModalPopupExtender.Hide();
        }
    }
}
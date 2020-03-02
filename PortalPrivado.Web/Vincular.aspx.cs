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
    public partial class Vincular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                String cadena;
                Paciente pac = new Paciente();
                PacienteDao pacDao = new PacienteDao();
                String[] master = Utilidades.Seguridad.DesEncriptarSap(Request.QueryString["r"], out cadena);
                ViewState["cadena"] = cadena;
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
                //HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                //hdtipo.Value = "";
                pac = pacDao.GetPaciente(master[3]);
                ViewState["Rut"] = master[3];
                List<Paciente> lst = new List<Paciente>();
                List<Paciente> lstVinculador = new List<Paciente>();
                lst = pacDao.GetVinculados(pac.BP, out lstVinculador);
                rpVinculados.DataSource = lst;
                rpVinculados.DataBind();
                rpVinculador.DataSource = lstVinculador;
                rpVinculador.DataBind();
                ViewState["lstVinculado"] = lstVinculador;
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Vincular >";
                
            }
           
        }

        protected void lkVincular_Click(object sender, EventArgs e)
        {
            PacienteDao pacDao = new PacienteDao();
            int flag;
            String parametro = pacDao.login(txtRut.Text, txtPass.Text, out flag);
            if (flag == 1)
            {
                String cadena;
                string[] parametros = Utilidades.Seguridad.DesEncriptarSap(parametro, out cadena);
                if (pacDao.SetVinculados(ViewState["Rut"].ToString(), txtRut.Text, "1") == 1)
                {
                    Paciente pac = new Paciente();
                    pac = pacDao.GetPaciente((String)ViewState["Rut"]);
                    txtRut.Text = "";
                    List<Paciente> lstVinculadores = new List<Paciente>();
                    rpVinculados.DataSource = pacDao.GetVinculados(pac.BP, out lstVinculadores);
                    rpVinculados.DataBind();
                }
                else
                {
                    String c = "Fracaso";
                }

            }

        }

        protected void rpVinculados_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdRut;
            HiddenField hdNombre;
            HttpContext context = HttpContext.Current;
            switch (e.CommandName)
            {
                case "R":
                    hdRut = (HiddenField)e.Item.FindControl("hdRut");
                    hdNombre = (HiddenField)e.Item.FindControl("hdNombre");
                    ViewState["rutvinculado"] = hdRut.Value;
                    Panel1.Visible = true;
                    lbNombreDes.Text = hdNombre.Value;
                    //LinkButton3_ModalPopupExtender.Show();
                    break;
                case "A":                   
                    hdRut = (HiddenField)e.Item.FindControl("hdRut");
                    hdNombre = (HiddenField)e.Item.FindControl("hdNombre");
                    String RutMaster = (String)ViewState["Rut"];
                    String cadena = (string)ViewState["cadena"];
                    cadena = cadena + "|V|" + hdRut.Value + "|" + hdNombre.Value;
                    cadena = Utilidades.Seguridad.EncriptarSap(cadena);
                    Server.Transfer("Vinculado.aspx?r=" +  cadena);
                    break;
            }

        }
        protected void rpVinculador_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            HiddenField hdNombre;
            hdNombre = (HiddenField)e.Item.FindControl("hdNombrev");
            lbNombreDes.Text = hdNombre.Value;
            //AjaxControlToolkit.ModalPopupExtender modal = (AjaxControlToolkit.ModalPopupExtender)e.Item.FindControl("LinkButton3_ModalPopupExtender");
            HiddenField hd = (HiddenField)e.Item.FindControl("hdRutVincu");
            ViewState["RutVinculador"] = hd.Value;
            Panel1.Visible = true;
            //modal.Show();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            String Rutvinculador = (String)ViewState["RutVinculador"];
            String Rut = (String)ViewState["Rut"];
            PacienteDao pacDao = new PacienteDao();
            if (Rutvinculador != null)
            {
                pacDao.SetVinculados(Rutvinculador, Rut, "2");
                List<Paciente> lstVinculador = new List<Paciente>();
                Paciente pac = new Paciente();
                pac = pacDao.GetPaciente(Rut);
                pacDao.GetVinculados(pac.BP, out lstVinculador);
                rpVinculador.DataSource = lstVinculador;
                rpVinculador.DataBind();                
                Panel1.Visible = false;
            }
            else
            {
                pacDao.SetVinculados(Rut, ViewState["rutvinculado"].ToString(), "2");
                List<Paciente> lstVinculadores = new List<Paciente>();
                Paciente pac = new Paciente();
                pac = pacDao.GetPaciente(Rut);
                rpVinculados.DataSource = pacDao.GetVinculados(pac.BP, out lstVinculadores);
                rpVinculados.DataBind();
                Panel1.Visible = false;


            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }
    }
}
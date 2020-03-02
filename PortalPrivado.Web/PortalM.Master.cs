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
    public partial class PortalM : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                String[] master;
                String cadena;
                string a = Request.Url.LocalPath;
                HttpContext context = HttpContext.Current;               
                string base64Encoded = hdToken.Value;
                byte[] data = System.Convert.FromBase64String(base64Encoded);
                string base64Decoded = System.Text.ASCIIEncoding.ASCII.GetString(data);
                master = base64Decoded.Split('|');
                string[] parametros = Utilidades.Seguridad.DesEncriptarSap(base64Encoded, out cadena);
                ViewState["parametros"] = parametros;
                MenuDao oMenudao = new MenuDao();
                Paciente oPaciente = new Paciente();
                PacienteDao oPacienteDao = new PacienteDao();
                aSession.HRef = Recursos.UrlAgendaPublica + "logout";
                aVolver.HRef = Recursos.UrlAgendaPublica + "logout";
                if (hdTipo.Value.Equals("V"))
                {
                    ViewState["rut"] = master[3];
                    oPaciente = oPacienteDao.GetPaciente(master[3]);
                    lbNombreVinc.Text = master[7];
                    lbNombreMaster.Text = oPaciente.Nombre + " " + oPaciente.Apellidos;
                    hdRutMaster.Value = master[6];
                }
                else
                {
                    ViewState["rut"] = master[3];
                    oPaciente = oPacienteDao.GetPaciente(parametros[3]);
                    lbNombre.Text = oPaciente.Nombre + " " + oPaciente.Apellidos;
                    hdRutMaster.Value = oPaciente.Rut;
                } 
                List<BO.Menu> lstMenu = oMenudao.GetMenu(oPaciente.BP.TrimStart('0'));
                RpMenu.DataSource = lstMenu;
                RpMenu.DataBind();
                if (!oPacienteDao.Session(master[3]))
                {
                    pnModalSes.Visible = true;
                    //ModalPopupExtender2.Show();
                }
            }
        }

        protected void lkCerrarVincu_Click(object sender, EventArgs e)
        {
            string[] parametros = (string[])ViewState["parametros"];            
            Response.Redirect("ReservaHora.aspx?r=" + Utilidades.Seguridad.EncriptarSap(parametros[0] + "|" + parametros[1] + "|" + 
                parametros[2] + "|" + parametros[3] + "|" + parametros[4]));
        }

        protected void lkCerrar_Click(object sender, EventArgs e)
        {
            pnModalMaster.Visible = true;
            //ModalPopupExtender1.Show();
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            PacienteDao paciente = new PacienteDao();
            if (paciente.CerrarSesion((String)(ViewState["rut"])))
            {
                ltSession.Text = "Su sesión se ha cerrado con éxito";
                LinkButton3.Visible = false;
                LinkButton4.Visible = false;
                aVolver.Visible = true;
            }
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            pnModalMaster.Visible = false;
            //ModalPopupExtender1.Hide();
            
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }
    }
}
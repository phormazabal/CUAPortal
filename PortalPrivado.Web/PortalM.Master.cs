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
                MenuDao oMenudao = new MenuDao();
                Paciente oPaciente = new Paciente();
                PacienteDao oPacienteDao = new PacienteDao();
                oPaciente = oPacienteDao.GetPaciente("13072764-6");
                lbNombre.Text = oPaciente.Nombre + " " + oPaciente.Apellidos;
                List<BO.Menu> lstMenu = oMenudao.GetMenu("2225003");
                RpMenu.DataSource = lstMenu;
                RpMenu.DataBind();
            }
        }
    }
}
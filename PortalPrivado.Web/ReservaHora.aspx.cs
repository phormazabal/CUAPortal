using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.DAO;
using PortalPrivado.BO;

namespace PortalPrivado.Web
{
    public partial class ReservaHora : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MedicoDao oMedico = new MedicoDao();
            oMedico.GetMedicos();
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<String> getBusqueda(string prefixText)
        {
            List<String> lstBusqueda = new List<string>();
           
            return lstBusqueda;
        }
    }
}
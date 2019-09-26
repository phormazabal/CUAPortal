using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using PortalPrivado.BO;
using PortalPrivado.DAO;
namespace PortalPrivado.Web
{
    public partial class Portal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                MenuDao oMenudao = new MenuDao();
                List<Menu> lstMenu = new List<Menu>();
                lstMenu = oMenudao.GetMenu("");
            }
        }
    }
}

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
    public partial class Reserva : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        //[System.Web.Script.Services.ScriptMethod()]
        //[System.Web.Services.WebMethod]
        //public static string[] getBusqueda(string prefixText)
        //{
        //    MedicoDao oMedico = new MedicoDao();
        //    oMedico.GetMedicos();
        //    List<Medicos> lstMed = new List<Medicos>();
        //    lstMed = oMedico.GetMedicos();
        //    var query = from i in lstMed
        //                where i.Nombre.Contains(prefixText) || i.Nombre.Contains(prefixText.ToUpper())
        //                select i;

        //    List<string> lst = new List<string>();
        //    lstMed = query.ToList<Medicos>();
        //    for (int i = 0; i < lstMed.Count; i++)
        //    {
        //        lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(lstMed[i].Nombre, lstMed[i].Rut));
        //    }

        //    return lst.ToArray();
        //}
        //}
    }
}
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

        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        //public static List<String> getBusqueda(string prefixText)
        //{
        //    MedicoDao oMedico = new MedicoDao();
        //    oMedico.GetMedicos();
        //    List<Medicos> lstMed = new List<Medicos>();
        //    lstMed = oMedico.GetMedicos();
        //    var query = from i in lstMed
        //                where i.Nombre.Contains(prefixText) || i.Nombre.Contains(prefixText.ToUpper())
        //                select i.Nombre;

        //    List<string> lst = query.ToList<string>();
        //    if (lst.Count == 1)
        //    {

        //    }
        //    //for (int i = 0; i < lst.Count; i++)
        //    //{
        //    //    lsts.Add(lst[i].Nombre);
        //    //}
        //    return lst;
        //}
        public static string[] getBusqueda(string prefixText)
        {
            MedicoDao oMedico = new MedicoDao();
            oMedico.GetMedicos();
            List<Medicos> lstMed = new List<Medicos>();
            lstMed = oMedico.GetMedicos();
            var query = from i in lstMed
                        where i.Nombre.Contains(prefixText) || i.Nombre.Contains(prefixText.ToUpper())
                        select i;

            List<string> lst = new List<string>();
            lstMed = query.ToList<Medicos>();
            for (int i = 0; i < lstMed.Count; i++)
            {
                lst.Add(AjaxControlToolkit.AutoCompleteExtender.CreateAutoCompleteItem(lstMed[i].Nombre, lstMed[i].RutMedico));
            }
            
            return lst.ToArray();
        }
    }
}
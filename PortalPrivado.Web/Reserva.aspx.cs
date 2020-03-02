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
            if (!Page.IsPostBack)
            {
                String cadena;
                String[] master = Utilidades.Seguridad.DesEncriptarSap(Request.QueryString["r"], out cadena);
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
                String Rut = "";
                String RutMaster = master[3];
                if (master.Length > 6)
                {
                    Rut = master[6];
                    HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                    hdtipo.Value = "V";
                }
                else
                    Rut = master[3];
                HttpContext context;
                context = HttpContext.Current;
                Cita cita = new Cita();
                lbMedico.Text = (String)context.Items["NombreMed"];
                cita = (Cita)context.Items["Cita"];
                lbEspecialidad.Text = (String)context.Items["Especialidad"];
                lbFecha.Text = cita.Fecreserva.Substring(0,2) + "/" + cita.Fecreserva.Substring(2, 2)
                    + "/" + cita.Fecreserva.Substring(4, 4);
                lbHora.Text = cita.Horareserva.Substring(0,2) + ":" + cita.Horareserva.Substring(2, 2);
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Reserva de hora > Agendamiento >";
                PacienteDao oPaciente = new PacienteDao();
                
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
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
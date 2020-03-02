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
    public partial class ExamenLab : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<String> Compartir = new List<String>();
                ViewState["Compartir"] = Compartir;
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
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
                List<Examenes> lst = new List<Examenes>();
                ExamenesDao exDao = new ExamenesDao();
                lst = exDao.GetExamenes(Rut, "1");
                ViewState["Examenes"] = lst;
                grdExam.DataSource = lst;
                grdExam.DataBind();
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Exámenes de Laboratorio >";
                PacienteDao oPaciente = new PacienteDao();                
            }
        }
        protected void grdHistorico_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            Panel1.Visible = false;
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            List<Examenes> lst = new List<Examenes>();
            List<String> Compartir = new List<String>();
            Compartir = (List<String>)ViewState["Compartir"];
            lst = (List<Examenes>)ViewState["Examenes"];
            //Medicos medico = new Medicos();
            //medico = lstMedicos.Find(x => x.Value[0].Rut.Equals(lst[i].ToLower
            for (int i = 0; i < grdExam.Items.Count; i ++)
            {
                String id = grdExam.DataKeys[i].Value.ToString();
                int index = lst.FindIndex(x => x.accession_number.Equals(id));
                CheckBox chk = (CheckBox)grdExam.Items[i].FindControl("chkCompartir");
                if (chk.Checked)
                {
                    lst[index].compartir = "True";
                }
                else
                {
                    lst[index].compartir = "False";
                }            
            }
            ViewState["Examenes"] = lst;
            grdExam.DataSource = lst;
            grdExam.DataBind();
        }

        protected void grdExam_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            List<Examenes> lst = new List<Examenes>();
            lst = (List<Examenes>)ViewState["Examenes"];
            switch (e.CommandName)
            {
                case "A":
                    HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                    
                    Context.Items.Add("pdf", lst[e.Item.DataItemIndex].pdf);
                    Context.Items.Add("prestacion", lst[e.Item.DataItemIndex].prestacion);
                    Context.Items.Add("fecha", lst[e.Item.DataItemIndex].fecha_estudio);
                    Context.Items.Add("imagen", lst[e.Item.DataItemIndex].estudio);
                    Context.Items.Add("urlComp", lst[e.Item.DataItemIndex].compartir_estudio);
                    Context.Items.Add("informante", lst[e.Item.DataItemIndex].informante);
                    Server.Transfer("DetalleExamen.aspx?r=" + hdMaster.Value + "&o=2");
                    break;
                case "C":
                    CheckBox chk = (CheckBox)e.Item.FindControl("chkCompartir");
                    if (chk.Checked)
                    {
                        lst[e.Item.DataItemIndex].compartir = "True";
                        ViewState["Examenes"] = lst;                        
                    }
                    grdExam.DataSource = lst;
                    grdExam.DataBind();
                    break;
            }
            
        }

        protected void lnkCompartir_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            //LinkButton3_ModalPopupExtender.Show();
        }

       

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            List<Examenes> lst = new List<Examenes>();
            lst = (List<Examenes>)ViewState["Examenes"];
            String CuerpoExamen = ""; //= Recursos.CuerpoHtml;
            for (int i = 0; i < grdExam.Items.Count; i++)
            {
                String id = grdExam.DataKeys[i].Value.ToString();
                int index = lst.FindIndex(x => x.accession_number.Equals(id));
                CheckBox chk = (CheckBox)grdExam.Items[i].FindControl("chkCompartir");
                if (chk.Checked)
                {
                    lst[index].compartir = "True";
                }
            }
            foreach (Examenes exam in lst)
            {
                if (exam.compartir.Equals("True"))
                {
                    CuerpoExamen = CuerpoExamen + String.Format(Recursos.CuerpoHtml, exam.prestacion, exam.fecha_estudio, exam.compartir_estudio);
                }
            }
            Utilidades.Comunicacion comunicacion = new Utilidades.Comunicacion();
            String html = String.Format(Recursos.HtmlExamenes, "", CuerpoExamen);
            comunicacion.sendEmailExam(html, txtCompartir.Text);
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
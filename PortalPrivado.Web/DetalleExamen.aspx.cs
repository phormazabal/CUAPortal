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
    public partial class DetalleExamen : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //Label1.Attributes.Add("onclick", "javascript:ActivarPostClickAceptar();" + Page.ClientScript.GetPostBackEventReference(this.Label1, string.Empty) + ";");
                //LinkButton3_ModalPopupExtender.Hide();
                //Label1.Attributes.Add("onclick", "javascript:ActivarPostClickAceptar();" + Page.ClientScript.GetPostBackEventReference(this.Label1, string.Empty) + ";");
                //ModalPopupExtender1.Hide();
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
                ViewState["O"] = Request.QueryString["o"];
                HttpContext context = HttpContext.Current;                
                String pdf = (String)context.Items["pdf"];                
                lbNombreMed.Text = (String)context.Items["informante"];
                lbFechaEstudio.Text = (String)context.Items["fecha"];
                lbNombreEstudio.Text = (String)context.Items["prestacion"];
                String urlEstudio = "";
                ViewState["urlComp"] = (String)context.Items["urlComp"];
                
                urlEstudio = (String)context.Items["imagen"];
                if (urlEstudio != null)
                {
                    pnImg.Visible = true;
                    iFrameXero.Attributes.Add("src", "http://192.168.254.73/?theme=eprDisplay&PatientId=1000000906&user=sap&password=zlinizaz");                    
                }                
                iFrameExam.Attributes.Add("src", pdf);
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Examenes > Detalle Examen >";
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
                
            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            pnExamen.Visible = true;
            //LinkButton3_ModalPopupExtender.Show();
        }
        protected void lkCerraImgrSession_Click(object sender, EventArgs e)
        {
            pnExamen.Visible = false;
            //LinkButton3_ModalPopupExtender.Hide();
        }
        protected void lkVOlver_Click(object sender, EventArgs e)
        {
            HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            String opcion = (String)ViewState["O"];
            switch (opcion)
            {
                case "0":
                    Response.Redirect("ResultadosExamenes.aspx?r=" + hdMaster.Value);
                    break;
                case "1":
                    Response.Redirect("ExamenImagenes.aspx?r=" + hdMaster.Value);
                    break;
                case "2":
                    Response.Redirect("ExamenLab.aspx?r=" + hdMaster.Value);
                    break;
            }             
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {            
            String CuerpoExamen = String.Format(Recursos.CuerpoHtml, lbNombreEstudio.Text, lbFechaEstudio.Text, (String)ViewState["urlComp"]);
            Utilidades.Comunicacion comunicacion = new Utilidades.Comunicacion();
            String html = String.Format(Recursos.HtmlExamenes, "", CuerpoExamen);
            comunicacion.sendEmailExam(html, txtCompartir.Text);
            pnCompartir.Visible = false;
        }


        protected void lkCompartir_Click1(object sender, EventArgs e)
        {
            pnCompartir.Visible = true;
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            pnCompartir.Visible = false;
        }
    }
}
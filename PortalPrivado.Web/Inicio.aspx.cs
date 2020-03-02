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
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Paciente oPaciente = new Paciente();
                PacienteDao oPacienteDao = new PacienteDao();
                String cadena;
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                hdMaster.Value = Request.QueryString["r"];
                string[] decript = Utilidades.Seguridad.DesEncriptarSap(hdMaster.Value, out cadena);
                if (decript.Length > 6)
                {
                    HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                    hdtipo.Value = "V";
                }
                oPaciente = oPacienteDao.GetPaciente(decript[3]);
                lbNombre.Text = oPaciente.Nombre + " " + oPaciente.Apellidos;
                lbDireccion.Text = oPaciente.Direccion;
                lbEmail.Text = oPaciente.Email;
                lbRut.Text = oPaciente.Rut;
                lbTelefono1.Text = oPaciente.Telefono1;
                lbTelefono2.Text = oPaciente.Telefono2;
                lbFechaNac.Text = oPaciente.FechaNacimiento.ToString("dd/MM/yyyy");
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Perfíl Paciente >";
                if (!oPacienteDao.Session(oPaciente.Rut))
                {
                    pnModalSes.Visible = true;
                    ModalPopupExtender1.Show();
                }
            }
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }
    }
}
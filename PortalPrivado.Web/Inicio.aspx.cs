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
                oPaciente = oPacienteDao.GetPaciente("13072764-6");
                lbNombre.Text = oPaciente.Nombre + " " + oPaciente.Apellidos;
                lbDireccion.Text = oPaciente.Direccion;
                lbEmail.Text = oPaciente.Email;
                lbRut.Text = oPaciente.Rut;
                lbTelefono1.Text = oPaciente.Telefono1;
                lbTelefono2.Text = oPaciente.Telefono2;
                lbFechaNac.Text = oPaciente.FechaNacimiento.ToString("dd/MM/yyyy");
                
            }
        }
    }
}
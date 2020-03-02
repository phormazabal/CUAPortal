using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PortalPrivado.BO;
using PortalPrivado.DAO;
namespace PortalPrivado.Web.publica
{
    public partial class CitaAgenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                HttpContext context = HttpContext.Current;
                Cita cita = new Cita();
                Medicos medico = new Medicos();
                cita = (Cita)context.Items["Cita"];
                medico = (Medicos)context.Items["Medico"];
                lbEspecialidad.Text = (String)context.Items["Especialidad"];
                lbFecha.Text = cita.Fecreserva.Substring(0, 2) + "/" + cita.Fecreserva.Substring(2, 2) + "/" +
                    cita.Fecreserva.Substring(4, 4);
                //if (cita.Horareserva.Length == 4)
                    lbHora.Text = cita.Horareserva.Substring(0, 2) + ":" + cita.Horareserva.Substring(2, 2);
                //else
                //    lbHora.Text = cita.Horareserva;
                lbNombreMed.Text = medico.Value[0].Nombres + " " + medico.Value[0].Apellidos;
                aHome.HRef = Recursos.UrlAgendaPublica;
            }
        }
    }
}
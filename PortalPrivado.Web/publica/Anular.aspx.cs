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
    public partial class Anular : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //ReservaDao reserva = new ReservaDao();
            // reserva.GetCita("", "0000948402");
            aOk.HRef = Recursos.UrlAgendaPublica;
            aClose.HRef = Recursos.UrlAgendaPublica;
        }

        protected void lkAnular_Click(object sender, EventArgs e)
        {
            ReservaDao oreserva = new ReservaDao();
            String anular = oreserva.delCita(txtCod.Text);
            Panel1.Visible = false;
            PnAnu.Visible = true;
        }

        protected void lkBuscar_Click(object sender, EventArgs e)
        {
            ReservaDao reserva = new ReservaDao();
            Cita ocita = new Cita();
            if (Utilidades.Seguridad.validarRut(txtRut.Text))
            {
                ocita = reserva.GetCita(txtRut.Text, txtCod.Text);
                if (ocita.Horareserva != null)
                {                    
                    ltEspecialidad.Text = ocita.Especialidad;
                    ltFecha.Text = ocita.Fecreserva.Substring(0, 2) + "/" + ocita.Fecreserva.Substring(2, 2) + "/" +
                    ocita.Fecreserva.Substring(4, 4);
                    ltHora.Text = ocita.Horareserva.Substring(0, 2) + ":" + ocita.Horareserva.Substring(2, 2) + " Hrs.";
                    ltMedico.Text = ocita.Medico;
                    Panel1.Visible = true;
                }
            }            
        }

        protected void lkCancelar_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }

        protected void lkokMsj_Click(object sender, EventArgs e)
        {

        }
    }
}
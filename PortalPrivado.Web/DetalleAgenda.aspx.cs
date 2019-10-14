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
    public partial class DetalleAgenda : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext context;
            context = HttpContext.Current;
            List<Agenda> agendas = new List<Agenda>();
            agendas = (List<Agenda>)context.Items["lstbusqueda"];
            MedicoDao oMedicoDao = new MedicoDao();
            Medicos medico = new Medicos();
            medico = (Medicos)context.Items["Medico"];
            ImgDr.ImageUrl = medico.Value[0].oImagenes.Url;
            lbNombre.Text = medico.Value[0].Nombres + " " + medico.Value[0].Apellidos;
            String fecha = agendas[0].Fecha.Substring(0, 8);
            List<DispoDiaria> lstDis = new List<DispoDiaria>();
            lstDis = oMedicoDao.GetDisponibilidadDiaria(medico.Value[0].VMA, fecha, agendas[0].Id_especialidad);
            dlDisHora.DataSource = lstDis;
            dlDisHora.DataBind();

        }

        protected void calendar_DayRender(object sender, DayRenderEventArgs e)
        {

            if (e.Day.Date.Day == 18)
            {
                e.Cell.Controls.Add(new LiteralControl("<br />14:30"));
                e.Cell.BackColor = System.Drawing.Color.BurlyWood;
                e.Day.IsSelectable = true;
            }
        }
    }
}
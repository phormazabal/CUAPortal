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
    public partial class Especialidad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                HttpContext context = HttpContext.Current;
                List<Medicos> lstMedicos = new List<Medicos>();
                HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
                lstMedicos = (List<Medicos>)context.Items["Medicos"];
                ViewState["lstMedicos"] = lstMedicos;
                lbEspecialidad.Text = (String)context.Items["Especialidad"];
                List<Agenda> lstbusqueda = new List<Agenda>();
                ViewState["Agendas"] = (List<Agenda>)context.Items["Agendas"];
                ViewState["Medicos"] = lstMedicos;
                hdIdEspcialidad.Value = string.Format("{0,10:G}", Convert.ToInt32((String)context.Items["IdEspecialidad"])).Trim();
                hdMaster.Value = Request.QueryString["r"];
                string cadena;
                string[] decript = Utilidades.Seguridad.DesEncriptarSap(hdMaster.Value, out cadena);
                String RutMaster = decript[3];
                if (decript.Length < 6)
                {
                    ViewState["Rut"] = decript[3];

                }
                else
                {
                    ViewState["Rut"] = decript[6];
                    HiddenField hdtipo = (HiddenField)Master.FindControl("hdTipo");
                    hdtipo.Value = "V";
                }
                 MedicoDao medicoDao = new MedicoDao();
                List<BO.Especialidad> lstSub = new List<BO.Especialidad>();
                lstSub = medicoDao.lstSubEsp(hdIdEspcialidad.Value);
                if (lstSub.Count > 1)
                {                    
                    dpSub.DataSource = lstSub;
                    dpSub.DataValueField = "CodEsp";
                    dpSub.DataTextField = "Glosa";
                }
                else
                {
                    lbFiltros.Visible = false;
                    dpSub.Visible = false;
                }
                dpSub.DataBind();
                lbCantidad.Text = " " + lstMedicos.Count.ToString() + " ";
                //if (lstMedicos.Count < 6)
                //{
                //    DataPager1.Visible = false;
                //}
                DataList2.DataSource = lstMedicos;
                DataList2.DataBind();
                ViewState["lstmedicos"] = lstMedicos;
                Literal litPag = (Literal)Master.FindControl("litPag1");
                litPag.Text = "Reserva de hora > Especialidad >";
                PacienteDao oPaciente = new PacienteDao();
                
            }
        }

        protected void btnReservaDirecta_Click(object sender, EventArgs e)
        {
            //MedicoDao medDao = new MedicoDao();
            
            //medDao.GetDisponibilidadDiaria();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            //HttpContext context = HttpContext.Current;
            //String IdMedico = DataList2.DataKeys[e.Item.ItemIndex].ToString();
            //switch (e.CommandName)
            //{
            //    case "ReservaDirecta":
                    
            //        List<Medicos> lstMedicos = new List<Medicos>();
            //        lstMedicos = (List<Medicos>)ViewState["Medicos"];
            //        Medicos medico = new Medicos();
            //        medico = lstMedicos.Find(x => x.IdMedico == IdMedico);
            //        MedicoDao medDao = new MedicoDao();
            //        PacienteDao pacDao = new PacienteDao();
            //        Paciente pac = new Paciente();
            //        List<DispoDiaria> lst = new List<DispoDiaria>();
            //        lst = medDao.GetDisponibilidadDiaria(IdMedico.TrimEnd(' '), medico.FechaServ.Substring(0, 8), medico.IdEspecialidad);
            //        HiddenField rutpac = (HiddenField)Master.FindControl("hdRutMaster");
            //        Cita cita = new Cita();
            //        cita.Utratamiento = lst[0].Utratamiento;
            //        cita.Horareserva = medico.FechaServ.Substring(8, 4);
            //        cita.Medico = IdMedico;
            //        cita.Especialidad = medico.IdEspecialidad;
            //        cita.Rutpac = rutpac.Value;
            //        cita.Rutsol = rutpac.Value;
            //        pac = pacDao.GetPaciente(cita.Rutpac);
            //        cita.Codorigen = "1";
            //        cita.Nompac = pac.Nombre;
            //        cita.Apepatpac = pac.Apellidos;
            //        cita.Fecreserva = medico.FechaServ.Substring(0, 8);
            //        cita.Mail = pac.Email;
            //        cita.Telefono = pac.Telefono1;
                    
            //        Agenda agendas = new Agenda();
            //        agendas.NombreMed = medico.Value[0].Nombres;
            //        agendas.Apepat = medico.Value[0].Apellidos;
            //        agendas.Especialidad = lbEspecialidad.Text;
            //        context.Items.Add("Agenda", agendas);
            //        context.Items.Add("Cita", cita);
            //        Server.Transfer("Confirmacion.aspx");
            //        break;
            //    case "VerAgenda":
            //        List<Agenda> lstbusqueda = new List<Agenda>();
            //        lstbusqueda = (List<Agenda>)ViewState["Agendas"];
            //        Agenda agenda = new Agenda();
            //        agenda = lstbusqueda.Find(x => x.Id_medico == IdMedico);
            //        MedicoDao oMedicoDao = new MedicoDao();
            //        Medicos oMedico = new Medicos();
            //        oMedico = oMedicoDao.GetMedico(agenda.RutMed);
            //        context.Items.Add("Medico", oMedico);
            //        context.Items.Add("Fecha", agenda.Fecha);
            //        context.Items.Add("Agenda", agenda);
            //        Server.Transfer("DetalleAgenda.aspx");
            //        break;
            //}
            
        }

        protected void dpSub_SelectedIndexChanged(object sender, EventArgs e)
        {
            MedicoDao medDao = new MedicoDao();
            List<String> lst = new List<String>();
            lst = medDao.lstMedSub(dpSub.SelectedValue);
            List<Medicos> lstMedicos = new List<Medicos>();
            lstMedicos = (List<Medicos>)ViewState["Medicos"];
            if (!dpSub.SelectedValue.Equals("0"))
            {
                List<Medicos> lstMedicosSub = new List<Medicos>();
                for (int i = 0; i < lst.Count; i++)
                {
                    Medicos medico = new Medicos();
                    medico = lstMedicos.Find(x => x.Value[0].Rut.Equals(lst[i].ToLower()));
                    if (medico != null)
                        lstMedicosSub.Add(medico);
                }
                DataList2.DataSource = lstMedicosSub;
            }
            else
            {
                DataList2.DataSource = lstMedicos;
            }
            DataList2.DataBind();
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            Server.Transfer("ReservaHora.aspx?r=" + hdMaster.Value);
        }

        protected void DataList2_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
           
           
        }

        protected void DataList2_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            List<Medicos> lstMedicos = new List<Medicos>();
            lstMedicos = (List<Medicos>)ViewState["lstmedicos"];
            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            DataList2.DataSource = lstMedicos;
            DataList2.DataBind();
        }

        protected void DataList2_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            HttpContext context = HttpContext.Current;
            String IdMedico = DataList2.DataKeys[e.Item.DataItemIndex].Value.ToString();
            HiddenField hdMaster = (HiddenField)Master.FindControl("hdToken");
            List<Agenda> lstbusqueda = new List<Agenda>();
            lstbusqueda = (List<Agenda>)ViewState["Agendas"];
            Agenda agenda = new Agenda();
            MedicoDao oMedicoDao = new MedicoDao();
            Medicos oMedico = new Medicos();
            switch (e.CommandName)
            {
                case "ReservaDirecta":
                    List<Medicos> lstMedicos = new List<Medicos>();
                    lstMedicos = (List<Medicos>)ViewState["Medicos"];
                    Medicos medico = new Medicos();
                    medico = lstMedicos.Find(x => x.IdMedico == IdMedico);
                    MedicoDao medDao = new MedicoDao();
                    PacienteDao pacDao = new PacienteDao();
                    Paciente pac = new Paciente();
                    List<DispoDiaria> lst = new List<DispoDiaria>();
                    lst = medDao.GetDisponibilidadDiaria(IdMedico.TrimEnd(' '), medico.FechaServ.Substring(0, 8), medico.IdEspecialidad);
                    HiddenField rutpac = (HiddenField)Master.FindControl("hdRutMaster");
                    Cita cita = new Cita();
                    cita.Utratamiento = lst[0].Utratamiento;
                    cita.Horareserva = medico.FechaServ.Substring(8, 4);
                    cita.Medico = IdMedico;
                    cita.Especialidad = medico.IdEspecialidad;
                    cita.Rutpac = rutpac.Value;
                    cita.Rutsol = rutpac.Value;
                    pac = pacDao.GetPaciente(cita.Rutpac);
                    cita.Codorigen = "1";
                    cita.Nompac = pac.Nombre;
                    cita.Apepatpac = pac.Apellidos;
                    cita.Fecreserva = medico.FechaServ.Substring(0, 8);
                    cita.Mail = pac.Email;
                    cita.Telefono = pac.Telefono1;
                    Agenda agendas = new Agenda();
                    agendas.NombreMed = medico.Value[0].Nombres;
                    agendas.Apepat = medico.Value[0].Apellidos;
                    agendas.Especialidad = lbEspecialidad.Text;
                    Context.Items.Add("IdEspecialidad", hdIdEspcialidad.Value);
                    Context.Items.Add("Agendas", lstbusqueda);
                    Context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("origen", "2a");
                    context.Items.Add("Agenda", agendas);
                    context.Items.Add("Cita", cita);
                    Server.Transfer("Confirmacion.aspx?r=" + hdMaster.Value);
                    break;
                case "VerAgenda":
                    agenda = lstbusqueda.Find(x => x.Id_medico == IdMedico);                    
                    oMedico = oMedicoDao.GetMedico(agenda.RutMed);
                    context.Items.Add("IdEspecialidad", hdIdEspcialidad.Value);
                    Context.Items.Add("Agendas", lstbusqueda);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Rut", ViewState["Rut"]);                    
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("origen", "2");
                    Server.Transfer("DetalleAgenda.aspx?r=" + hdMaster.Value);
                    break;
                case "VerPerfil":
                    agenda = lstbusqueda.Find(x => x.Id_medico == IdMedico);
                    oMedico = oMedicoDao.GetMedico(agenda.RutMed);
                    context.Items.Add("IdEspecialidad", hdIdEspcialidad.Value);
                    Context.Items.Add("Agendas", lstbusqueda);
                    context.Items.Add("Especialidad", lbEspecialidad.Text);
                    context.Items.Add("Medicos", ViewState["lstMedicos"]);
                    context.Items.Add("Medico", oMedico);
                    context.Items.Add("Rut", ViewState["Rut"]);
                    context.Items.Add("Agenda", agenda);
                    context.Items.Add("origen", "2");
                    Server.Transfer("PerfilMedico.aspx?r=" + hdMaster.Value);
                    break;
            }

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect(Recursos.UrlInicio);
        }
    }
}
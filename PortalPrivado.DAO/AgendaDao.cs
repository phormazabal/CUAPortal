using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PortalPrivado.BO;
namespace PortalPrivado.DAO
{
    public class AgendaDao
    {
        public List<Agenda> GetAgenda(String IdEspecialidad, String IdMedico)
        {
            try
            {
                Config config = new Config();
                List<Agenda> lstAgenda = new List<Agenda>();
                WsBuscarCita.SI_BuscarCita_osService serv = new WsBuscarCita.SI_BuscarCita_osService();
                WsBuscarCita.DT_BuscarCita dt = new WsBuscarCita.DT_BuscarCita();
                WsBuscarCita.DT_BuscarCitaBuscaOfertaGral dt_info = new WsBuscarCita.DT_BuscarCitaBuscaOfertaGral();
                WsBuscarCita.DT_r_BuscarCita dtr = new WsBuscarCita.DT_r_BuscarCita();
                dt_info.codesp = IdEspecialidad;
                dt_info.idmed = IdMedico;
                dt.BuscaOfertaGral = dt_info;
                serv.Credentials = new NetworkCredential(config.User, config.Pass);
                dtr = serv.SI_BuscarCita_os(dt);
                if (IdEspecialidad.Length == 0)
                    for (int i = 0; i < dtr.BuscaOfertaGral.Length; i++)
                    {
                        if (IdMedico.Equals(dtr.BuscaOfertaGral[i].Id_medico.Trim(' ')))
                        {
                            Agenda oAgenda = new Agenda();
                            oAgenda.Id_especialidad = dtr.BuscaOfertaGral[i].id_especialidad;
                            oAgenda.Especialidad = dtr.BuscaOfertaGral[i].especialidad;
                            oAgenda.Id_medico = dtr.BuscaOfertaGral[i].Id_medico;
                            oAgenda.NombreMed = dtr.BuscaOfertaGral[i].nommed;
                            oAgenda.Apepat = dtr.BuscaOfertaGral[i].apemat;
                            oAgenda.Fecha = dtr.BuscaOfertaGral[i].fecha;
                            oAgenda.RutMed = dtr.BuscaOfertaGral[i].rutmed;
                            lstAgenda.Add(oAgenda);
                        }
                    }
                else
                {
                    for (int i = 0; i < dtr.BuscaOfertaGral.Length; i++)
                    {
                        Agenda oAgenda = new Agenda();
                        oAgenda.Id_especialidad = dtr.BuscaOfertaGral[i].id_especialidad;
                        oAgenda.Especialidad = dtr.BuscaOfertaGral[i].especialidad;
                        oAgenda.Id_medico = dtr.BuscaOfertaGral[i].Id_medico;
                        oAgenda.NombreMed = dtr.BuscaOfertaGral[i].nommed;
                        oAgenda.Apepat = dtr.BuscaOfertaGral[i].apemat;
                        oAgenda.Fecha = dtr.BuscaOfertaGral[i].fecha;
                        oAgenda.RutMed = dtr.BuscaOfertaGral[i].rutmed;
                        lstAgenda.Add(oAgenda);
                    }
                }
              
                return lstAgenda;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

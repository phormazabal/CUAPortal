using System;
using System.Collections.Generic;
using System.Net;
using PortalPrivado.BO;

namespace PortalPrivado.DAO
{
    public class MedicoDao
    {
        public MedicoDao()
        {
        }

        public List<Medicos> GetMedicos()
        {
            try
            {
                Config oConfig = new Config();
                List<Medicos> lstMed = new List<Medicos>();
                WsGetMedicos.SI_os_ObtenerMedicoService serv = new WsGetMedicos.SI_os_ObtenerMedicoService();
                WsGetMedicos.DT_ObtenerMedico dt = new WsGetMedicos.DT_ObtenerMedico();                
                WsGetMedicos.DT_r_ObtenerMedico dtr;
                serv.Credentials = new NetworkCredential("phormazabal", "Wario0862");
                dtr = serv.SI_os_ObtenerMedico(dt);
                for (int i = 0; i < dtr.DatosMedicos.Length; i++)
                {
                    Medicos oMedico = new Medicos();
                    oMedico.Nombre = dtr.DatosMedicos[i].nommed;
                    oMedico.Apellido = dtr.DatosMedicos[i].apemed;
                    oMedico.FechaNacimiento = dtr.DatosMedicos[i].fecnac;
                    oMedico.Idmedico = dtr.DatosMedicos[i].id_medico;
                    oMedico.RutMedico = dtr.DatosMedicos[i].runmed;
                    lstMed.Add(oMedico);

                }
                return lstMed;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<String> lstBusq(List<Medicos> lstMed)
        {
            List<String> lstOut = new List<string>();
            return lstOut;
        }
    }
}

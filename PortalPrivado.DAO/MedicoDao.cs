using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using PortalPrivado.BO;

namespace PortalPrivado.DAO
{
    public class MedicoDao
    {
        public MedicoDao()
        {
        }
       /// <summary>
       /// Consume servicio rest entregado por LFI
       /// </summary>
       /// <param name="Rut"></param>
       /// <returns>Retorna la inforamción cargada en el portal público</returns>
        public Medicos GetMedico(String Rut)
        {
            Config oConfig = new Config();
            Medicos oMedicos = new Medicos();
            //?$filter=Rut eq '10292829-6'
            string sUrlRequest =  oConfig.UrlRestLfi +@"?$filter=Rut eq '" + Rut + "'";
            var json = new WebClient().DownloadString(sUrlRequest);            
            oMedicos = JsonConvert.DeserializeObject<Medicos>(json);
            sUrlRequest = String.Format(oConfig.UrlRestImg, oMedicos.Value[0].Id);
            json = new WebClient().DownloadString(sUrlRequest);
            oMedicos.Value[0].oImagenes = JsonConvert.DeserializeObject<MedicoImagenes>(json);
            return oMedicos;
        }
        /// <summary>
        /// Servicio que trae la información de la disponibilidad diaria por médico
        /// </summary>
        /// <param name="IdMed">VMA</param>
        /// <param name="Fecha">Formato ddMMyyyy</param>
        /// <param name="especialidad">00XX</param>
        /// <returns>Lista con detalle de la disponibilidad en el día preguntado</returns>
        public List<DispoDiaria> GetDisponibilidadDiaria(String idMed, String fecha,String especialidad)
        {
            Config oConfig = new Config();
            List<DispoDiaria> lst = new List<DispoDiaria>();
            WsDispDiaria.SI_DispDiariaxMedico_osService serv = new WsDispDiaria.SI_DispDiariaxMedico_osService();
            WsDispDiaria.DT_DispDiariaxMedico dt = new WsDispDiaria.DT_DispDiariaxMedico();
            WsDispDiaria.DT_DispDiariaxMedicoBuscaOfertaMedica dt_info = new WsDispDiaria.DT_DispDiariaxMedicoBuscaOfertaMedica();
            WsDispDiaria.DT_r_DispDiariaxMedico dr = new WsDispDiaria.DT_r_DispDiariaxMedico();
            serv.Credentials = new NetworkCredential(oConfig.User, oConfig.Pass);
            dt_info.idmed = idMed;
            dt_info.fecha = fecha;
            dt_info.especialidad = especialidad;
            dt.BuscaOfertaMedica = dt_info;
            dr = serv.SI_DispDiariaxMedico_os(dt);
            for (int i = 0; i < dr.BuscaOfertaMedica.Length; i++)
            {
                DispoDiaria oDisponibilida = new DispoDiaria();
                oDisponibilida.Especialidad = dr.BuscaOfertaMedica[i].especialidad;
                oDisponibilida.Estado = dr.BuscaOfertaMedica[i].estado;
                oDisponibilida.Fecha = dr.BuscaOfertaMedica[i].fecate;
                oDisponibilida.Hora = dr.BuscaOfertaMedica[i].horate.Substring(0, 2) + ":"
                    + dr.BuscaOfertaMedica[i].horate.Substring(2,2) + " Hrs";
                oDisponibilida.Utratamiento = dr.BuscaOfertaMedica[i].Utratamiento;
                lst.Add(oDisponibilida);
            }
            return lst;

        }
      
    }
}

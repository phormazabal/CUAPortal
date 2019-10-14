using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PortalPrivado.BO;
namespace PortalPrivado.DAO
{
    public class ReservaDao
    {
        /// <summary>
        /// Estructura que alimenta la busqueda predictiva
        /// </summary>
       
        public List<Busqueda> GetBusqueda()
        {
            Config config = new Config();
            List<Busqueda> lst = new List<Busqueda>();
            WsGetBusqueda.Si_os_busquedaService serv = new WsGetBusqueda.Si_os_busquedaService();
            WsGetBusqueda.DT_Busqueda dt = new WsGetBusqueda.DT_Busqueda();
            dt.IdBusqueda = "";
            WsGetBusqueda.DT_r_BusquedaBusqueda[] dtr;
            serv.Credentials = new NetworkCredential(config.User,config.Pass);
            dtr = serv.Si_os_busqueda(dt);
            for (int i = 0; i < dtr.Length; i++)
            {
                Busqueda oBusqueda = new Busqueda();
                oBusqueda.Id = dtr[i].IdBusqueda;
                oBusqueda.Glosa = dtr[i].Glosa.ToString().ToUpper();
                lst.Add(oBusqueda);
            }
            return lst;
        }
        //public List<Agenda> BuscarCita(String IdMedico,String IdEspecialidad)
        //{
        //    List<Agenda> busquedas = new List<Agenda>();
        //    Config config = new Config();
        //    WsBuscarCita.SI_BuscarCita_osService serv = new WsBuscarCita.SI_BuscarCita_osService();
        //    WsBuscarCita.DT_BuscarCita dt = new WsBuscarCita.DT_BuscarCita();
        //    WsBuscarCita.DT_r_BuscarCita dtr;
           
        //    //dt.BuscaOfertaGral.codesp = IdEspecialidad;
        //    dt.BuscaOfertaGral.idmed = IdMedico;
        //    serv.Credentials = new NetworkCredential(config.User, config.Pass);
        //    dtr = serv.SI_BuscarCita_os(dt);
        //    for (int i = 0; i < dtr.BuscaOfertaGral.Length; i++)
        //    {
        //        Agenda oAgenda = new Agenda();
        //        oAgenda.Apepat = dtr.BuscaOfertaGral[i].apepat;
        //        oAgenda.Apemat = dtr.BuscaOfertaGral[i].apemat;
        //        oAgenda.Especialidad = dtr.BuscaOfertaGral[i].especialidad;
        //        oAgenda.Fecha = dtr.BuscaOfertaGral[i].fecha;
        //        oAgenda.Id_especialidad = dtr.BuscaOfertaGral[i].id_especialidad;
        //        oAgenda.Id_medico = dtr.BuscaOfertaGral[i].Id_medico;
        //        oAgenda.NombreMed = dtr.BuscaOfertaGral[i].nommed;
        //        oAgenda.RutMed = dtr.BuscaOfertaGral[i].rutmed;
        //        busquedas.Add(oAgenda);
        //    }
        //    return busquedas;
        //}
    }
}

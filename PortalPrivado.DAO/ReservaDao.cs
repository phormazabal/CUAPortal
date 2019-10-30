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
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<String> reservar(Reserva reserva)
        {
            List<String> lts = new List<String>();
            WsReserva.SI_ReservaCita_osService serv = new WsReserva.SI_ReservaCita_osService();
            WsReserva.DT_ReservaCita dt = new WsReserva.DT_ReservaCita();
            WsReserva.DT_r_ReservaCita dtr = new WsReserva.DT_r_ReservaCita();
            dt.apepatpac = reserva.Apepatpac;
            dt.codorigen = reserva.Codorigen;
            dt.especialidad = reserva.Especialidad;
            dt.fecreserva = reserva.Fecreserva;
            dt.horareserva = reserva.Horareserva;
            dt.mail = reserva.Mail;
            dt.medico = reserva.Medico;
            dt.nompac = reserva.Nompac;
            dt.rutpac = reserva.Rutpac;
            dt.rutsol = reserva.Rutsol;
            dt.telefono = reserva.Telefono;
            dt.utratamiento = reserva.Utratamiento;
            dtr = serv.SI_ReservaCita_os(dt);
            lts.Add(dtr.codreserva);
            lts.Add(dtr.fechacita);
            lts.Add(dtr.horacita);
            return lts;
        }
    }
}

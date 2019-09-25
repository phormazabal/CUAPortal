using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using PortalPrivado.BO;

namespace PortalPrivado.DAO
{
    public class PacienteDao
    {
        /// <summary>
        /// Retorna la información relacionada a un paciente, tiene como
        /// parametro de entrada el documento de indentificación(Rut Passport)
        /// </summary>
        /// <returns>Objeto con la información de un paciente</returns>
        public Paciente GetPaciente(String DocId)
        {
            Config oConfig = new Config();
            Paciente objPaciente = new Paciente();
            WsInfoPac.SI_os_InfoPacienteService serv = new WsInfoPac.SI_os_InfoPacienteService();
            WsInfoPac.DT_r_InfoPaciente oRInfo = new WsInfoPac.DT_r_InfoPaciente();
            WsInfoPac.DT_InfoPaciente oRut = new WsInfoPac.DT_InfoPaciente();
            oRut.IdPac = DocId;
            serv.Credentials = new NetworkCredential(oConfig.User, oConfig.Pass);
            oRInfo = serv.SI_os_InfoPaciente(oRut);
            objPaciente.Nombre = oRInfo.Nombre;
            objPaciente.Apellidos = oRInfo.AppPat + " " + oRInfo.AppMat;
            objPaciente.Email = oRInfo.Email;
            string Fecha = oRInfo.FechaNacimiento.Substring(6, 2) + "/" + oRInfo.FechaNacimiento.Substring(4, 2) + "/" + oRInfo.FechaNacimiento.Substring(0, 4);
            objPaciente.FechaNacimiento = DateTime.Parse(Fecha);
            objPaciente.Rut = DocId;
            objPaciente.Telefono1 = oRInfo.Telefono1;
            objPaciente.Telefono2 = oRInfo.Telefono2;
            objPaciente.Direccion = oRInfo.Direccion;
            return objPaciente;

        }
        
    }
}

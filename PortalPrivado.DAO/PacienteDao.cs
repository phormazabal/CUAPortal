using System;
using System.Collections.Generic;
using System.Linq;
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
            Paciente objPaciente = new Paciente();          
            
            return objPaciente;

        }
        
    }
}

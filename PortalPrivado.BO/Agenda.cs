using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalPrivado.BO
{
    [Serializable]
    public class Agenda
    {
        String _RutMed;
        String _NombreMed;
        String _apepat;
        String _apemat;
        String _fecha;
        String _especialidad;
        String _Id_medico;
        String _id_especialidad;

        public string RutMed { get => _RutMed; set => _RutMed = value; }
        public string NombreMed { get => _NombreMed; set => _NombreMed = value; }
        public string Apepat { get => _apepat; set => _apepat = value; }
        public string Fecha { get => _fecha; set => _fecha = value; }
        public string Especialidad { get => _especialidad; set => _especialidad = value; }
        public string Id_medico { get => _Id_medico; set => _Id_medico = value; }
        public string Id_especialidad { get => _id_especialidad; set => _id_especialidad = value; }
        public string Apemat { get => _apemat; set => _apemat = value; }
    }
}

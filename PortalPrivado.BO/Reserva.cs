using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalPrivado.BO
{
    [Serializable]
    public class Reserva
    {
        String _rutsol;
        String _nompac;
        String _apepatpac;
        String _telefono;
        String _mail;
        String _rutpac;
        String _fecreserva;
        String _horareserva;
        String _codorigen;
        String _medico;
        String _utratamiento;
        String _especialidad;

        public string Rutsol { get => _rutsol; set => _rutsol = value; }
        public string Nompac { get => _nompac; set => _nompac = value; }
        public string Apepatpac { get => _apepatpac; set => _apepatpac = value; }
        public string Telefono { get => _telefono; set => _telefono = value; }
        public string Mail { get => _mail; set => _mail = value; }
        public string Rutpac { get => _rutpac; set => _rutpac = value; }
        public string Fecreserva { get => _fecreserva; set => _fecreserva = value; }
        public string Horareserva { get => _horareserva; set => _horareserva = value; }
        public string Codorigen { get => _codorigen; set => _codorigen = value; }
        public string Medico { get => _medico; set => _medico = value; }
        public string Utratamiento { get => _utratamiento; set => _utratamiento = value; }
        public string Especialidad { get => _especialidad; set => _especialidad = value; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalPrivado.BO
{
    [Serializable]
    public class DispoDiaria
    {
        String _Fecha;
        String _Hora;
        String _Estado;
        String _Utratamiento;
        String _Especialidad;

        public string Fecha { get => _Fecha; set => _Fecha = value; }
        public string Hora { get => _Hora; set => _Hora = value; }
        public string Estado { get => _Estado; set => _Estado = value; }
        public string Utratamiento { get => _Utratamiento; set => _Utratamiento = value; }
        public string Especialidad { get => _Especialidad; set => _Especialidad = value; }
    }
}

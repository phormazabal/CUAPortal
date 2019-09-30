using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PortalPrivado.BO
{
    public class Medicos
    {
        String _Nombre;
        String _Apellido;
        String _Idmedico;
        String _RutMedico;
        String _FechaNacimiento;

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellido { get => _Apellido; set => _Apellido = value; }
        public string Idmedico { get => _Idmedico; set => _Idmedico = value; }
        public string RutMedico { get => _RutMedico; set => _RutMedico = value; }
        public string FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
    }
}
        
    


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalPrivado.BO
{
    public class Paciente
    {
        String _Nombre;
        String _Apellidos;
        String _Email;
        String _Telefono1;
        String _Telefono2;
        String _Password;
        DateTime _FechaNacimiento;
        String _Rut;

        public string Nombre { get => _Nombre; set => _Nombre = value; }
        public string Apellidos { get => _Apellidos; set => _Apellidos = value; }
        public string Email { get => _Email; set => _Email = value; }
        public string Telefono1 { get => _Telefono1; set => _Telefono1 = value; }
        public string Telefono2 { get => _Telefono2; set => _Telefono2 = value; }
        public string Password { get => _Password; set => _Password = value; }
        public DateTime FechaNacimiento { get => _FechaNacimiento; set => _FechaNacimiento = value; }
        public string Rut { get => _Rut; set => _Rut = value; }
    }
}

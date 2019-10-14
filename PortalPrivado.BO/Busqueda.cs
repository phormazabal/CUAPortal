using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalPrivado.BO
{
    public class Busqueda
    {
        String _Id;
        String _Glosa;

        public string Id { get => _Id; set => _Id = value; }
        public string Glosa { get => _Glosa; set => _Glosa = value; }
    }
}

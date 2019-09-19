using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalPrivado.BO
{
    public class SubMenu
    {
        String _IdSubMenu;
        String _Glosa;
        String _Url;

        public string IdSubMenu { get => _IdSubMenu; set => _IdSubMenu = value; }
        public string Glosa { get => _Glosa; set => _Glosa = value; }
        public string Url { get => _Url; set => _Url = value; }
    }
}

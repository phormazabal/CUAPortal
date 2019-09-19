using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalPrivado.BO
{
    public class Menu
    {
        String _IdMenu;
        String _GlosaMenu;
        String _Url;

        public string IdMenu { get => _IdMenu; set => _IdMenu = value; }
        public string GlosaMenu { get => _GlosaMenu; set => _GlosaMenu = value; }
        public string Url { get => _Url; set => _Url = value; }

        public List<SubMenu> SubMenu
        {
            get => default;
            set
            {
            }
        }
    }
}

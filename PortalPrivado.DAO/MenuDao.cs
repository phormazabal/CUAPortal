using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Net;
using PortalPrivado.BO;
namespace PortalPrivado.DAO
{
    public class MenuDao
    {
        public List<Menu> GetMenu()
        {
            try
            {
                List<Menu> lstMenu = new List<Menu>();
                WsMenu.SI_os_GetMenuService serv = new WsMenu.SI_os_GetMenuService();
                WsMenu.DT_r_GetMenuMenu[] GetMenu;
                WsMenu.DT_GetMenu dT_GetMenu = new WsMenu.DT_GetMenu();
                dT_GetMenu.IdMenu = "";
                serv.Credentials = new NetworkCredential("phormazabal", "Clinica2019");
                GetMenu = serv.SI_os_GetMenu(dT_GetMenu);
                serv.Dispose();
				for (int i = 0; i < GetMenu.Length; i++)
				{
					Menu objMenu = new Menu();
					objMenu.IdMenu = GetMenu[i].IdMenu;
					objMenu.GlosaMenu = GetMenu[i].Glosa;
				}
                return lstMenu;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

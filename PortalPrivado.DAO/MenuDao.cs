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
                Config oConfig = new Config();
                List<Menu> lstMenu = new List<Menu>();
                WsMenu.SI_os_GetMenuService serv = new WsMenu.SI_os_GetMenuService();
                WsMenu.DT_r_GetMenuMenu[] GetMenu;
                WsMenu.DT_GetMenu dT_GetMenu = new WsMenu.DT_GetMenu();
                dT_GetMenu.IdMenu = "";
                serv.Credentials = new NetworkCredential(oConfig.User, oConfig.Pass);
                GetMenu = serv.SI_os_GetMenu(dT_GetMenu);
                serv.Dispose();
				for (int i = 0; i < GetMenu.Length; i++)
				{
					Menu objMenu = new Menu();
					objMenu.IdMenu = GetMenu[i].IdMenu;
					objMenu.GlosaMenu = GetMenu[i].Glosa;
                    objMenu.Url = GetMenu[i].URL;
                    if (GetMenu[i].SubMenu != null)
                    for (int j = 0; j < GetMenu[i].SubMenu.Length; j++)
                    {
                        SubMenu oSubMenu = new SubMenu();
                        oSubMenu.IdSubMenu = GetMenu[i].SubMenu[j].IdSubMenu;
                        oSubMenu.Glosa = GetMenu[i].SubMenu[j].GlosaSubMenu;
                        oSubMenu.Url = GetMenu[i].SubMenu[j].URL;
                        objMenu.lstSubMenu.Add(oSubMenu);
                    }
                    lstMenu.Add(objMenu);
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

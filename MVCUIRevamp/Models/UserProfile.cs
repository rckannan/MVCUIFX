using System;
using System.Collections.Generic;


namespace RithV.FX.Models
{
    public class WebMenus
    {
        public List<WebMenu> Menus { get; private set; }

        public WebMenus()
        {
            Menus = new List<WebMenu>
            {
                new WebMenu()
                {
                    DisplayName = "Dashboard1",
                    Action = "Index",
                    Controller = "Home",
                    IconName = "glyph-icon icon-dashboard",
                    isPatent = true,

                    ChildMenus = new List<WebMenu>
                    {
                        new WebMenu()
                        {
                           DisplayName = "Dashboard1.1",
                            Action = "Fetch",
                            Controller = "users"
                        },
                        new WebMenu()
                        {
                            DisplayName = "Dashboard1.2",
                            Action = "Fetch",
                            Controller = "Roles"
                        }
                    }
                },
                new WebMenu()
                {
                    DisplayName = "Dashboard2",
                    Action = "Contact",
                    Controller = "Home",
                    IconName = "glyph-icon icon-dashboard",
                    isPatent = true,
                    ChildMenus = new List<WebMenu>
                    {
                        new WebMenu()
                        {
                           DisplayName = "Dashboard2.1",
                            Action = "Test3",
                            Controller = "Home"
                        },
                        new WebMenu()
                        {
                            DisplayName = "Dashboard2.2",
                            Action = "Test4",
                            Controller = "Home"
                        }
                    }
                }
            };

        }
    }

    public class WebMenu
    {
        public string DisplayName { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }

        public string IconName { get; set; }
        public bool isPatent { get; set; }
        public List<WebMenu> ChildMenus { get; set; }

        public WebMenu()
        {
            ChildMenus = new List<WebMenu>();
            isPatent = false;
        }

    }

    public class UserLogin
    {
        public Int64 UserID { get; set; }
        public string UserName { get; set; }

        public UserLogin()
        {
            UserID = 1;
            UserName = "Kannan";
        }
    }
}

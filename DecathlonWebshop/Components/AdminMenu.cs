using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DecathlonWebshop.Components
{
    public class AdminMenu:ViewComponent
    {
        private readonly IStringLocalizer<AdminMenu> _stringLocalizer;

        public AdminMenu(IStringLocalizer<AdminMenu> stringLocalizer)
        {
            _stringLocalizer = stringLocalizer;
        }

        public IViewComponentResult Invoke()
        {
            var menuItems = new List<AdminMenuItem> { new AdminMenuItem()
                {
                //TODO asp vindt resx file niet op locatie "DecathlonWebshop.Resources.Components.AdminMenu"
                    DisplayValue = _stringLocalizer["TXT_UserManagement"],
                    ActionValue = "UserManagement"

                },
                new AdminMenuItem()
                {
                    DisplayValue = _stringLocalizer["TXT_RoleManagement"],
                    ActionValue = "RoleManagement"
                }};

            return View(menuItems);
        }
    }

    public class AdminMenuItem
    {
        public string DisplayValue { get; set; }
        public string ActionValue { get; set; }
    }
}


using Entities.Concretes;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Mvc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mvc.Areas.Admin.ViewComponents
{
    public class AdminMenuViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;
        public AdminMenuViewComponent(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        public ViewViewComponentResult Invoke()
        {
            //we got current user
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            var roles = _userManager.GetRolesAsync(user).Result;
            return View(new UserWithRolesViewModel
            {
                User = user,
                Roles = roles
            });

        }
    }
}

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
    public class UserMenuViewComponent:ViewComponent
    {
        private readonly UserManager<User> _userManager;
        public ViewViewComponentResult Invoke()
        {
            //got current user
            var user = _userManager.GetUserAsync(HttpContext.User).Result;
            return View(new UserViewModel
            {
                User = user
            });
        }
    }
}

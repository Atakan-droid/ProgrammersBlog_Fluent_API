﻿using AutoMapper;
using Core.Utilities.Extensions;
using Entities.Concretes;
using Entities.Dtos;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mvc.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Mvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IMapper _mapper;
        public UserController(UserManager<User> userManager, IWebHostEnvironment env,IMapper mapper)
        {
            _userManager = userManager;
            _env = env;
            _mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            var users = await _userManager.Users.ToListAsync();

            return View(new UserListDto
            {
                Users = users,
                ResultStatus=Core.Utilities.Results.Complex_Types.ResultStatus.Success
            }); ;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return PartialView("_UserAddPartial");
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            if (ModelState.IsValid)
            {
                userAddDto.Picture = await ImageUpload(userAddDto);
                var user = _mapper.Map<User>(userAddDto);
                var result = await _userManager.CreateAsync(user,userAddDto.Password);
                if (result.Succeeded)
                {
                    var userAddAjaxModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserDto = new UserDto
                        {
                            ResultStatus = Core.Utilities.Results.Complex_Types.ResultStatus.Success,
                            Message = $"{user.UserName} adlı kullanıcı adına sahip ,kullanıcı baraşyla eklenmiştir.",
                            User = user
                        },
                        UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
                    });
                    return Json(userAddAjaxModel);
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("",err.Description);
                    }
                    var userAddAjaxErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
                    {
                        UserAddDto=userAddDto,
                        UserAddPartial=await this.RenderViewToStringAsync("_UserAddPartial",userAddDto)
                    });
                    return Json(userAddAjaxErrorModel);
                }
            }
            var userAddAjaxModelStateErrorModel = JsonSerializer.Serialize(new UserAddAjaxViewModel
            {
                UserAddDto = userAddDto,
                UserAddPartial = await this.RenderViewToStringAsync("_UserAddPartial", userAddDto)
            });
            return Json(userAddAjaxModelStateErrorModel);

        }
        public async Task<string> ImageUpload(UserAddDto userAddDto)
        {
            //~~/img/user.Pic
            string wwwroot = _env.WebRootPath;
            //string fileName = Path.GetFileNameWithoutExtension(userAddDto.Picture.FileName);
            //.png
            string fileExtension = Path.GetExtension(userAddDto.PictureFile.FileName);
            DateTime dateTime = DateTime.Now;
            string fileName = $"{userAddDto.UserName}_{dateTime.FullDateAndTimeStringWithUnderscore()}{fileExtension}";
            var path = Path.Combine($"{wwwroot}/img", fileName);

            await using(var stream=new FileStream(path, FileMode.Create))
            {
                await userAddDto.PictureFile.CopyToAsync(stream);
            }
            return fileName;
        }
    }
}
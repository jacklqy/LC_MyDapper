using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Zhaoxi.AspNetCore.Interface;
using Zhaoxi.AspNetCore.Model;
using Zhaoxi.AspNetCore.Service;
using Zhaoxi.AspNetCore.Web.Models;

namespace Zhaoxi.AspNetCore.Web.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly IUserService _iUserService;

        public FirstController(ILogger<FirstController> logger,IUserService iUserService)
        {
            _logger = logger;
            _iUserService = iUserService;
        }

        public IActionResult Index()
        {
            {
                //IUserService userService = new UserService();
                //userService.Get<Company>(50000);
            }
            {
                var company = new Company()
                {
                    Name = "朝夕教育003",
                    CreateTime = DateTime.Now,
                    Description = "致力于生态圈",
                    LastModifierId = 1,
                    LastModifyTime = DateTime.Now,
                    CreatorId = 1,
                };
                _iUserService.Insert<Company>(company);
                 
                Company company1 = _iUserService.Get<Company>(1);
                Company company50076 = _iUserService.Get<Company>(50076);
            }
            return View();
        }
         
    }
}

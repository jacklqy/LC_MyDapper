using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Zhaoxi.AspNetCore.Interface;
using Zhaoxi.AspNetCore.Model;
using Zhaoxi.AspNetCore.Service;
using Zhaoxi.AspNetCore.Web.Models;

namespace Zhaoxi.AspNetCore.Web.Controllers
{
    public class SecondController : Controller
    {
        private readonly ILogger<SecondController> _logger;
        private readonly IUserService _iUserService;
        private readonly IConfiguration _iConfiguration;
        public SecondController(ILogger<SecondController> logger,IUserService iUserService, IConfiguration configuration)
        {
            _logger = logger;
            _iUserService = iUserService;
            _iConfiguration = configuration;
        }

        public IActionResult Index()
        {
            base.ViewBag.Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm ss");
            base.ViewBag.Port = _iConfiguration["port"]; 
            return View();
        }

        public IActionResult IndexCache()
        {
            object strResult=  _iUserService.GetString();
            return View(strResult);
        }

    }
}

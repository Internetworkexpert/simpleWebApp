﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CloudFunBC.Models;
using Microsoft.Extensions.Configuration;

namespace CloudFunBC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public IActionResult Index()
        {
            ViewBag.ShowSetting = false;
            if (!string.IsNullOrEmpty(_config.GetValue<string>("RegularSetting")))
            {
                ViewBag.Regular = _config.GetValue<string>("RegularSetting");
                ViewBag.ShowSetting = true;
            }
            if (!string.IsNullOrEmpty(_config.GetValue<string>("SensitiveSetting")))
            {
                ViewBag.Sensitive = _config.GetValue<string>("SensitiveSetting");
                ViewBag.ShowSetting = true;
            }
            

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}

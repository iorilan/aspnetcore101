using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CityService.DbModels;
using Microsoft.AspNetCore.Mvc;
using CityService.Models;
using CityService.Repo;
using Microsoft.EntityFrameworkCore;

namespace CityService.Controllers
{
    public class HomeController : Controller
    {
        private CityDbContext _db;

        public HomeController(CityDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            var all = _db.Cities.ToList();
            return View(all);

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

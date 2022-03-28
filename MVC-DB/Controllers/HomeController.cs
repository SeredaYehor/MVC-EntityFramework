using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC_DB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_DB.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DbModel local = new DbModel();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AddToDb(Worker worker)
        {
            List<Worker> result = new List<Worker>();
            local.example.Add(worker);
            local.SaveChanges();
            result = local.example.Select(x => x).ToList();
            return View("GetData", result);
        }

        public IActionResult RemoveFromDb(int id)
        {
            Worker remove = new Worker();
            List<Worker> result = new List<Worker>();
            remove = local.example.Find(id);
            local.example.Remove(remove);
            local.SaveChanges();
            result = local.example.Select(x => x).ToList();
            return View("GetData", result);
        }

        public IActionResult Update(int id, string login)
        {
            Worker edit = new Worker();
            Worker updated = new Worker();
            updated.ID = id;
            updated.Login = login;
            List<Worker> result = new List<Worker>();
            edit = local.example.Find(id);
            if (edit != null)
            {
                local.Entry(edit).CurrentValues.SetValues(updated);
                local.SaveChanges();
            }
            result = local.example.Select(x => x).ToList();
            return View("GetData", result);
        }
        public IActionResult GetData()
        {
            List<Worker> result = new List<Worker>();
            result = local.example.Select(x => x).ToList();
            return View(result);
        }
        public IActionResult Index()
        {
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyCurator_MVC.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeyCurator_MVC.Controllers
{
    
    public class DevelopmentController : Controller
    {
        private ApplicationDbContext _context;
        public DevelopmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {

            var username = HttpContext.Session.GetString("username");
            var number = HttpContext.Session.GetInt32("Number");

            Console.WriteLine($"We have {username} and the number {number}");

            var item = _context.Items.Where(i => i.ItemId == 1).SingleOrDefault();


            

            return View();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace HeyCurator_MVC.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private ItemDateService _dateService;
        private DataAccessService _data;

        private object dbLock;

        public AdminController(ApplicationDbContext context, ItemDateService dateService, DataAccessService data)
        {
            _context = context;
            _dateService = dateService;
            _data = data;
            dbLock = new object();
        }

        //public IActionResult Home()
        //{
        //    return View();
        //}


        public IActionResult Index()
        {
            


            return View();
        }


        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            _dateService.UpdateItemDates(item);
            _context.Items.Add(item);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to create item.");
            }

            return RedirectToAction("Index");
        }




        [HttpPost]
        public IActionResult AddCuratorRole(CuratorRole role)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (_context.CuratorRoles.Any(cr => cr.NameOfRole == role.NameOfRole))
            {
                return RedirectToAction("Index");
            }

            _context.CuratorRoles.Add(role);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to create role.");
            }

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult AddCuratorSpace(CuratorSpace curatorSpace)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            if (_context.CuratorSpaces.Any(cs => cs.Name == curatorSpace.Name))
            {
                return RedirectToAction("Index");
            }
            _context.CuratorSpaces.Add(curatorSpace);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to create role.");
            }


            return RedirectToAction("Index");
        }





    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.Services;
using HeyCurator_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HeyCurator_MVC.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private ItemDateService _dateService;
        private DataAccessService _data;
        private ItemCountService _itemService;
        private object dbLock;

        public AdminController(ApplicationDbContext context, ItemDateService dateService, DataAccessService data, ItemCountService itemService)
        {
            _context = context;
            _dateService = dateService;
            _data = data;
            _itemService = itemService;
            dbLock = new object();
        }


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

        [HttpPost]
        public IActionResult AddExhibitSpace(ExhibitSpace exhibitSpace)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            _context.ExhibitSpaces.Add(exhibitSpace);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to create exhibit space.");
            }


            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult AddExhibit(Exhibit exhibit)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            exhibit.ExhibitSpace = _context.ExhibitSpaces.Where(e => e.ExhibitSpaceId == exhibit.ExhibitSpaceId).Include(es => es.CuratorSpace).FirstOrDefault();

            exhibit.CuratorSpaceId = (int)exhibit.ExhibitSpace.CuratorSpaceId;

            _context.Exhibits.Add(exhibit);

            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to add exhibit.");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddStorage(Storage storage)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
           
            _context.Storages.Add(storage);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to add exhibit.");
            }
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult AddItemInStorageViewModel(AddItemInStorageViewModel itemInStorageViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            ItemInStorage iis = new ItemInStorage
            {
                ItemId = itemInStorageViewModel.ItemId,
                StorageCount = itemInStorageViewModel.StorageCount,
                StorageId = itemInStorageViewModel.StorageId
            };
            
            
            
            ExhibitSpace es = _context.Exhibits.Where(e => e.ExhibitId == itemInStorageViewModel.ExhibitId).Select(e => e.ExhibitSpace).SingleOrDefault();

            iis.CuratorSpaceId = es.CuratorSpaceId;

            StorageCuratorSpace scs = new StorageCuratorSpace
            {
                StorageId = iis.StorageId,
                CuratorSpaceId = (int)es.CuratorSpaceId
            };

            _context.ItemInStorages.Add(iis);
            _context.StorageCuratorSpaces.Add(scs);

            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to add Item in storage or Storage relation to curator space.");
            }

            _context.Entry(iis).GetDatabaseValues();

            ExhibitItemInStorage eiis = new ExhibitItemInStorage
            {
                ExhibitId = itemInStorageViewModel.ExhibitId,
                ItemInStorageId = iis.ItemInStorageId
            };

            _context.ExhibitItemInStorages.Add(eiis);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to connect exhibit to item in storage.");
            }

            _itemService.UpdateItemReserveAmount(iis.ItemId);

            return RedirectToAction("Index");
        }


        public IActionResult AssignedEmployeeRole(EmployeeRoleViewModel model)
        {
            EmployeeRoles role = new EmployeeRoles
            {
                EmployeeId = model.EmployeeId,
                CuratorRoleId = model.CuratorRoleId
            };

            _context.EmployeeRoles.Add(role);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to assign role to employee.");
            }


            return RedirectToAction("Index");
        }

    }
}
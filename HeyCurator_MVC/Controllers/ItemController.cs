using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.Services;
using HeyCurator_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;

namespace HeyCurator_MVC.Controllers
{
    public class ItemController : Controller
    {

        private ApplicationDbContext _context;
        private ItemCountService _itemCountService;
        private EmployeeService _employeeService;
        private object dbLock;
        private RecordAccessService _recordAccess;
        private ItemDateService _itemDateService;

        public ItemController(ApplicationDbContext context, ItemCountService itemCountService, EmployeeService employeeService, RecordAccessService recordService, ItemDateService itemDateService)
        {
            _context = context;
            _itemCountService = itemCountService;
            _employeeService = employeeService;
            dbLock = new object();
            _recordAccess = recordService;
            _itemDateService = itemDateService;
        }

        public IActionResult Index()
        {

            var items = _context.Items.AsEnumerable();

            // Return the search page view.
            return View(items);
        }


        public IActionResult Details(int id)
        {
            Item item = GetItem(id);

            //RecordFull itemWithRecord = new RecordFull
            //{
            //    Item = item
            //};

            return View(item);
        }


        
        public PartialViewResult CreateRecordPartial(int id)
        {
            Item item = GetItem(id);
            List<Storage> storages = _itemCountService.GetAllStoragesOfItem(item);


            RecordFull fullRecord = new RecordFull
            {
                Item = item,
                ItemId = item.ItemId
            };

            var partial = new PartialViewResult
            {
                ViewName = "_RecordAddModalPartial",
                ViewData = new ViewDataDictionary<RecordFull>(ViewData, fullRecord)
            };

            return partial;

        }

        public PartialViewResult DisplayRecordsTable(int id)
        {

            List<Record> records = _recordAccess.GetLast10RecordsOfItem(id);

            
            var partial = new PartialViewResult
            {
                ViewName = "_RecordListPartial",
                ViewData = new ViewDataDictionary<List<Record>>(ViewData, records)
            };
            return partial;
        }


        public IActionResult CreateNewRecord(RecordFull fullRecord)
        {
            

            Record record = new Record();
            record.RecordedCount = fullRecord.NewRecordedAmount;
            ItemInStorage iis = _context.ItemInStorages.Where(x => x.ItemId == fullRecord.Item.ItemId && x.StorageId == fullRecord.ChoosenStorageId).SingleOrDefault();
            record.ItemInStorageId = iis.ItemInStorageId;
            record.TimeStamp = DateTime.Now;
            record.RecordNote = fullRecord.RecordedNotesOnUpdate;
            record.Employee = _employeeService.GetCurrentlyLoggedInEmployee();
            record.CuratorVerified = _employeeService.IsEmployeeCuratorOfItem(fullRecord.Item.ItemId);
            _context.Records.Add(record);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Update Record.");
            }

            // Update Item.
            iis.StorageCount = fullRecord.NewRecordedAmount;
            _context.ItemInStorages.Update(iis);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Create Record.");
                
            }
            _itemCountService.UpdateItemReserveAmount(fullRecord.Item.ItemId);

            var viewItem = _context.Items.Where(i => i.ItemId == fullRecord.Item.ItemId).SingleOrDefault();

            _itemDateService.UpdateItemDates(viewItem, record.TimeStamp);

            return View("Details", viewItem);
            
        }


        private Item GetItem(int id) =>
            _context.Items.Where(i => i.ItemId == id).SingleOrDefault();

        [HttpGet]
        public IActionResult PurchaseRequest(int id)
        {



            PurchaserNotification request = new PurchaserNotification();




            return View(request);
        }

        [HttpPost]
        public IActionResult CreatePurchaseRequest(PurchaserNotification request)
        {

            return View();
        }

        [HttpGet]
        public PartialViewResult ModifyRecordPartial(int id)
        {
            var record = _context.Records.Where(r => r.RecordId == id).SingleOrDefault();


            var partial = new PartialViewResult
            {
                ViewName = "_RecordModifyModalPartial",
                ViewData = new ViewDataDictionary<Record>(ViewData, record)
            };

            return partial;
        }

        [HttpPost]
        public IActionResult ModifyRecord(Record record)
        {
            if(!ModelState.IsValid)
            {
                return RedirectToAction("Home", "Home");
            }

            record.TimeStamp = _context.Records.Where(r => r.RecordId == record.RecordId).Select(r => r.TimeStamp).SingleOrDefault();

            var viewItem = _context.ItemInStorages.Where(i => record.ItemInStorageId == i.ItemInStorageId).Include(i=> i.Item).SingleOrDefault();
            record.CuratorVerified = _employeeService.IsEmployeeCuratorOfItem(viewItem.ItemId);
            _context.Records.Update(record);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Update Record.");
                
            }
            var lastRecord = _context.Records.Where(r=> r.ItemInStorageId == viewItem.ItemInStorageId).OrderBy(r => r.TimeStamp).Last();
            if(record.RecordId == lastRecord.RecordId)
            {
                viewItem.StorageCount = record.RecordedCount;
                _context.ItemInStorages.Update(viewItem);
                try
                {
                    lock (dbLock)
                    {
                        _context.SaveChanges();
                    }
                }
                catch
                {
                    throw new Exception("Unable to Update Record.");

                }
                _itemDateService.UpdateItemDates(viewItem.Item, record.TimeStamp);

            }

            _itemCountService.UpdateItemReserveAmount(viewItem.ItemId);

            return View("Details", viewItem.Item);
        }
    }
}

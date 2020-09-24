using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HeyCurator_MVC.Services
{
    public class ItemCountService
    {

        private ApplicationDbContext _context;
        private EmployeeService _employeeService;
        private object dbLock;

        public ItemCountService(ApplicationDbContext context, EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
            dbLock = new object();
        }

        private Item GetItem(int id) =>
            _context.Items.Where(i => i.ItemId == id).SingleOrDefault();

        public void UpdateItemReserveAmount(int itemId)
        {
            Item item = _context.Items.Where(i => i.ItemId == itemId).SingleOrDefault();

            item.RecordedStorageAmount = _context.ItemInStorages.Where(i => i.ItemId == itemId).Select(i => i.StorageCount).Sum();
            _context.Items.Update(item);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Update Item count.");
            }

        }
        public void UpdateAllItemReserveAmount()
        {
            List<int> itemIds = _context.Items.Select(i => i.ItemId).ToList();
            for (int i = 0; i < itemIds.Count(); i++)
            {
                Item item = _context.Items.Where(t => t.ItemId == itemIds[i]).SingleOrDefault();
                item.RecordedStorageAmount = _context.ItemInStorages.Where(s => s.ItemId == itemIds[i]).Select(s => s.StorageCount).Sum();
                _context.Items.Update(item);
            }
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Update All Item counts.");
            }
        }

        public bool ItemMeetsRestockRequirements(int itemId)
        {
            var reserveCount = _context.ItemInStorages.Where(i => i.ItemId == itemId).Select(i => i.StorageCount).Sum();
            Item item = _context.Items.Where(i => i.ItemId == itemId).FirstOrDefault();
            return reserveCount <= item.MinCount;
        }

        public List<Item> ItemsThatMeetRestockRequirement()
        {
            UpdateAllItemReserveAmount();
            return _context.Items.Where(i => i.MinCount <= i.RecordedStorageAmount).ToList();
        }

        public List<Item> EmployeeItemsThatMeetRestockRequirements()
        {
            List<Item> employeeItems = _employeeService.GetEmployeesItems();
            List<Item> matchingItems = new List<Item>();
            foreach (var item in employeeItems)
            {
                if (ItemMeetsRestockRequirements(item.ItemId))
                {
                    matchingItems.Add(item);
                }
            }
            return matchingItems;
        }


        public List<Storage> GetAllStoragesOfItem(int itemId) => GetAllStoragesOfItem(GetItem(itemId));

        public List<Storage> GetAllStoragesOfItem(Item item)
        {
            var items = _context.ItemInStorages.Where(i => i.ItemId == item.ItemId).Select(i => i.Storage);
            if(items == null || items.Count() == 0)
            {
                return new List<Storage>();
            }
            return items.ToList();
        }



        public void CreateNewRecord(RecordFull fullRecord)
        {
            Record record = new Record();



        }




    }
}

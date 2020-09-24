using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;

namespace HeyCurator_MVC.Services
{
    public class ItemDateService
    {
        private ApplicationDbContext _context;
        private object dbLock;
        public ItemDateService(ApplicationDbContext context)
        {
            _context = context;
            dbLock = new object();
        }

        public Item CalculateItemDates(Item item)
        {
            item.DateOfLastUpdate = DateTime.Now;
            item.UpdateByDate = DateTime.Now.AddDays(item.DaysBetweenUpdates);
            item.DateNotifyCurators = item.UpdateByDate.AddDays(item.DaysBeforeNotifyAllCurators);
            return item;
        }
        public void UpdateItemDates(Item item)
        {
            item.DateOfLastUpdate = DateTime.Now;
            item.UpdateByDate = DateTime.Now.AddDays(item.DaysBetweenUpdates);
            item.DateNotifyCurators = item.UpdateByDate.AddDays(item.DaysBeforeNotifyAllCurators);
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
                throw new Exception("Unable to Update Item Update Dates.");
            }
        }
        public void UpdateItemDates(Item item, DateTime timestamp)
        {
            item.DateOfLastUpdate = timestamp;
            item.UpdateByDate = timestamp.AddDays(item.DaysBetweenUpdates);
            item.DateNotifyCurators = item.UpdateByDate.AddDays(item.DaysBeforeNotifyAllCurators);

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
                throw new Exception("Unable to Update Item Update Dates.");
            }

        }
        public List<DateTime> CalculateItemDates(int daysBetweenUpdates, int daysBeforeNotifyAllCurators)
        {
            List<DateTime> itemsDates = new List<DateTime>();
            itemsDates.Add(DateTime.Today);
            itemsDates.Add(itemsDates[0].AddDays(daysBetweenUpdates));
            itemsDates.Add(itemsDates[1].AddDays(daysBeforeNotifyAllCurators));
            return itemsDates;
        }
        public bool IsTimeToUpdate(Item item)
        {
            return DateTime.Now > item.UpdateByDate;
        }
        public bool ShouldNotifyTeam(Item item)
        {
            return DateTime.Now > item.DateNotifyCurators;
        }



    }
}

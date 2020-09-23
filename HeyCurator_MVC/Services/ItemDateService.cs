using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;

namespace HeyCurator_MVC.Services
{
    public class ItemDateService
    {
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

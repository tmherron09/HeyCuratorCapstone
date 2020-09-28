using HeyCurator_MVC.Data;
using HeyCurator_MVC.Hubs;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HeyCurator_MVC.HostedServices
{
    public class InventoryControlBackgroundService : BackgroundService
    {
        private IServiceScopeFactory _serviceScopeFactory;
        public IEnumerable<ExpiredUpdateItem> ExpiredItemsDetected;
        private object dbLock;
        private ICBEventTrigger EventTrigger;
        //private IHubContext<ChatHub> _hub;
        
        public InventoryControlBackgroundService(IServiceScopeFactory serviceScopeFactory, ICBEventTrigger eventTrigger)
        {
            _serviceScopeFactory = serviceScopeFactory;
            ExpiredItemsDetected = PopulateDetected();
            dbLock = new object();
            EventTrigger = eventTrigger;
            //_hub = hub;
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.Run(async () =>
           {
               while (!stoppingToken.IsCancellationRequested)
               {
                   Console.WriteLine("\n\n\nEXECUTING INVENTORY CONTROL\n\n\n\n\n\nEXECUTING INVENTORY CONTROL\n\n\n\n\n\nEXECUTING INVENTORY CONTROL\n\n\n\n\n\nEXECUTING INVENTORY CONTROL\n\n\n");

                   CheckDatabaseForExpirations();
                   CheckForUpdateAllCurator();
                   RemoveUpdatedItems();
                   CheckDatabaseForLowCountItems();
                   RemoveItemsNoLongerLow();

                   await Task.Delay(3000);
               }
           });
        }

        public void CheckDatabaseForExpirations()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var date = DateTime.Now;
                List<Item> itemsDetected = ExpiredItemsDetected.Select(e => e.Item).ToList();
                var expiredItems = _context.Items.Where(i => i.UpdateByDate < date).Where(i => !itemsDetected.Contains(i)).ToList();
                foreach (var item in expiredItems)
                {
                    if (_context.ExpiredUpdateItems.Any(e => e.ItemId == item.ItemId))
                    {
                        var expiredItemInDb = _context.ExpiredUpdateItems.Where(e => e.ItemId == item.ItemId).FirstOrDefault();
                        if (expiredItemInDb.AllCuratorExpiration == false && item.DateNotifyCurators < date)
                        {

                            expiredItemInDb.AllCuratorExpiration = true;
                            _context.ExpiredUpdateItems.Update(expiredItemInDb);
                            lock (dbLock)
                            {
                                _context.SaveChanges();
                            }
                            EventTrigger.UpdatedPendingItems();
                            ExpiredItemsDetected.Append(expiredItemInDb);
                        }
                        continue;
                    }
                    bool NotifyAll = item.DateNotifyCurators < date;
                    ExpiredUpdateItem exItem = new ExpiredUpdateItem(
                        itemId: item.ItemId,
                        allNotified: NotifyAll
                        );
                    _context.ExpiredUpdateItems.Add(exItem);
                    lock (dbLock)
                    {
                        _context.SaveChanges();
                    }
                    EventTrigger.UpdatedPendingItems();
                    ExpiredItemsDetected.Append(exItem);
                }
            }

        }
        public void CheckForUpdateAllCurator()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var date = DateTime.Now;
                var expiredItemsToUpdate = _context.ExpiredUpdateItems.Where(i => i.AllCuratorExpiration == false).Include(i => i.Item).Where(i => i.Item.DateNotifyCurators < date).ToList();
                if (expiredItemsToUpdate.Count() > 0)
                {
                    foreach (var exItem in expiredItemsToUpdate)
                    {
                        exItem.AllCuratorExpiration = true;
                        _context.ExpiredUpdateItems.Update(exItem);
                    }
                    lock (dbLock)
                    {
                        _context.SaveChanges();
                    }
                    EventTrigger.UpdatedPendingItems();
                }
            }
        }

        public void RemoveUpdatedItems()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var updatedItems = _context.ExpiredUpdateItems.Include(e => e.Item).Where(e => e.Item.UpdateByDate > DateTime.Now).ToList();
                for (int i = 0; i < updatedItems.Count(); i++)
                {
                    _context.ExpiredUpdateItems.Remove(updatedItems[i]);
                }
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
        }

        private List<ExpiredUpdateItem> PopulateDetected()
        {

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();

                var exItems = _context.ExpiredUpdateItems.Include(e => e.Item).ToList();

                return exItems;
            }
        }

        private void CheckDatabaseForLowCountItems()
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();


                var lowCountInDb = _context.LowCountItems.Include(i => i.Item).Select(l => l.Item).ToList();
                var lowItems = _context.Items.Where(i => i.RecordedStorageAmount <= i.MinCount).Where(i => !lowCountInDb.Contains(i)).ToList();
                foreach (var item in lowItems)
                {
                    LowCountItem lowItem = new LowCountItem();
                    lowItem.ItemId = item.ItemId;
                    lowItem.Item = item;
                    lowItem.ItemName = item.Name;
                    lowItem.AmountInReserve = item.RecordedStorageAmount;
                    lowItem.PurchaseNotificationMade = false;
                    lowItem.OrderHasBeenMade = false;
                    _context.LowCountItems.Add(lowItem);
                    lock (dbLock)
                    {
                        _context.SaveChanges();
                    }

                }


            }
        }


        private void RemoveItemsNoLongerLow()
        {
            //using (var scope = _serviceScopeFactory.CreateScope())
            //{
            //    var _itemCount = scope.ServiceProvider.GetService<ItemCountService>();
            //    _itemCount.UpdateAllItemReserveAmount();
            //}

            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var _context = scope.ServiceProvider.GetService<ApplicationDbContext>();
                var lowCountInDb = _context.LowCountItems.Include(i => i.Item).ToList();
                

                for (int i = 0; i< lowCountInDb.Count(); i++)
                {
                    if (lowCountInDb[i].Item.RecordedStorageAmount > lowCountInDb[i].Item.MinCount)
                    {
                        _context.LowCountItems.Remove(lowCountInDb[i]);
                    }
                }
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
        }
    }
}


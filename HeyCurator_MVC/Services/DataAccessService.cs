using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Services
{
    public class DataAccessService
    {
        private ItemDateService _itemDateService;
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private object dbLock;



        public IEnumerable<object> Items { get; internal set; }

        public DataAccessService(ItemDateService itemDateService, ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _itemDateService = itemDateService;
            _context = context;
            dbLock = new object();
            _userManager = userManager;
            
        }


        /* Item Access/Populate Methods */

        /// <summary>
        
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Item GetItemById(int itemId)
        {
            lock (dbLock)
            {
                return _context.Items.Where(i => i.ItemId == itemId).FirstOrDefault();
            }
        }

        




        //public List<Item> GetItemsAssignedToCurator(int curatorId)
        //{
        //    Curator curator = _context.Curators.Where(c => c.CuratorId == curatorId).FirstOrDefault();
        //    return GetItemsAssignedToCurator(curator);
        //}

        //public List<Item> GetItemsAssignedToCurator(Curator curator)
        //{
        //    List<int> spaceIds = _context.CuratorAssignments.Where(ca => ca.CuratorId == curator.CuratorId).Select(c => c.CuratorSpaceId).ToList();
        //    List<Item> items = new List<Item>();
        //    foreach (var id in spaceIds)
        //    {
        //        var item = _context.ItemInStorages.Where(s => s.CuratorSpaceId == id).Include(i => i.Item).Select(i => i.Item).ToList();
        //        items.AddRange(item);
        //    }

        //    return items;
        //}

        


        //public List<PendingItemViewModel> GetUserPendingItemVM()
        //{
        //    List<PendingItemViewModel> pendingItems = new List<PendingItemViewModel>();

        //    //var user = await _userManager.GetUserAsync(_claim);
        //    //var claims = await _userManager.GetClaimsAsync(user);

        //    var username = _claim.Identity.Name;
        //    var employee = _context.Employees.Where(e => (e.FirstName) == username).SingleOrDefault();
        //    if(employee == null)
        //    {
        //        employee = _context.Employees.Where(e => (e.FirstName[0] + e.LastName) == username).SingleOrDefault();
        //    }
        //    var curatorIds = _context.Curators.Include(c => c.Employee).Where(c => c.Employee == employee).Select(c=> c.CuratorId).ToList();
        //    var items = _context.ItemInStorages.Where(i => curatorIds.Contains((int)i.CuratorId)).ToList();
            
        //    foreach(var item in items)
        //    {
        //        PendingItemViewModel model = new PendingItemViewModel();
        //        var pendingItem = _context.Items.Where(i => i.ItemId == item.ItemId).First();
        //        model.ItemId = pendingItem.ItemId;
        //        model.CurrentCount = _context.ItemInStorages.Where(s => s.ItemId == item.ItemId).Sum(i => i.StorageCount);
        //        model.ItemName = pendingItem.Name;
        //        model.LastUpdated = pendingItem.DateOfLastUpdate;
        //        model.IsTeamNotified = pendingItem.DateNotifyCurators < DateTime.Now;
        //        pendingItems.Add(model);
        //    }
            
            
        //    return pendingItems;
        //}

        //public void GetExpiredUpdateItems()
        //{
        //    var date = DateTime.Now;
        //    var expiredItems = _context.Items.Where(i => i.UpdateByDate < date).ToList();
        //    foreach (var item in expiredItems)
        //    {
        //        if (_context.ExpiredUpdateItems.Any(e => e.ItemId == item.ItemId))
        //        {

        //            if (item.DateNotifyCurators < date)
        //            {
        //                var expiredItemInDb = _context.ExpiredUpdateItems.Where(e => e.ItemId == item.ItemId).FirstOrDefault();
        //                expiredItemInDb.AllCuratorExpiration = true;
        //                _context.ExpiredUpdateItems.Update(expiredItemInDb);
        //                lock (dbLock)
        //                {
        //                    _context.SaveChanges();
        //                }
        //            }
        //            continue;
        //        }
        //        bool NotifyAll = item.DateNotifyCurators < date;
        //        ExpiredUpdateItem exItem = new ExpiredUpdateItem(
        //            itemId: item.ItemId,
        //            allNotified: NotifyAll
        //            );
        //        _context.ExpiredUpdateItems.Add(exItem);
        //        lock (dbLock)
        //        {
        //            _context.SaveChanges();
        //        }
        //    }
        //}

        public List<ExpiredUpdateItem> SendCuratorExpiredList(string curatorRoles)
        {

            return null;

        }






        /* Access/Populate Curator Method */

        //public List<Curator> GetCuratorsAssignedToItem(Item item)
        //{
        //    lock (dbLock)
        //    {
        //        return _context.ItemInStorages.Where(i => i.ItemId == item.ItemId).Include(i => i.Curator).Select(i => i.Curator).ToList();
        //    }
        //}

        //public List<Curator> GetCuratorsAssignedToItem(int itemId)
        //{
        //    lock (dbLock)
        //    {
        //        var Item = GetItemById(itemId);
        //        return _context.ItemInStorages.Where(i => i.ItemId == Item.ItemId).Include(i => i.Curator).Select(i => i.Curator).ToList();
        //    }
        //}
    }
}

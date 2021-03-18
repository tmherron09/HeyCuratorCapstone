using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HeyCurator_MVC.Services
{
    public class RecordAccessService
    {
        private readonly ApplicationDbContext _context;

        public RecordAccessService(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<Record> GetLastTenRecords()
        {
            if (AreAtLeastTenRecords())
            {
                return _context.Records.OrderByDescending(r => r.TimeStamp).Include(r => r.Employee).Take(10).ToList();
            }
            else
            {
                return _context.Records.OrderByDescending(r => r.TimeStamp).Include(r => r.Employee).ToList();
            }
        }
        //public List<Record> GetAllRecordsOfItem(int itemId)
        //{
        //    var itemInStorageIds = _context.ItemInStorages.Where(i => i.ItemId == itemId).Select(i => i.ItemInStorageId).ToList();
        //    return _context.Records.Where(r => itemInStorageIds.Contains(r.ItemInStorageId)).OrderByDescending(r => r.TimeStamp).Include(r => r.Employee).ToList();
        //}

        //public List<Record> GetLast10RecordsOfItem(int itemId)
        //{
        //    var itemInStorageIds = _context.ItemInStorages.Where(i => i.ItemId == itemId).Select(i => i.ItemInStorageId).ToList();
        //    if (AreAtLeastTenRecordsOfItem(itemId))
        //    {
                
        //        return _context.Records.Where(r => itemInStorageIds.Contains(r.ItemInStorageId)).OrderByDescending(r => r.TimeStamp).Include(r => r.Employee).Take(10).ToList();
        //    }
        //    else
        //    {
        //        var result = _context.Records.Where(r => itemInStorageIds.Contains(r.ItemInStorageId)).OrderByDescending(r => r.TimeStamp).Include(r => r.Employee).ToList();
        //        return result;
        //    }
        //}

        //public List<Record> GetPageOfRecordOfItem(int itemId, int page)
        //{
        //    var itemInStorageIds = _context.ItemInStorages.Where(i => i.ItemId == itemId).Select(i => i.ItemInStorageId).ToList();
        //    var pagesUpUntil = _context.Records.Where(r => itemInStorageIds.Contains(r.ItemInStorageId)).Include(r => r.Employee).Include(r => r.ItemInStorage).ThenInclude(i => i.Storage).Take(page * 10).ToList();
        //    List<Record> requestedPage = new List<Record>();
        //    for (int i = pagesUpUntil.Count() - 10; i < pagesUpUntil.Count(); i++)
        //    {
        //        requestedPage.Add(pagesUpUntil[i]);
        //    }
        //    return requestedPage;
        //}

        public bool AreAtLeastTenRecords()
        {
            var count = _context.Records.ToList().Count();
            return count >= 10;
        }

        //public bool AreAtLeastTenRecordsOfItem(int itemId)
        //{
        //    var itemInStorageIds = _context.ItemInStorages.Where(i => i.ItemId == itemId).Select(i => i.ItemInStorageId).ToList();
        //    var count = _context.Records.Where(r => itemInStorageIds.Contains(r.ItemInStorageId)).ToList().Count();
        //    return count >= 10;
        //}

    }
}

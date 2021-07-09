using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class InventoryControlModelRepository : RepositoryBase<InventoryControlModel>, IInventoryControlModelRepository
    {


        public InventoryControlModelRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfCuratorSpace(int curatorSpaceId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfExhibit(int exhibitId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfItem(int itemId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfStorage(int storageId)
        {
            return await Task.Run(() => 
                _context.StorageItemInstances
                .Where(sii => sii.StorageId == storageId)
                .Select(sii => sii.ItemInstance)
                .Include(ii => ii.InventoryControlModel)
                .Select(ii => ii.InventoryControlModel));
        }

        public async Task<InventoryControlModel> GetInvConModWithRecentRecords(int icmId, int amount)
        {
            var icm = await _context.InventoryControlModels
                .Where(icm => icm.Id == icmId)
                .FirstOrDefaultAsync();
            icm.Records = await _context.Records.Where(r => r.InventoryControlModelID == icmId )
                .OrderByDescending(r=> r.TimeStamp)
                .Take<Record>(amount)
                .ToListAsync();
            return icm;
        }

        public async Task<InventoryControlModel> GetInvConModWithRecords(int icmId)
        {
            return await _context.InventoryControlModels
                .Where(icm => icm.Id == icmId)
                .Include(icm=> icm.Records)
                .FirstOrDefaultAsync();

        }

        public async Task<InventoryControlModel> GetInvConModWithRecordsForTimeSpan(int icmId, TimeSpan timespan)
        {
            var icm = await _context.InventoryControlModels
                .Where(icm => icm.Id == icmId)
                .FirstOrDefaultAsync();
            var dateComparer = DateTime.Now - timespan;
            icm.Records = await _context.Records.Where(r => r.InventoryControlModelID == icmId && r.TimeStamp >= dateComparer).ToListAsync();
            return icm;
            
        }

        public async Task<InventoryControlModel> GetInventoryControlModel(int icmId)
        {
            return await _context.InventoryControlModels.Where(icm => icm.Id == icmId).FirstOrDefaultAsync();
        }

        public async Task<InventoryControlModel> GetInventoryControlModelOfItemInstance(int itemInstanceId)
        {
            throw new NotImplementedException();
        }
    }
}

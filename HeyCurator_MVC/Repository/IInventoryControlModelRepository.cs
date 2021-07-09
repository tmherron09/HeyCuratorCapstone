using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public interface IInventoryControlModelRepository : IRepositoryBase<InventoryControlModel>
    {
        Task<InventoryControlModel> GetInventoryControlModel(int icmId);
        Task<InventoryControlModel> GetInventoryControlModelOfItemInstance(int itemInstanceId);
        Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfItem(int itemId);
        Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfEmployee(int employeeId);
        Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfCuratorSpace(int curatorSpaceId);
        Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfExhibit(int exhibitId);
        Task<IEnumerable<InventoryControlModel>> GetAllInvConModOfStorage(int storageId);

        Task<InventoryControlModel> GetInvConModWithRecords(int icmId);
        Task<InventoryControlModel> GetInvConModWithRecentRecords(int icmId, int amount);
        Task<InventoryControlModel> GetInvConModWithRecordsForTimeSpan(int icmId, TimeSpan timespan);
        

    }
}

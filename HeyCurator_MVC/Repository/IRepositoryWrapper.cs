using HeyCurator_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public interface IRepositoryWrapper
    {

        IEmployeeRepository Employee { get; }
        ICuratorRoleRepository CuratorRole { get; }
        IExhibitSpaceRepository ExhibitSpace { get; }
        IExhibitRepository Exhibit { get; }
        IItemRepository Item { get; }
        IItemInstanceRepository ItemInstance { get; }
        IInventoryControlModelRepository InventoryControlModel { get; }
        IRecordRepository Record { get; }
        IStorageRepository Storage { get; }

    }
}

using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.SearchModels
{
    public class CuratorSpaceSearchModel
    {

        public CuratorSpace CuratorSpace { get; set; }


        public List<CuratorRole> CuratorSpaceCuratorRoles { get; set; }
        public List<Employee> AssignedEmployees { get; set; }
        public List<ExhibitSpace> ExhibitSpaces { get; set; }
        public List<Exhibit> Exhibits { get; set; }
        public List<Item> ExhibitSpaceItems { get; set; }
        public List<Storage> ExhibitSpaceStorages { get; set; }



        // Nullable
        public List<ExpiredUpdateItem> ExpiredItemsInCuratorSpace { get; set; }
        public List<ExpiredUpdateItem> ExpiredItemsInCuratorSpaceWithoutRequestOrOrder { get; set; }
        public List<ExpiredUpdateItem> ExpiredItemsInCuratorSpaceWithRequestOrOrder { get; set; }
        public List<LowCountItem> LowItemCountsInCuratorSpace { get; set; }
        public List<LowCountItem> LowItemCountsInCuratorSpaceWithRequestOrOrder { get; set; }
        public List<LowCountItem> LowItemCountsInCuratorSpaceWithoutRequestOrOrder { get; set; }
        public List<Order> OrdersForCuratorSpace { get; set; }
        public List<PurchaserNotification> PurchaseRequestsForCuratorSpace { get; set; }



    }
}

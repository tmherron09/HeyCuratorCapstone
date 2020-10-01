using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.SearchModels
{
    public class CuratorRoleSearchModel
    {

        public CuratorRole  CuratorRole { get; set; }


        public List<Employee> AssignedEmployees { get; set; }
        public List<CuratorSpace> CuratorSpaces { get; set; }
        public List<ExhibitSpace> CuratorExhibitSpaces { get; set; }
        public List<Exhibit> CuratorExhibits { get; set; }
        public List<Item> CuratorItems { get; set; }
        public List<ItemInStorage> CuratorItemLocations { get; set; }
        public List<Storage> CuratorStorages { get; set; }


        // Nullable
        public List<ExpiredUpdateItem> CuratorAllExpiredItems{ get; set; }
        public List<ExpiredUpdateItem> CuratorExpiredItemsWithoutRequestOrOrder { get; set; }
        public List<ExpiredUpdateItem> CuratorExpiredItemsWithRequestOrOrder { get; set; }
        public List<LowCountItem> CuratorAllLowItemCounts { get; set; }
        public List<LowCountItem> CuratorLowItemCountsWithoutRequestOrOrder { get; set; }
        public List<LowCountItem> CuratorLowItemCountsWithRequestOrOrder { get; set; }
        public List<Order> OrdersByCurator { get; set; }
        public List<Order> OrdersForCuratorItems { get; set; }
        public List<PurchaserNotification> PurchaseRequestsByCurator { get; set; }
        public List<PurchaserNotification> PurchaseRequestsForCuratorItems { get; set; }



    }
}

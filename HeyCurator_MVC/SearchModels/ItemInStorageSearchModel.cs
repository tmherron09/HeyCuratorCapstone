using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.SearchModels
{
    public class ItemInStorageSearchModel
    {

        public ItemInStorage ItemInStorage { get; set; }

        public Item Item { get; set; }
        public Storage ItemStorage { get; set; }
        public List<CuratorRole> AssignedCuratorRoles { get; set; }
        public List<Employee> AssignedEmployees { get; set; }
        public List<CuratorSpace> CuratorSpacesUsingItem { get; set; }
        public List<ExhibitSpace> ExhibitSpacesUsingItem { get; set; }
        public List<Exhibit> ExhibitsUsingItem { get; set; }
        public bool IsExpiredItem { get; set; }
        public bool IsLowCount { get; set; }



        // Nullable
        public Record LatestUpdateRecord { get; set; }
        public List<Record> ItemUpdateRecords { get; set; }
        public List<Order> OrdersByForItem { get; set; }
        public List<Order> OrdersForRelatedItems { get; set; }
        public List<PurchaserNotification> PurchaseRequestsForItem { get; set; }
        public List<PurchaserNotification> PurchaseRequestsForRelatedItems { get; set; }


    }
}

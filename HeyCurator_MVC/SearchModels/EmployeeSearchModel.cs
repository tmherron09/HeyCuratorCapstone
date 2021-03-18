using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.SearchModels
{
    public class EmployeeSearchModel
    {

        public Employee Employee { get; set; }

        public List<CuratorRole> AssignedCuratorRoles { get; set; }
        public List<CuratorSpace> EmployeeCuratorSpaces { get; set; }
        public List<ExhibitSpace> EmployeeExhibitSpaces { get; set; }
        public List<Exhibit> EmployeeExhibits { get; set; }
        public List<Item> EmployeeItems { get; set; }
        public List<Storage> EmployeeStorages { get; set; }
        // Nullable
        public List<ExpiredUpdateItem> EmployeeAllExpiredItems { get; set; }
        public List<ExpiredUpdateItem> EmployeeExpiredItemsWithoutRequestOrOrder { get; set; }
        public List<ExpiredUpdateItem> EmployeeExpiredItemsWithRequestOrOrder { get; set; }
        public List<LowCountItem> EmployeeAllLowItemCounts { get; set; }
        public List<LowCountItem> EmployeeLowItemCountsWithoutRequestOrOrder { get; set; }
        public List<LowCountItem> EmployeeLowItemCountsWithRequestOrOrder { get; set; }
        public List<Order> OrdersByEmployee { get; set; }
        public List<Order> OrdersForEmployeeItems { get; set; }
        public List<PurchaserNotification> PurchaseRequestsByEmployee { get; set; }
        public List<PurchaserNotification> PurchaseRequestsForEmployeeItems { get; set; }


    }
}

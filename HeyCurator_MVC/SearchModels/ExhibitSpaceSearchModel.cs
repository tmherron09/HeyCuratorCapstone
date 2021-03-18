using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.SearchModels
{
    public class ExhibitSpaceSearchModel
    {

        public ExhibitSpace ExhibitSpace { get; set; }

        public List<Exhibit> Exhibits { get; set; }
        public List<Item> ExhibitSpaceItems { get; set; }
        public List<Storage> ExhibitSpaceStorages { get; set; }
        public CuratorSpace CuratorSpace { get; set; }
        public List<CuratorRole> CuratorRoles { get; set; }
        public List<Employee> Employees { get; set; }



        // Nullable
        public List<ExpiredUpdateItem> ExpiredItemsInExhibitSpace { get; set; }
        public List<LowCountItem> LowItemCountsInExhibitSpace { get; set; }
        public List<Order> OrdersForExhibitSpace { get; set; }
        public List<PurchaserNotification> PurchaseRequestsForExhibitSpace { get; set; }



    }
}

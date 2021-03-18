using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.SearchModels
{
    public class ItemSearchModel
    {
        public Item Item { get; set; }

        //public List<ItemInStorage> StorageReferences { get; set; }
        public List<Storage> Storages { get; set; }
        public List<Exhibit> Exhibits { get; set; }
        public List<ExhibitSpace> ExhibitSpaces { get; set; }
        public List<CuratorSpace> CuratorSpaces { get; set; }
        public List<CuratorRole> CuratorRoles { get; set; }
        public List<Employee> Employees { get; set; }
        public bool IsExpired { get; set; }
        public bool IsLowCount { get; set; }


        // Nullable
        public List<Record> Records { get; set; }
        public List<PurchaserNotification> PurchaseRequests { get; set; }
        public List<Order> Orders { get; set; }







    }
}

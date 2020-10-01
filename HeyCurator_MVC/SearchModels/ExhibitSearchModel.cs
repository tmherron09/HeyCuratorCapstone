using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.SearchModels
{
    public class ExhibitSearchModel
    {

        public Exhibit Exhibit { get; set; }

        public List<Item> ExhibitItems { get; set; }
        public List<ItemInStorage> ExhibitItemLocations { get; set; }
        public List<Storage> ExhibitStorages { get; set; }
        public ExhibitSpace ExhibitSpace { get; set; }
        public CuratorSpace CuratorSpace { get; set; }
        public List<CuratorRole> CuratorRoles { get; set; }
        public List<Employee> Employees { get; set; }


    }
}

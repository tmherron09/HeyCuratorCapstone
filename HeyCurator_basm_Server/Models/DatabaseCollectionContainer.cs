using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class DatabaseCollectionContainer
    {

        // Non-Database Objects
        public ICollection<Employee> Employees { get; set; }
        public ICollection<Curator> Curators { get; set; }
        public ICollection<CuratorRole> CuratorRoles { get; set; }
        public ICollection<CuratorSpace> CuratorSpaces { get; set; }
        public ICollection<ExhibitSpace> ExhibitSpaces { get; set; }
        public ICollection<Exhibit> Exhibits { get; set; }
        public ICollection<Storage> Storages { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<ItemInStorage> ItemInStorages { get; set; }
        public ICollection<ExhibitItemInStorage> ExhibitItemInStorages { get; set; }

        public DatabaseCollectionContainer()
        {
            Employees = new List<Employee>();
            Curators = new List<Curator>();
            CuratorRoles = new List<CuratorRole>();
            CuratorSpaces = new List<CuratorSpace>();
            ExhibitSpaces = new List<ExhibitSpace>();
            Exhibits = new List<Exhibit>();
            ExhibitItemInStorages = new List<ExhibitItemInStorage>();
            Storages = new List<Storage>();
            Items = new List<Item>();
            ItemInStorages = new List<ItemInStorage>();

        }
    }
}

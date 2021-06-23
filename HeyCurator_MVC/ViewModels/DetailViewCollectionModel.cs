using HeyCurator_MVC.Models;
using HeyCurator_MVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    /// <summary>
    /// This model is for the Collection Listing withing a Details View. This list all connections without the tree mapping.
    /// </summary>
    public class DetailViewCollectionModel
    {

        public List<Employee> Employees { get; set; }
        public List<CuratorRole> CuratorRoles { get; set; }
        public List<ExhibitSpace> ExhibitSpaces { get; set; }
        public List<Exhibit> Exhibits { get; set; }
        public List<ItemInstance> ItemInstances { get; set; }
        public List<Storage> Storages { get; set; }

        // First Instantiate a new instance, then call one of the preceding methods to populate the model
        public DetailViewCollectionModel()
        {

        }


        public void EmployeeDetailView(IRepositoryWrapper repo, int employeeId)
        {
            throw new NotImplementedException();
        }




    }
}

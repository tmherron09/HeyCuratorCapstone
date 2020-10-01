using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.SearchModels
{
    public interface ISearchModelPopulateService
    {

        ItemSearchModel PopulateItemFullRef(int id);
        ItemSearchModel PopulateItemFullRef(Item item);

        ExhibitSearchModel PopulateExhibitFullRef(int id);
        ExhibitSearchModel PopulateExhibitFullRef(Exhibit exhibit);

        ExhibitSpaceSearchModel PopulateExhibitSpaceFullRef(int id);
        ExhibitSpaceSearchModel PopulateExhibitSpaceFullRef(ExhibitSpace exhibitSpace);

        CuratorSpaceSearchModel PopulateCuratorSpaceFullRef(int id);
        CuratorSpaceSearchModel PopulateCuratorSpaceFullRef(CuratorSpace curatorSpace);

        CuratorRoleSearchModel PupulateCuratorRoleFullRef(int id);
        CuratorRoleSearchModel PopulateCuratorRoleFullRef(CuratorRole curatorRole);

        ItemInStorageSearchModel PopulateItemInStorageFullRef(int id);
        ItemInStorageSearchModel PopulateItemInStorageFullRef(ItemInStorage itemInStorage);

        EmployeeSearchModel PopulateEmployeeFullRef(int id);
        EmployeeSearchModel PopulateEmployeeFullRef(Employee employee);

    }
}

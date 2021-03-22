using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class CurRolAssignExhibitSpaceViewModel
    {
        public int CuratorRoleId { get; set; }
        public string CuratorRoleName { get; set; }


        public List<ExhibitSpace> ExhibitSpaces { get; set; }
        public List<int> AlreadyAssigned { get; set; }
        public List<int> ChoosenExhibitSpaces { get; set; }

    }
}

using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class ExhibitAssignExhibitSpaceViewModel
    {

        public int ExhibitId { get; set; }
        public string ExhibitName { get; set; }

        public List<ExhibitSpace> ExhibitSpaces { get; set; }
        public int AlreadyAssigned { get; set; }
        public int ChoosenExhibitSpace { get; set; }


    }
}

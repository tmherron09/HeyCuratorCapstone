using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class ExhibitAssignItemInstanceViewModel
    {

        public int ExhibitId { get; set; }
        public string ExhibitName { get; set; }

        public List<ItemInstance> ItemInstances { get; set; }

        public List<int> AlreadyAssigned { get; set; }
        public List<int> ChoosenItems { get; set; }


    }
}

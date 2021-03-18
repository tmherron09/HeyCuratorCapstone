using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class CreateExhibitSpaceViewModel
    {

        public ExhibitSpace ExhibitSpace { get; set; }
        public int InitialCuratorRoleId { get; set; }

        public CreateExhibitSpaceViewModel()
        {

        }

    }
}

using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class CreateExhibitViewModel
    {
        public Exhibit Exhibit { get; set; }
        public int AssignedExhibitSpaceId { get; set; }

        public CreateExhibitViewModel()
        {

        }


    }
}

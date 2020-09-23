using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class PendingItemViewModel
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public int CurrentCount { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool IsTeamNotified { get; set; }


        public PendingItemViewModel()
        {


        }
        

    }
}

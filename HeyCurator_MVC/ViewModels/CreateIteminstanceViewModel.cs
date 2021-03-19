using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class CreateIteminstanceViewModel
    {

        public ItemInstance ItemInstance { get; set; }
        public InventoryControlModel InventoryControlModel { get; set; }

        public CreateIteminstanceViewModel()
        {

        }

    }
}

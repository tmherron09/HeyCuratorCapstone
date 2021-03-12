using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class CreateCuratorRoleViewModel
    {
        public CuratorRole Curator { get; set; }
        public int InitialEmployeeId { get; set; }

        public CreateCuratorRoleViewModel()
        {

        }

    }
}

using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class EmpAssignCurRolViewModel
    {

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }

        public List<CuratorRole> CuratorRoles { get; set; }
        public List<int> AlreadyAssigned { get; set; }
        public List<int> ChoosenCuratorRoles { get; set; }


    }
}

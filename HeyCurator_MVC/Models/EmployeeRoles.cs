using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class EmployeeRoles
    {
        [Key]
        public int EmployeeRoleId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("CuratorRole")]
        public int CuratorRoleId { get; set; }
        public CuratorRole CuratorRole { get; set; }

        // TODO: Remove at next Migration
        public CuratorRole StaffRole { get; set; }
    }

}

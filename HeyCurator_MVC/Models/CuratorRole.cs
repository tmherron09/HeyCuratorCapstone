using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class CuratorRole
    {

        [Key]
        public int CuratorRoleId { get; set; }

        // Name of the Type of Role or Name of Space it should be responsible for.
        public string NameOfRole { get; set; }

        [DisplayName("Curator Employees")]
        public ICollection<EmployeeRoles> EmployeeRoles { get; set; }

        // TODO: Add descriptor propety.
        [DisplayName("Exhibit Spaces")]
        public ICollection<CuratorSpace> CuratorSpaces { get; set; }
    }
}

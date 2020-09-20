using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class CuratorRole
    {

        [Key]
        public int CuratorRoleId { get; set; }

        // Name of the Type of Role or Name of Space it should be responsible for.
        public string NameOfRole { get; set; }

    }
}

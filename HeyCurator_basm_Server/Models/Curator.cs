using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class Curator
    {
        [Key]
        public int CuratorId { get; set; }

        // Example Classic Curator, Village Curator. Staff member can be changed.
        public string Name { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }




        // Non-Database items
       

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class CuratorAssignment
    {
        [Key]
        public int CuratorAssignmentId { get; set; }
        [ForeignKey("Curator")]
        public int CuratorId { get; set; }
        public Curator Curator { get; set; }

        [ForeignKey("CuratorSpace")]
        public int CuratorSpaceId { get; set; }
        public CuratorSpace CuratorSpace { get; set; }


        // Non-Database Objects
        


    }
}

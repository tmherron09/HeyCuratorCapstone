using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class CuratorSpace
    {
        [Key]
        public int CuratorSpaceId { get; set; }

        [DisplayName("Curator Space")]
        public string Name { get; set; }


        // Non-Database Objects




    }
}

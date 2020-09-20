using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class ExhibitItemInStorage
    {

        [Key]
        public int ExhibitItemInStorageId { get; set; }

        [ForeignKey("Exhibit")]
        public int ExhibitId { get; set; }
        public Exhibit Exhibit { get; set; }

        [ForeignKey("ItemInStorage")]
        public int ItemInStorageId { get; set; }
        public ItemInStorage ItemInStorage { get; set; }



    }
}

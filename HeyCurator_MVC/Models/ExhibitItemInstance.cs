using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class ExhibitItemInstance
    {

        [ForeignKey("Exhibit")]
        public int ExhibitId { get; set; }
        public Exhibit Exhibit { get; set; }

        [ForeignKey("ItemInstance")]
        public int ItemInstanceId { get; set; }
        public ItemInstance ItemInstance { get; set; }

    }
}

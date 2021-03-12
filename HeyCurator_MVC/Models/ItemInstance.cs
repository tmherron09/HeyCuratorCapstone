using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class ItemInstance
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Item Instance Identifier Name")]
        public string ItemInstanceName { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        //[ForeignKey("InventoryControlModel")]
        //public int InventoryControlModelId { get; set; }
        public InventoryControlModel InventoryControlModel { get; set; }


        public ICollection<StorageItemInstance> StorageItemInstances { get; set; }
        public ICollection<ExhibitItemInstance> ExhibitItemInstances { get; set; }


    }
}

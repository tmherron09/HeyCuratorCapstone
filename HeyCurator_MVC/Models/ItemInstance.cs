using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    /// <summary>
    /// Stores reference to Item Base Model.
    /// Has an Inventory Control Model.
    /// Has References to all storages this item instance is stored.
    /// Has Reference to all Exhibits that use this specific instance.
    /// </summary>
    public class ItemInstance
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Item Instance Identifier Name")]
        public string ItemInstanceName { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        /// <summary>
        /// Item Base Model reference.
        /// </summary>
        public Item Item { get; set; }

        //[ForeignKey("InventoryControlModel")]
        //public int InventoryControlModelId { get; set; }
        public InventoryControlModel InventoryControlModel { get; set; }

        /// <summary>
        /// EF Reference for explicit Join Table
        /// </summary>
        public ICollection<StorageItemInstance> StorageItemInstances { get; set; }
        /// <summary>
        /// EF Reference for explicit Join Table
        /// </summary>
        public ICollection<ExhibitItemInstance> ExhibitItemInstances { get; set; }

        [NotMapped]
        public List<Storage> Storages { get; set; }
        [NotMapped]
        public List<Exhibit> Exhibits { get; set; }

    }
}

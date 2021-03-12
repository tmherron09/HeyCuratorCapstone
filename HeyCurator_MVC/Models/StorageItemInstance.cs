using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{

    /// <summary>
    /// Represents both an Item Instance stored in multiple places and
    /// a storage space holds multiple item instances within.
    /// </summary>
    public class StorageItemInstance
    {
        public int ItemInstanceId { get; set; }
        public ItemInstance ItemInstance { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }

    }
}

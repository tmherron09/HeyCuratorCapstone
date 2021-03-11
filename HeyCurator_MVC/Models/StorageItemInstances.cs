using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class StorageItemInstances
    {
        public int ItemInstanceId { get; set; }
        public ItemInstance ItemInstance { get; set; }
        public int StorageId { get; set; }
        public Storage Storage { get; set; }

    }
}

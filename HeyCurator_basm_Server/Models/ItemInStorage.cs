using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class ItemInStorage
    {
        [Key]
        public int ItemInStorageId { get; set; }

        public int StorageCount { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        [ForeignKey("Storage")]
        public int StorageId { get; set; }
        public Storage Storage { get; set; }

        [ForeignKey("CuratorSpace")]
        public int? CuratorSpaceId { get; set; }
        public CuratorSpace CuratorSpace { get; set; }

        [ForeignKey("Curator")]
        public int? CuratorId { get; set; }
        public Curator Curator { get; set; }




        // Non-Database Objects

    }
}

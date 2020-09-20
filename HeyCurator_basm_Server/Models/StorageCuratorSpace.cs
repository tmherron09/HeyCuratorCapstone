using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class StorageCuratorSpace
    {
        [Key]
        public int StorageCuratorSpacesId { get; set; }
        [ForeignKey("Storage")]
        public int StorageId { get; set; }
        public Storage Storage { get; set; }
        [ForeignKey("CuratorSpace")]
        public int CuratorSpaceId { get; set; }
        public CuratorSpace CuratorSpace { get; set; }
    }
}

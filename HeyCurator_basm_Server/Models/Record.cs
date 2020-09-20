using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }

        public int RecordedCount { get; set; }

        [ForeignKey("ItemInStorage")]
        public int ItemInStorageId { get; set; }
        public Item ItemInStorage { get; }


        // DateTime.Today
        public DateTime TimeStamp { get; set; }
        
        
        [ForeignKey("RecordInfo")]
        public int RecordInfoId { get; set; }
        public RecordInfo RecordInfo { get; set; }


    }
}

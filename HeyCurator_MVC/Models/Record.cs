using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime TimeStamp { get; set; }
        
        
        [ForeignKey("RecordInfo")]
        public int RecordInfoId { get; set; }
        public RecordInfo RecordInfo { get; set; }

        
    }
}

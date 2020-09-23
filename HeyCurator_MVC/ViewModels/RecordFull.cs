using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class RecordFull
    {
        public int RecordId { get; set; }
        public Record Record { get; set; }

        public int RecordInfoId { get; set; }
        public RecordInfo RecordInfo { get; set; }



    }
}

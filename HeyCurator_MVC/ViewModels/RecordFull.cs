using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewModels
{
    public class RecordFull
    {
        public Item Item { get; set; }
        public int ItemId { get; set; }
        public int NewRecordedAmount { get; set; }
        public int ChoosenStorageId { get; set; }
        public List<Storage> Storages { get; set; }
        public string RecordedNotesOnUpdate { get; set; }

    }
}

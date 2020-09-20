using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class DatabaseCollectionContainer
    {

        // Non-Database Objects
        public ICollection<Curator> Curators { get; set; }
        public ICollection<Storage> Storages { get; set; }
        public ICollection<ItemInStorage> ItemInStorages { get; set; }
        public ICollection<Record> Records { get; set; }
        public ICollection<RecordInfo> RecordInfos { get; set; }
    }
}

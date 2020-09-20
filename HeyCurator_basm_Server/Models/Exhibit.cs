using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class Exhibit
    {
        public int ExhibitId { get; set; }

        public string Name { get; set; }

        [ForeignKey("CuratorSpace")]
        public int CuratorSpaceId { get; set; }
        public CuratorSpace CuratorSpace { get; set; }

        // Example a room or section of an open area.
        // TMH example- Market is an exhibit space, in the curator space Village.
        // Market has exhibits CheckoutOne, CheckoutSelf, HealthyShoppingList, etc.
        // Then through ref, I know if I need an item for Market, then these storage areas all have an item used in one of those exhibits.
        [ForeignKey("ExhibitSpace")]
        public int? ExhibitSpaceId { get; set; }
        public ExhibitSpace ExhibitSpace { get; set; }

        


        // Long Term Support specific to museum use.
        [NotMapped]
        public ICollection<string> OtherNames { get; set; }
        //public ICollection<Storage> ExhibitStorages { get; set; }

    }
}

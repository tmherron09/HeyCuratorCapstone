using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class ExhibitSpace
    {
        [Key]
        public int ExhibitSpaceId { get; set; }

        public string ExhibitSpaceName { get; set; }

        [ForeignKey("CuratorSpace")]
        public int? CuratorSpaceId { get; set; }
        public CuratorSpace CuratorSpace { get; set; }

        // All Exhibits in this Exhibit space
        public ICollection<Exhibit> Exhibits { get; set; }
        // All Storages that contains items for this
        [NotMapped]
        public ICollection<Storage> ExhibitStorages { get; set; }
        // All the items used in this exhibit space.
        [NotMapped]
        public ICollection<Item> ExhibitSpaceItems { get; set; }

    }
}

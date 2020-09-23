using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class CuratorSpace
    {
        [Key]
        public int CuratorSpaceId { get; set; }

        [DisplayName("Curator Space")]
        public string Name { get; set; }

        [ForeignKey("CuratorRole")]
        public int CuratorRoleId { get; set; }
        public CuratorRole CuratorRole { get; set; }

        public ICollection<ExhibitSpace> ExhibitSpaces { get; set; }
        public ICollection<Exhibit> Exhibits { get; set; }
        public ICollection<ItemInStorage> ItemsInStorage { get; set; }
        public ICollection<Storage> Storages { get; set; }

    }
}

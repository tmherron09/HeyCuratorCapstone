using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }
        public string Name { get; set; }

        [Display(Name = "Storage Space Decription")]
        public string Description { get; set; }
        [Display(Name = "Description of the Location of the Storage Space")]
        public string LocationDescription { get; set; }
        [Display(Name = "Restricted Access Rules")]
        public string RestrictedAccessRules { get; set; }

        public ICollection<StorageItemInstance> StorageItemInstances { get; set; }




        // TODO: Remove
        public string StorageType { get; set; }
        public AccessLevel AccessLevel { get; set; }

    }

    // Access Level auth Checks moved to Future Updates
    public enum AccessLevel
    {
        Volunteer,
        FloorStaff,
        AssistantManager,
        FloorManager,
        Curator,
        MaintenanceTeam,
        Administrative,
        Other
    }
}

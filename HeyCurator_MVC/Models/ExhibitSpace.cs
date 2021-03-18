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

        [Display(Name = "Exhibit Space Name")]
        [Required]
        public string ExhibitSpaceName { get; set; }

        [Display(Name = "Exhibit Space Decription")]
        public string Description { get; set; }

        [Display(Name = "Description of the Location of the Exhibit Space")]
        public string LocationDescription { get; set; }

        // Add General Info Model. can be used for Exhibit, Exhibit Space



        // All Exhibits in this Exhibit space
        // ExhibitSpace to Exhibits is One to Many.
        public ICollection<Exhibit> Exhibits { get; set; }

        // Exhibit Space to Curator Role is Many to Many
        public ICollection<CuratorSpace> CuratorSpaces { get; set; }

    }
}

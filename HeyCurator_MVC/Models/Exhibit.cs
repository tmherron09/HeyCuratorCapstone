using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class Exhibit
    {
        [Key]
        public int ExhibitId { get; set; }

        [Display(Name = "Exhibit Space Name")]
        [Required]
        public string Name { get; set; }

        [Display(Name = "Exhibit  Decription")]
        public string Description { get; set; }

        [Display(Name = "Description of the Location of the Exhibit")]
        public string LocationDescription { get; set; }


        // Add General Info Model. can be used for Exhibit, Exhibit Space
        // Educational Model


        [ForeignKey("ExhibitSpace")]
        public int ExhibitSpaceId { get; set; }
        public ExhibitSpace ExhibitSpace { get; set; }


        public ICollection<ExhibitItemInstance> ExhibitItemInstances  { get; set; }


        //  Depreciate In-Progress

        //public ICollection<ItemInStorage> ItemInStorages { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class Storage
    {
        [Key]
        public int StorageId { get; set; }
        public string Name { get; set; }
        public StorageType StorageType { get; set; }
        public AccessLevel AccessLevel { get; set; }

        // Non-Database Objects

    }


    public enum StorageType
    {
        Closet,
        LowerCabinet,
        UpperCabinet,
        InExhibitPiece,
        Basement,
        Office,
        OutdoorContainer,
        Warehouse,
        InExhibitOutOfVisitorReach,
        StorageRoom

    }

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

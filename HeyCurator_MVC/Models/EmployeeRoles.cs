using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class EmployeeRoles
    {
        [Key]
        public int EmployeeRoleId { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [ForeignKey("CuratorRole")]
        public int CuratorRoleId { get; set; }
        public CuratorRole CuratorRole { get; set; }
        public CuratorRole StaffRole { get; set; }
    }

    public enum StaffRole
    {
        President,
        Director,
        SeniorManager,
        Manager,
        FloorManager,
        AssistantFloorManager,
        FloorStaffLevelTwo,
        FloorStaff,
        FloorStaffProbation,
        BirthdayManager,
        STEAMDirector,
        STEAMManager,
        EducationManager,
        OutreachManager,
        FrontDeskStaff,
        MuseumStoreStaff,
        MaintenanceDirector,
        MaintenanceSpecialist,
        ExhibitTeamMember,
        CustodialTeamMember,
        MembershipDirector,
        VolunteerDirector,
        MarketingDirector,
        MarketingTeamMember,
        SpecialEventsCoordinator,
        SpecialEventsStaff,
        OfficeIntern,
        DevelopementDirector,
        DevelopementTeamMember,
        GraphicsTeamMember,
        AdministrativeAssistantToPresident,
        AdministrativeOfficeStaff,
        CafeDirector,
        CafeManager,
        WorldTravelerCoordinator, // WTG Curator
        TravelingExhibitGalleryCoordinator, // TEG Curator
        GroundsKeeper,
    }
}

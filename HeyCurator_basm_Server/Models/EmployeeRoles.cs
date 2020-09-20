using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class EmployeeRoles
    {
        [Key]
        public int EmployeeRole { get; set; }

        public StaffRole StaffRole { get; set; }
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

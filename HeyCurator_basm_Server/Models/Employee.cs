using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HeyCurator_basm_Server.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [ForeignKey("IdentityUser")]
        [AllowNull]
        public string IdentityUser { get; set; }




    }

    // Possible Switch to string and allow Admin defined values.
    // Or predefined in IdentityRoles
    
}
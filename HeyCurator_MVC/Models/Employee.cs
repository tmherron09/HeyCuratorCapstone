using Microsoft.AspNetCore.Identity;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HeyCurator_MVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        
        [Required]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("User Name")]
        public string EmployeeUserName { get; set; }

        [AllowNull]
        [DisplayName("Employee Title")]
        public string Title { get; set; }

        [ForeignKey("IdentityUser")]
        [AllowNull]
        public string IdentityUser { get; set; }

        [DisplayName("Employee's Roles")]
        public ICollection<EmployeeRoles> EmployeeRoles { get; set; }


    }

    // Possible Switch to string and allow Admin defined values.
    // Or predefined in IdentityRoles
    
}
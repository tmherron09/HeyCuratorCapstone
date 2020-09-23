using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class RecordInfo
    {

        [Key]
        public int RecordInfoId { get; set; }


        [ForeignKey("Record")]
        public int RecordId { get; set; }



        // This is Set if the staff member recording count is the assigned curator. Sets CuratorVerified to true.
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }





        // Verified by staff member other that item's curator, set Curator verified to false.
        [AllowNull]
        public int? FirstVerifierId { get; set; }
        [ForeignKey("FirstVerifierId")]
        public Employee FirstVerifier { get; set; }




        // A second staff member can verify and agree with the curator/first staff member.
        [AllowNull]
        public int? SecondVefifierId { get; set; }
        [ForeignKey("SecondVefifierId")]
        public Employee SecondVefifier { get; set; }



        // If curatorid matches the items id, set to true.
        public bool CuratorVerified { get; set; }
        // For later feature of challenging a count to correct it.
        public bool IsChallenged { get; set; }
        public bool SecondaryVefified { get; set; }

        // Record special conditions as to why count is at a certain value.
        public string RecordNote { get; set; }




    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class Record
    {
        [Key]
        public int RecordId { get; set; }

        [Display(Name = "Updated Inventory Count in Units")]
        public int RecordedCount { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        [Display(Name = "Time of Record")]
        public DateTime TimeStamp { get; set; }

        [Display(Name = "Recording Employee")]
        [ForeignKey("Employee")]
        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Display(Name = "Record Verified By Assigned Curator")]
        public bool CuratorVerified { get; set; }

        [Display(Name = "Record Note")]
        public string RecordNote { get; set; }

        //[ForeignKey("InventoryControlModel")]
        public int InventoryControlModelID { get; set; }
        public InventoryControlModel InventoryControlModel { get; }





        /*
         * 
         *  TODO: DEPRECIATE ALL FIELDS BELOW
         * 
         */

        [ForeignKey("ItemInStorage")]
        public int ItemInStorageId { get; set; }
        public ItemInStorage ItemInStorage { get; }


        [AllowNull]
        public int? FirstVerifierId { get; set; }
        [ForeignKey("FirstVerifierId")]
        public Employee FirstVerifier { get; set; }
        // A second staff member can verify and agree with the curator/first staff member.
        
        [AllowNull]
        public int? SecondVefifierId { get; set; }
        [ForeignKey("SecondVefifierId")]
        public Employee SecondVefifier { get; set; }
        
        public bool IsChallenged { get; set; }
        public bool SecondaryVefified { get; set; }


        public ICollection<Employee> Employees { get; set; }


    }
}

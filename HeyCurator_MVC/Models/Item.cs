using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required]
        [DisplayName("Item Name")]
        public string Name { get; set; }

        [DisplayName("Item Description")]
        public string ItemDescription { get; set; }

        public ICollection<ItemInstance> ItemInstances { get; set; }



        /*
         * 
         *   TODO: Depreciate Items Below
         *      To Be Repalced by Inventory Control Models
         * 
         */




        [DisplayName("Minimum Reserve Count")]
        public int MinCount { get; set; }
        // Store as days to use the DateTime.AddDays(), TimeSpan is not important as
        // We are doing counts as Day specific not Time of Day/Hour Specific.
        [DisplayName("Days Between Updates")]
        public int DaysBetweenUpdates { get; set; }
        [DisplayName("Days before notify curators")]
        public int DaysBeforeNotifyAllCurators { get; set; }
        [DisplayName("Last Updated")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime DateOfLastUpdate { get; set; }
        [DisplayName("Update By")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, MMMM dd, yyyy}")]
        public DateTime UpdateByDate { get; set; }
        [DisplayName("Date curators notified by")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dddd, MMMM dd, yyyy}")]
        public DateTime DateNotifyCurators { get; set; }
        [DisplayName("Amount recorded in storage")]
        public int RecordedStorageAmount { get; set; }


    }

    public enum RestockConditional
    {
        None,
        ItemCondition,
        Daily,
        DailyConditionCheck, // It is checked daily but only replaced base on condition.
        Weekly,
        WeeklyConditionCheck,
        Monthky,
        MonthlyConditionCheck
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }
        public string Name { get; set; }
        public int MinCount { get; set; }
        // Store as days to use the DateTime.AddDays(), TimeSpan is not important as
        // We are doing counts as Day specific not Time of Day/Hour Specific.
        public int DaysBetweenUpdates { get; set; }
        public int DaysBeforeNotifyAllCurators { get; set; }
        public DateTime DateOfLastUpdate { get; set; }
        public DateTime UpdateByDate { get; set; }
        public DateTime DateNotifyCurators { get; set; }

        // Possibly Move to New Table

        // This the count of matching ItemId in all ItemInStorageCounts
        // It is not set, grabs count for 1 or Many StorageItems
        // Not sure if breaks principal of being dependent on other columns if outside the table.
        public int RecordedStorageCount { get; }

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

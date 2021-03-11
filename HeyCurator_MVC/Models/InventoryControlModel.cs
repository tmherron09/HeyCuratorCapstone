using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class InventoryControlModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("ItemInstance")]
        public int ItemInstanceId { get; set; }
        public ItemInstance ItemInstance { get; set; }

        [Display(Name = "Unit Measurement", Description = "How this item's count is measured.")]
        public string UnitMeasurement { get; set; }

        [Display(Name = "Minimum Inventory Count in Units")]
        public float MinimumUnitCount { get; set; }

        [Display(Name = "Recommended Inventory Count in Units")]
        public float RecommendedUnitCount { get; set; }
      
        [Display(Name = "Most Recent Inventory Count")]
        public int MostRecentInventoryCount { get; set; }

        [Display(Name = "Date of Most Recent Inventory Count")]
        public DateTime DateOfMostRecentInventoryCount { get; set; }

        [Display(Name = "Scheduled Update Period in Days")]
        public int ScheduledUpdatePeriodInDays { get; set; }

        [Display(Name = "Days Allowed to Lapse after a missed Update")]
        public int AllowUpdateLapseInDays { get; set; }

        [NotMapped]
        public DateTime NextScheduleUpdateByDate
        {
            get
            {
                return DateOfMostRecentInventoryCount + TimeSpan.FromDays(ScheduledUpdatePeriodInDays);
            }
        }

        [NotMapped]
        public DateTime CuratorNotificationThatUpdateHasLapsed
        {
            get
            {
                return NextScheduleUpdateByDate + TimeSpan.FromDays(AllowUpdateLapseInDays);
            }
        }

        public ICollection<Record> Records { get; set; }

    }
}

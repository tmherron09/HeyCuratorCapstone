using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HeyCurator_MVC.Models
{
    public class PurchaserNotification
    {

        [Key]
        public int PurchaserNotificationId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }


        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:d}")]
        public DateTime TimeStamp { get; set; }


        [DisplayName("Amount in stock")]
        public int CurrentStock { get; set; }


        public int? AmountRequested { get; set; }



        public OrderUrgency OrderUrgency { get; set; }


        public string CuratorNote { get; set; }
        public string PurchaserNote { get; set; }

        // Can be accomplished without, but here for initial ease of view.
        public int? OrderRefId { get; set; }


        public bool IsFullFilled { get; set; }



    }
    public enum OrderUrgency
    {
        None,
        OrderSoon,
        OrderRequired,
        UrgentOrder,
        Special
    }

}

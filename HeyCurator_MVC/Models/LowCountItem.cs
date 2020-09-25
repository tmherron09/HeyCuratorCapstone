using HeyCurator_MVC.Data;
using HeyCurator_MVC.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class LowCountItem
    {
        [Key]
        public int ExpiredUpdateItemId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public string ItemName { get; set; }
        public int AmountInReserve { get; set; }
        public bool PurchaseNotificationMade { get; set; }
        public bool OrderHasBeenMade { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }

        public int AmountInOrder { get; set; }
        public DateTime TimeStamp { get; set; }

        [ForeignKey("Employee")]
        [DisplayName("Purchaser")]
        public int EmployeeId { get; set; }
        public Employee Purchaser { get; set; }

        public string PurchaserNote { get; set; }


    }
}

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
    public class ExpiredUpdateItem
    {
        [Key]
        public int ExpiredUpdateItemId { get; set; }

        [ForeignKey("Item")]
        public int ItemId { get; set; }
        public Item Item { get; set; }


        public bool AllCuratorExpiration { get; set; }






        [NotMapped]
        public List<Employee> AssignedEmployees { get; set; }

        public ExpiredUpdateItem()
        {

        }
        public ExpiredUpdateItem(int itemId, bool allNotified)
        {
            ItemId = itemId;
            AllCuratorExpiration = allNotified;
        }
        public ExpiredUpdateItem(Item item, bool allCuratorExpiration, DataAccessService data)
        {
            //AssignedEmployees = data.GetCuratorsAssignedToItem(item);
            AllCuratorExpiration = allCuratorExpiration;
            ItemId = item.ItemId;
            Item = item;

        }
        public ExpiredUpdateItem(int itemId, bool allCuratorExpiration, DataAccessService data)
        {
            Item = data.GetItemById(itemId);
            //AssignedCurators = data.GetCuratorsAssignedToItem(Item);
            AllCuratorExpiration = allCuratorExpiration;
            ItemId = itemId;

        }
        


    }
}

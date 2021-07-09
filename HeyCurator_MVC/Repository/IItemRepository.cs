using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public interface IItemRepository : IRepositoryBase<Item>
    {
        /// <summary>
        /// Returns Item Model without references.
        /// </summary>
        /// <param name="itemId"></param>
        /// <returns></returns>
        Task<Item> GetItemBase(int itemId);
        Task<Item> GetItemWithInstances(int itemId);
        Task<Item> GetItemWithInstancesWithStorages(int itemId);
        Task<Item> GetItemWithInstancesWithExhibits(int itemId);
        Task<Item> GetItemWithInstancesWithStoragesAndExhibits(int itemId);

        Task<IEnumerable<Item>> GetAllItemsBase();
        Task<IEnumerable<Item>> GetAllItemsWithInstances();
        Task<IEnumerable<Item>> GetAllItemsWithInstancesWithStorages();
        Task<IEnumerable<Item>> GetAllItemsWithInstancesWithExhibits();
        Task<IEnumerable<Item>> GetAllItemsWithInstancesWithStoragesAndExhibits();

        Task PopulateItemBaseWithInstances(Item item);
        Task PopulateInstancesWithStorages(ItemInstance itemInstance);
        Task PopulateInstancesWithExhibits(ItemInstance itemInstance);
        Task PopulateAllItemInstancesWithStorages(Item item);
        Task PopulateAllItemInstancesWithExhibits(Item item);
        Task PopulateAllItemInstancesWithStoragesAndExhibits(Item item);


    }
}

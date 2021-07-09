using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class ItemRepository : RepositoryBase<Item>, IItemRepository
    {

        public ItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Item> GetItemBase(int itemId)
        {
            return await _context.Items.Where(i => i.ItemId == itemId).FirstOrDefaultAsync();
        }
        public async Task<IEnumerable<Item>> GetAllItemsBase()
        {
            return await Task.Run(() => FindAll());
        }
        public async Task<Item> GetItemWithInstances(int itemId)
        {
            var item = await GetItemBase(itemId);
            await PopulateItemBaseWithInstances(item);
            return item;
        }
        public async Task<IEnumerable<Item>> GetAllItemsWithInstances()
        {
            var items = await GetAllItemsBase();
            foreach(var item in items)
            {
                await PopulateItemBaseWithInstances(item);
            }
            return items;
        }
        public async Task<Item> GetItemWithInstancesWithExhibits(int itemId)
        {
            var item = await GetItemWithInstances(itemId);
            await PopulateAllItemInstancesWithExhibits(item);
            return item;
        }
        public async Task<IEnumerable<Item>> GetAllItemsWithInstancesWithExhibits()
        {
            var items = await GetAllItemsWithInstances();
            foreach(var item in items)
            {
                await PopulateAllItemInstancesWithExhibits(item);
            }
            return items;
        }
        public async Task<Item> GetItemWithInstancesWithStorages(int itemId)
        {
            var item = await GetItemWithInstances(itemId);
            await PopulateAllItemInstancesWithStorages(item);

            return item;
        }
        public async Task<IEnumerable<Item>> GetAllItemsWithInstancesWithStorages()
        {
            var items = await GetAllItemsWithInstances();
            foreach (var item in items)
            {
                await PopulateAllItemInstancesWithStorages(item);
            }
            return items;
        }
        public async Task<Item> GetItemWithInstancesWithStoragesAndExhibits(int itemId)
        {
            var item = await GetItemWithInstances(itemId);
            await PopulateAllItemInstancesWithStoragesAndExhibits(item);
            return item;
        }
        public async Task<IEnumerable<Item>> GetAllItemsWithInstancesWithStoragesAndExhibits()
        {
            var items = await GetAllItemsWithInstances();
            foreach (var item in items)
            {
                await PopulateAllItemInstancesWithStoragesAndExhibits(item);
            }
            return items;
        }
        public async Task PopulateItemBaseWithInstances(Item item)
        {
            item.ItemInstances = await _context.ItemInstances
                .Where(ii => ii.ItemId == item.ItemId)
                .Select(ii => new ItemInstance
                {
                    Id = ii.Id,
                    ItemInstanceName = ii.ItemInstanceName,
                    ItemId = ii.ItemId,
                    InventoryControlModel = ii.InventoryControlModel
                })
                .ToListAsync();
        }
        public async Task PopulateInstancesWithStorages(ItemInstance itemInstance)
        {
            itemInstance.Storages = await _context.StorageItemInstances
                .Where(sii => sii.ItemInstanceId == itemInstance.Id)
                .Select(sii => sii.Storage)
                .ToListAsync();
        }
        public async Task PopulateInstancesWithExhibits(ItemInstance itemInstance)
        {
            itemInstance.Exhibits = await _context.ExhibitItemInstances
                .Where(eii => eii.ItemInstanceId == itemInstance.Id)
                .Select(eii => eii.Exhibit)
                .ToListAsync();
        }
        public async Task PopulateAllItemInstancesWithStorages(Item item)
        {
            foreach (var itemInstance in item.ItemInstances)
            {
                await PopulateInstancesWithStorages(itemInstance);
            }
        }
        public async Task PopulateAllItemInstancesWithExhibits(Item item)
        {
            foreach (var itemInstance in item.ItemInstances)
            {
                await PopulateInstancesWithExhibits(itemInstance);
            }
        }
        public async Task PopulateAllItemInstancesWithStoragesAndExhibits(Item item)
        {
            foreach (var itemInstance in item.ItemInstances)
            {
                await PopulateInstancesWithExhibits(itemInstance);
                await PopulateInstancesWithStorages(itemInstance);
            }
        }

    }


}

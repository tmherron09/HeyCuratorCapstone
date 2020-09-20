using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyCurator_basm_Server.Data;
using HeyCurator_basm_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyCurator_basm_Server.Services
{
    public class AdminServices
    {
        private ItemDateService _itemDateService;
        private readonly ApplicationDbContext _context;

        public AdminServices(ItemDateService itemDateService, ApplicationDbContext context)
        {
            _itemDateService = itemDateService;
            _context = context;
        }


        public async Task<string> CreateItem(Item item)
        {

            _itemDateService.UpdateItemDates(item);
            _context.Items.Add(item);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.ItemId))
                {
                    return "Failed to Add Item";
                }
                else
                {
                    throw;
                }
            }
            return "Success";


        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }

    }
}

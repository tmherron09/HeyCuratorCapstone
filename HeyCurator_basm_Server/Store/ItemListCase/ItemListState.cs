using HeyCurator_basm_Server.Models;
using HeyCurator_basm_Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ItemListCase
{
    public class ItemListState
    {
        public List<Item> Items { get; }
        public bool IsLoading { get; }
        public ItemListState(bool isLoading, List<Item> items)
        {
            IsLoading = isLoading;
            Items = items;
        }
    }
}

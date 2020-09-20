using HeyCurator_basm_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ItemListCase
{
    public class FetchItemListResultAction
    {
        public List<Item> Items { get; }
        public FetchItemListResultAction(List<Item> items)
        {
            Items = items;
        }

    }
}

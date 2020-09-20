using HeyCurator_basm_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.DatabaseUseCase
{
    public class FetchDatabaseItemsAction
    {
        public List<Item> Items{ get; set; }
        public FetchDatabaseItemsAction(List<Item> items)
        {
            Items = items;
        }

    }
}

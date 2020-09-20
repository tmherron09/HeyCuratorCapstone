using Fluxor;
using HeyCurator_basm_Server.Services;
using HeyCurator_basm_Server.Store.ItemListCase;
using HeyCurator_basm_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store
{
    public class Effects
    {
        private AdminServices _admin { get; set; }

        public Effects(AdminServices admin)
        {
            _admin = admin;
        }

        [EffectMethod]
        public async Task HandleFetchItemListAction(FetchItemListAction action, IDispatcher dispatcher)
        {
            var items = await _admin.GetAllItems();
            dispatcher.Dispatch(new FetchItemListResultAction(items));
        }
    }
}

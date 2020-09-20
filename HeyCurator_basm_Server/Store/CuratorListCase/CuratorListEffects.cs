using Fluxor;
using HeyCurator_basm_Server.Models;
using HeyCurator_basm_Server.Services;
using HeyCurator_basm_Server.Store.ItemListCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.CuratorListCase
{
    public class CuratorListEffects
    {
        private AdminServices _admin { get; set; }
        private DatabaseListService DbListService { get; set; }
        public CuratorListEffects(AdminServices admin, DatabaseListService dbListService)
        {
            _admin = admin;
            DbListService = dbListService;
        }

        [EffectMethod]
        public async Task HandleFetchCuratorListAction(FetchCuratorListAction action, IDispatcher dispatcher)
        {
            var curators = await _admin.GetAllCurators();
            dispatcher.Dispatch(new FetchCuratorListResultAction(curators));
        }
    }
}

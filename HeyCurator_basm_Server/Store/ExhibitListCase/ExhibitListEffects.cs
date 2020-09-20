using Fluxor;
using HeyCurator_basm_Server.Models;
using HeyCurator_basm_Server.Services;
using HeyCurator_basm_Server.Store.ItemListCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ExhibitListCase
{
    public class ExhibitListEffects
    {
        private AdminServices _admin { get; set; }
        private DatabaseListService DbListService { get; set; }
        public ExhibitListEffects(AdminServices admin, DatabaseListService dbListService)
        {
            _admin = admin;
            DbListService = dbListService;
        }

        [EffectMethod]
        public async Task HandleFetchExhibitListAction(FetchExhibitListAction action, IDispatcher dispatcher)
        {
            var exhibits = _admin.GetAllExhibits();
            dispatcher.Dispatch(new FetchExhibitListResultAction(exhibits));
        }
    }
}

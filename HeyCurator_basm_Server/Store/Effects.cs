using Fluxor;
using HeyCurator_basm_Server.Models;
using HeyCurator_basm_Server.Services;
using HeyCurator_basm_Server.Store.DatabaseUseCase;
using HeyCurator_basm_Server.Store.ItemListCase;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store
{
    public class Effects
    {
        private AdminServices _admin { get; set; }
        private DatabaseListService DbListService { get; set; }

        public Effects(AdminServices admin, DatabaseListService dbListService)
        {
            _admin = admin;
            DbListService = dbListService;
        }

        [EffectMethod]
        public async Task HandleFetchItemListAction(FetchItemListAction action, IDispatcher dispatcher)
        {
            var items = await _admin.GetAllItems();
            dispatcher.Dispatch(new FetchItemListResultAction(items));
        }

        [EffectMethod]
        public async Task HandleFetchDatabaseAction(FetchDatabaseAction action, IDispatcher dispatcher)
        {
            var db = DbListService.GetAllList();
            dispatcher.Dispatch(new FetchDatabaseActionResult(db));
        }
        [EffectMethod]
        public async Task HandleFetchDatabaseCuratorsAction(FetchDatabaseCuratorsAction action, IDispatcher dispatcher)
        {
            var curators = DbListService.GetAllCurators();
        }
        [EffectMethod]
        public async Task HandleFetchDatabaseItemsAction(FetchDatabaseItemsAction action, IDispatcher dispatcher)
        {
            var items = DbListService.GetAllItems();
        }
    }
    
}

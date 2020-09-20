using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ItemListCase
{
    public static class ItemListReducers
    {
        [ReducerMethod]
        public static ItemListState ReduceFetchItemListAction(ItemListState state, FetchItemListAction action) =>
            new ItemListState(
                isLoading: true,
                items: null);

        [ReducerMethod]
        public static ItemListState ReduceFetchItemListResultAction(ItemListState state, FetchItemListResultAction action) =>
            new ItemListState(
                isLoading: false,
                items: action.Items
                );
    }
}

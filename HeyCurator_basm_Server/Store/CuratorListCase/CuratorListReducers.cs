using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.CuratorListCase
{
    public static class CuratorListReducers
    {
        [ReducerMethod]
        public static CuratorListState ReduceFetchCuratorListAction(CuratorListState state, FetchCuratorListAction action) =>
            new CuratorListState(
                isLoading: true,
                curators: null);

        [ReducerMethod]
        public static CuratorListState ReduceFetchCuratorListResultAction(CuratorListState state, FetchCuratorListResultAction action) =>
            new CuratorListState(
                isLoading: false,
                curators: action.Curators
                );
    }
}

using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ExhibitListCase
{
    public static class ExhibitListReducers
    {
        [ReducerMethod]
        public static ExhibitListState ReduceFetchExhibitListAction(ExhibitListState state, FetchExhibitListAction action) =>
            new ExhibitListState(
                isLoading: true,
                exhibits: null);

        [ReducerMethod]
        public static ExhibitListState ReduceFetchExhibitListResultAction(ExhibitListState state, FetchExhibitListResultAction action) =>
            new ExhibitListState(
                isLoading: false,
                exhibits: action.Exhibits
                );
    }
}

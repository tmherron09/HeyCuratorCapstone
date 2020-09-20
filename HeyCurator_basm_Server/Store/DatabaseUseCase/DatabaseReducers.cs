using Fluxor;

namespace HeyCurator_basm_Server.Store.DatabaseUseCase
{
    public static class DatabaseReducers
    {

        [ReducerMethod]
        public static DatabaseState ReduceFetchDatabaseAction(DatabaseState state, FetchDatabaseAction action) =>
            new DatabaseState(
        isLoading: true,
        dbContainer: null);

        [ReducerMethod]
        public static DatabaseState ReduceFetchDatabaseResultAction(DatabaseState state, FetchDatabaseActionResult action) =>
            new DatabaseState(
                isLoading: false,
                dbContainer: action.DatabaseLists
                );
        [ReducerMethod]
        public static DatabaseState ReduceFetchDatabaseCuratorsAction(DatabaseState state, FetchDatabaseCuratorsAction action)
        {
            
            return new DatabaseState(
                oldState: state,
                curators: action.Curators,
                isLoading: false);
        }
        [ReducerMethod]
        public static DatabaseState ReduceFetchDatabaseItemsAction(DatabaseState state, FetchDatabaseItemsAction action)
        {
            return new DatabaseState(
                oldState: state,
                items: action.Items,
                isLoading: false);
        }

    }
}

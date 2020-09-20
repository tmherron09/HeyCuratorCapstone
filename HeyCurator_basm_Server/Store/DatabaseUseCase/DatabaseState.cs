using HeyCurator_basm_Server.Models;
using HeyCurator_basm_Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.DatabaseUseCase
{
    public class DatabaseState
    {
        public DatabaseCollectionContainer DbContainer { get; set; }
        public bool IsLoading { get; }

        public DatabaseState(DatabaseCollectionContainer dbContainer, bool isLoading)
        {
            DbContainer = dbContainer;
            IsLoading = IsLoading;
        }
        public DatabaseState(DatabaseState oldState, bool isLoading, List<Curator> curators)
        {
            oldState.DbContainer.Curators = curators;
            DbContainer = oldState.DbContainer;
            IsLoading = isLoading;
        }
        public DatabaseState(DatabaseState oldState, bool isLoading, List<Item> items)
        {
            oldState.DbContainer.Items = items;
            DbContainer = oldState.DbContainer;
            IsLoading = isLoading;
        }
    }
}

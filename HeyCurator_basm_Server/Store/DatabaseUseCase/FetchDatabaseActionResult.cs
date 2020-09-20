using HeyCurator_basm_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.DatabaseUseCase
{
    public class FetchDatabaseActionResult
    {
        public DatabaseCollectionContainer DatabaseLists { get; }
        public FetchDatabaseActionResult(DatabaseCollectionContainer db)
        {
            DatabaseLists = db;
        }
    }
}

using HeyCurator_basm_Server.Models;
using HeyCurator_basm_Server.Store.DatabaseUseCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store
{
    public static class StateInitializedCheck
    {


        public static bool DatabaseStateInitialized(DatabaseCollectionContainer dbcc)
        {
            return dbcc != null ? true : false;
        }
    }
}

using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.DatabaseUseCase
{
    public class Feature : Feature<DatabaseState>
    {
        public override string GetName() => "Database";
        protected override DatabaseState GetInitialState() =>
            new DatabaseState(
                dbContainer: null,
                isLoading: false
                );
        


    }
}

using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.CuratorListCase
{
    public class Feature : Feature<CuratorListState>
    {
        public override string GetName() => "CuratorList";
        protected override CuratorListState GetInitialState()
        {
            return new CuratorListState(
                isLoading: false,
                curators: null);
        }
    }
}

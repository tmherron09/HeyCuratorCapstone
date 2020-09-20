using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ExhibitListCase
{
    public class Feature : Feature<ExhibitListState>
    {
        public override string GetName() => "ExhibitList";
        protected override ExhibitListState GetInitialState()
        {
            return new ExhibitListState(
                isLoading: false,
                exhibits: null);
        }
    }
}

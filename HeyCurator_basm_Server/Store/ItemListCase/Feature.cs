using Fluxor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ItemListCase
{
    public class Feature : Feature<ItemListState>
    {
        public override string GetName() => "ItemList";
        protected override ItemListState GetInitialState()
        {
            return new ItemListState(
                isLoading: false,
                items: null);
        }
    }
}

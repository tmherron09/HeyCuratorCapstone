using HeyCurator_basm_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.CuratorListCase
{
    public class FetchCuratorListResultAction
    {
        public List<Curator> Curators { get; }
        public FetchCuratorListResultAction(List<Curator> curators)
        {
            Curators = curators;
        }

    }
    
}

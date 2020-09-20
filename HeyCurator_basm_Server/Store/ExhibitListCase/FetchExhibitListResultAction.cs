using HeyCurator_basm_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ExhibitListCase
{
    public class FetchExhibitListResultAction
    {
        public List<Exhibit> Exhibits { get; }
        public FetchExhibitListResultAction(List<Exhibit> exhibits)
        {
            Exhibits = exhibits;
        }

    }
    
}

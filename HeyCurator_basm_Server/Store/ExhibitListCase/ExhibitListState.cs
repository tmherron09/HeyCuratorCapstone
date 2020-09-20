using HeyCurator_basm_Server.Models;
using HeyCurator_basm_Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.ExhibitListCase
{
    public class ExhibitListState
    {
        public List<Exhibit> Exhibits { get; }
        public bool IsLoading { get; }
        public ExhibitListState(bool isLoading, List<Exhibit> exhibits)
        {
            IsLoading = isLoading;
            Exhibits = exhibits;
        }
    }
}

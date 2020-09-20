using HeyCurator_basm_Server.Models;
using HeyCurator_basm_Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.CuratorListCase
{
    public class CuratorListState
    {
        public List<Curator> Curators { get; }
        public bool IsLoading { get; }
        public CuratorListState(bool isLoading, List<Curator> curators)
        {
            IsLoading = isLoading;
            Curators = curators;
        }
    }
}

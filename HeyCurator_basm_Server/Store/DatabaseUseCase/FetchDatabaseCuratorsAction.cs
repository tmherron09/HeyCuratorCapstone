using HeyCurator_basm_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_basm_Server.Store.DatabaseUseCase
{
    public class FetchDatabaseCuratorsAction
    {
        public List<Curator> Curators { get; set; }
        public FetchDatabaseCuratorsAction(List<Curator> curators)
        {
            Curators = curators;
        }

    }
}

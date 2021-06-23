using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class ExhibitRepository : RepositoryBase<Exhibit>, IExhibitRepository
    {

        public ExhibitRepository(ApplicationDbContext context) : base(context)
        {
        }

        public string ExhibitNameById(int exhibitId) =>
            FindAllBy(ex => ex.ExhibitId == exhibitId).Select(ex => ex.Name).FirstOrDefault();
        public List<int> ItemInstanceIds(int exhibitId) =>
            GetItemInstanceIdsByExhibit(exhibitId).ToList();
    }
}

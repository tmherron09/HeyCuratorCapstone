using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Exhibit>> AllExhibitBaseModels()
        {
            return await Task.Run(()=> _context.Exhibits.Include(e => e.ExhibitSpace));
        }
        public async Task<Exhibit> ExhibitBaseModel(int exhibitId)
        {
            return await _context.Exhibits.Where(e => e.ExhibitId == exhibitId).Include(e => e.ExhibitSpace).FirstOrDefaultAsync();
        }
        public string ExhibitNameById(int exhibitId) =>
            FindAllBy(ex => ex.ExhibitId == exhibitId).Select(ex => ex.Name).FirstOrDefault();

        public List<int> ItemInstanceIds(int exhibitId) =>
            GetItemInstanceIdsByExhibit(exhibitId).ToList();


    }
}

using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class CuratorRoleRepository : RepositoryBase<CuratorRole>, ICuratorRoleRepository
    {

        public CuratorRoleRepository(ApplicationDbContext context) : base(context)
        {
        }
        public string CuratorRoleNameById(int curatorRoleId) =>
            _context.CuratorRoles.Where(cr => cr.CuratorRoleId == curatorRoleId).Select(cr => cr.NameOfRole).FirstOrDefault();

        public IEnumerable<ExhibitSpace> GetExhibitSpaces(int id) =>
            GetExhibitSpacesByCuratorRole(id);
        public List<int> GetExhibitSpaceIds(int curatorRoleId) =>
            GetExhibitSpaceIdsByCuratorRole(curatorRoleId).ToList();

    }
}

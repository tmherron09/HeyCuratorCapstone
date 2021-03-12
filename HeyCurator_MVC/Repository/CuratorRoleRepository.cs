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

    }
}

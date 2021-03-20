﻿using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public interface IEmployeeRepository : IRepositoryBase<Employee>
    {
        string EmployeeNameById(int id);

        List<int> GetCuratorRoleIds(int id);
        IEnumerable<CuratorRole> GetCuratorRoles(int id);

    }
}

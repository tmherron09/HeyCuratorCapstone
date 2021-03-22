using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
        }


        public string EmployeeNameById(int id) =>
            FindAllBy(emp => emp.EmployeeId == id).Select(emp => emp.EmployeeUserName).FirstOrDefault();

        public List<int> GetCuratorRoleIds(int employeId) =>
            GetCuratorRoleIdsByEmployee(employeId).ToList();

        public IEnumerable<CuratorRole> GetCuratorRoles(int id) =>
            GetCuratorRolesByEmployee(id);

        public IEnumerable<ExhibitSpace> GetExhibitSpaces(int id)
        {
            IEnumerable<CuratorRole> curatorRoles = GetCuratorRoles(id);
            List<ExhibitSpace> exhibitSpaces = new List<ExhibitSpace>();
            foreach(var curator in curatorRoles)
            {
                exhibitSpaces.AddRange((GetExhibitSpacesByCuratorRole(curator.CuratorRoleId)));
            }
            return exhibitSpaces;
        }

    }
}

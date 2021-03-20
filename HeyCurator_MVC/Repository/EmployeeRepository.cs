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

        public List<int> GetCuratorRoleIds(int id) =>
            _context.EmployeeRoles.Where(er => er.EmployeeId == id).Select(er => er.CuratorRoleId).ToList();

        public IEnumerable<CuratorRole> GetCuratorRoles(int id) =>
            _context.EmployeeRoles.Where(er => er.EmployeeId == id).Include(er=> er.CuratorRole).Select(er=> er.CuratorRole).AsEnumerable();

    }
}

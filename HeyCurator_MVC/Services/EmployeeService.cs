using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Services
{
    public class EmployeeService
    {

        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;
        private ClaimsPrincipal _claim;
        public EmployeeService(ApplicationDbContext context, UserManager<IdentityUser> userManager, ClaimsPrincipal claim)
        {
            _context = context;
            _userManager = userManager;
            _claim = claim;
        }

        public Employee GetCurrentlyLoggedInEmployee()
        {
            var user = _userManager.GetUserName(_claim);
            return _context.Employees.Where(e => e.EmployeeUserName == user).FirstOrDefault();
        }

        public Employee GetCurrentlyLoggedInEmployee(IdentityUser user)
        {
            return _context.Employees.Where(e => e.EmployeeUserName == user.UserName).FirstOrDefault();
        }

        public List<Item> GetEmployeesItems()
        {
            return GetEmployeesItems(GetCurrentlyLoggedInEmployee());
        }

        

        public List<Employee> GetEmployeesOfItem(int itemId)
        {
            var spaces = new List<CuratorSpace>();
            //var spaces = _context.ItemInStorages.Where(i => i.ItemId == itemId).Select(i => i.CuratorSpace).ToList();
            //var spaces = _context.ItemInStorages.Where(i => i.ItemId == itemId).Include(i=> i.CuratorSpace).Select(i => i.CuratorSpace).ToList();
            var curatorRoleIds = _context.CuratorSpaces.Where(c => spaces.Contains(c)).Select(c => c.CuratorRoleId).ToList();
            return _context.EmployeeRoles.Where(r => curatorRoleIds.Contains(r.CuratorRoleId)).Include(r => r.Employee).Select(r=> r.Employee).ToList();
        }

        public bool IsEmployeeCuratorOfItem(int itemId)
        {
            Employee employee = GetCurrentlyLoggedInEmployee();
            var curators = GetEmployeesOfItem(itemId);

            return curators.Contains(employee);
        }

        // TODO: Depreciate For New Model

        public List<Item> GetEmployeesItems(Employee employee)
        {
            var curatorRoleIds = _context.EmployeeRoles.Where(e => e.EmployeeId == employee.EmployeeId).Select(e => e.CuratorRoleId).ToList();
            var exhibitSpaceIds = _context.CuratorSpaces.Where(cs => curatorRoleIds.Contains(cs.CuratorRoleId)).Select(cs => cs.ExhibitSpaceId).ToList();
            var exhibitIds = _context.Exhibits.Where(ex => exhibitSpaceIds.Contains(ex.ExhibitSpaceId)).Select(ex=> ex.ExhibitId).ToList();
            var itemInstanceIds = _context.ExhibitItemInstances.Where(eii => exhibitIds.Contains(eii.ExhibitId)).Select(eii=> eii.ItemInstanceId).ToList();
            return _context.ItemInstances.Where(ii => itemInstanceIds.Contains(ii.Id)).Include(ii=> ii.Item).Select(ii => ii.Item).ToList();
        }
    }
}

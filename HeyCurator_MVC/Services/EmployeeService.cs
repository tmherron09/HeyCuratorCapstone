using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
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

    }
}

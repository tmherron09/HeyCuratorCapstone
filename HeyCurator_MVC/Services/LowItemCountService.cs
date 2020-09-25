using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Services
{
    public class LowItemCountService
    {

        private ApplicationDbContext _context;
        private EmployeeService _employeeService;

        public LowItemCountService(ApplicationDbContext context, EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public List<LowCountItem> GetLowCountItemsOfEmployee(string username)
        {
            var employee = _context.Employees.Where(e => (e.EmployeeUserName) == username).SingleOrDefault();

            var employeeItems = _employeeService.GetEmployeesItems(employee);

            return _context.LowCountItems.Where(e => employeeItems.Contains(e.Item)).Include(e => e.Item).ToList();
        }

        public List<LowCountItem> GetAllLowCountItems() =>
            _context.LowCountItems.Include(l => l.Item).ToList();


    }
}

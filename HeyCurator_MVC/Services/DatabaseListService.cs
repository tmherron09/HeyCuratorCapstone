using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Services
{
    public class DatabaseListService
    {
        public DatabaseCollectionContainer DbContainer { get; set; }
        public ApplicationDbContext _context { get; set; }

        public DatabaseListService(ApplicationDbContext context)
        {
            _context = context;
            DbContainer = new DatabaseCollectionContainer();
        }

        public DatabaseCollectionContainer GetAllList()
        {
            DbContainer.Items =  _context.Items.ToList();
            DbContainer.CuratorRoles =  _context.CuratorRoles.ToList();
            DbContainer.CuratorSpaces =  _context.CuratorSpaces.ToList();
            DbContainer.Exhibits =  _context.Exhibits.ToList();
            DbContainer.ExhibitSpaces =  _context.ExhibitSpaces.ToList();
            DbContainer.ExhibitItemInStorages =  _context.ExhibitItemInStorages.ToList();
            DbContainer.ItemInStorages =  _context.ItemInStorages.ToList();
            DbContainer.Storages =  _context.Storages.ToList();
            DbContainer.Employees =  _context.Employees.ToList();

            return DbContainer;
        }

        public List<Employee> GetAllEmployees()
        {

            return _context.Employees.Include(c => c.EmployeeRoles).ToList();
        }
        public List<Item> GetAllItems()
        {
            return _context.Items.Include(i=> i.CuratorSpaces).Include(i=> i.Exhibits).Include(i=> i.ExhibitSpaces).Include(i=> i.ItemInStorages).ThenInclude(s=> s.Storage).ToList();
        }




    }
}

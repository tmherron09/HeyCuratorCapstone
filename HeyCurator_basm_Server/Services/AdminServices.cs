using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyCurator_basm_Server.Data;
using HeyCurator_basm_Server.Models;
using Microsoft.EntityFrameworkCore;

namespace HeyCurator_basm_Server.Services
{
    public class AdminServices
    {
        private ItemDateService _itemDateService;
        private readonly ApplicationDbContext _context;

        public AdminServices(ItemDateService itemDateService, ApplicationDbContext context)
        {
            _itemDateService = itemDateService;
            _context = context;
        }
        public async Task<string> CreateItem(Item item)
        {

            _itemDateService.UpdateItemDates(item);
            _context.Items.Add(item);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ItemExists(item.ItemId))
                {
                    return "Failed to Add Item";
                }
                else
                {
                    throw;
                }
            }
            return "Success";

        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<string> AddCurator(Curator curator)
        {

            _context.Curators.Add(curator);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CuratorExists(curator.CuratorId))
                {
                    return "Failed to Add Curator";
                }
                else
                {
                    throw;
                }
            }
            return "Success";
        }
        public async Task<List<Curator>> GetAllCurators()
        {
            return await _context.Curators.Include(c=> c.Employee).ToListAsync();
        }
        public async Task<string> AddCuratorRole(CuratorRole role)
        {

            if (_context.CuratorRoles.Any(cr => cr.NameOfRole == role.NameOfRole))
            {
                return "Curator Role already exists.";
            }
            _context.CuratorRoles.Add(role);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CuratorRoleExists(role.CuratorRoleId))
                {
                    return "Failed to Add Curator Role";
                }
                else
                {
                    throw;
                }
            }
            return "Success";

        }
        public List<CuratorRole> GetAllCuratorRoles()
        {
            return  _context.CuratorRoles.ToList();
        }
        public async Task<string> AddCuratorSpace(CuratorSpace curatorSpace)
        {

            if (_context.CuratorSpaces.Any(cs => cs.Name == curatorSpace.Name))
            {
                return "Curator Space already exists.";
            }
            _context.CuratorSpaces.Add(curatorSpace);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CuratorSpaceExists(curatorSpace.CuratorSpaceId))
                {
                    return "Failed to Add Curator";
                }
                else
                {
                    throw;
                }
            }
            return "Success";
        }
        public  List<CuratorSpace> GetAllCuratorSpaces()
        {
            return  _context.CuratorSpaces.ToList();
        }
        public async Task<string> AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (EmployeeExists(employee.EmployeeId))
                {
                    return "Failed to Add Employee";
                }
                else
                {
                    throw;
                }
            }
            return "Success";
        }
        public async Task<string> AddExhibitSpace(ExhibitSpace exhibitSpace)
        {

            _context.ExhibitSpaces.Add(exhibitSpace);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExhibitSpaceExists(exhibitSpace.ExhibitSpaceId))
                {
                    return "Failed to Add Exhibit Space";
                }
                else
                {
                    throw;
                }
            }
            return "Success";
        }
        public List<ExhibitSpace> GetAllExhibitSpaces()
        {
            return  _context.ExhibitSpaces.Include(e=> e.CuratorSpace).Include(e=> e.Exhibits).ToList();
        }
        public async Task<string> AddExhibitItemInStorage(ExhibitItemInStorage exhibitItemInStorage)
        {
            _context.ExhibitItemInStorages.Add(exhibitItemInStorage);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExhibitItemInStorageExists(exhibitItemInStorage.ExhibitItemInStorageId))
                {
                    return "Failed to Add Item in storage to exhibit.";
                }
                else
                {
                    throw;
                }
            }
            return "Success";
        }
        public async Task<List<ExhibitItemInStorage>> GetAllExhibitItemInStorage()
        {
            return await _context.ExhibitItemInStorages.Include(e=>e.Exhibit).Include(e=>e.ItemInStorage).ToListAsync();
        }
        public async Task<string> AddExhibit(Exhibit exhibit)
        {

            exhibit.ExhibitSpace = _context.ExhibitSpaces.Where(e => e.ExhibitSpaceId == exhibit.ExhibitSpaceId).Include(es => es.CuratorSpace).FirstOrDefault();
            exhibit.CuratorSpaceId = (int)exhibit.ExhibitSpace.CuratorSpaceId;
            _context.Exhibits.Add(exhibit);
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ExhibitExists(exhibit.ExhibitId))
                {
                    return "Failed to Add Exhibit";
                }
                else
                {
                    throw;
                }
            }
            return "Success";
        }
        public List<Exhibit> GetAllExhibits()
        {
            return  _context.Exhibits.ToList();
        }




        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
        private bool CuratorExists(int id)
        {
            return _context.Curators.Any(e => e.CuratorId == id);
        }
        private bool CuratorRoleExists(int id)
        {
            return _context.CuratorRoles.Any(e => e.CuratorRoleId == id);
        }
        private bool CuratorSpaceExists(int id)
        {
            return _context.CuratorSpaces.Any(e => e.CuratorSpaceId == id);
        }
        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
        private bool ExhibitSpaceExists(int id)
        {
            return _context.ExhibitSpaces.Any(e => e.ExhibitSpaceId == id);
        }
        private bool ExhibitItemInStorageExists(int id)
        {
            return _context.ExhibitItemInStorages.Any(e => e.ExhibitItemInStorageId == id);
        }
        private bool ExhibitExists(int id)
        {
            return _context.Exhibits.Any(e => e.ExhibitId == id);
        }



    }
}

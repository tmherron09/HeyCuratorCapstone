using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Services
{
    public class SelectListService
    {

        private ApplicationDbContext _context;

        public SelectListService(ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList GetAllEmployeeSelectList() =>
            new SelectList(_context.Employees.Where(m => true).ToList(), "EmployeeId", "EmployeeUserName");
        public SelectList GetAllCuratorRoleSelectList() =>
            new SelectList(_context.CuratorRoles.Where(m => true).ToList(), "CuratorRoleId", "NameOfRole");
        public SelectList GetAllCuratorSpaceSelectList() =>
            new SelectList(_context.CuratorSpaces.Where(m => true).ToList(), "CuratorSpaceId", "Name");

        public SelectList GetAllExhibitSpacesSelectList() =>
            new SelectList(_context.ExhibitSpaces.Where(m => true).ToList(), "ExhibitSpaceId", "ExhibitSpaceName");

        public SelectList GetAllExhibitSelectList() =>
            new SelectList(_context.Exhibits.Where(m => true).ToList(), "ExhibitId", "Name");

        public SelectList GetAllItemInstanceSelectList() =>
            new SelectList(_context.ItemInstances.Where(m => true).ToList(), "Id", "ItemInstanceName");
        public SelectList GetAllStorageSelectList() =>
           new SelectList(_context.Storages.Where(m => true).ToList(), "StorageId", "Name");

        public SelectList GetAllItemSelectList() =>
            new SelectList(_context.Items.Where(m => true).ToList(), "ItemId", "Name");


    }
}

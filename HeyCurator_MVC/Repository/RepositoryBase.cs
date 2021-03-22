﻿using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<T> FindAll() =>
            _context.Set<T>().AsNoTracking();

        public IQueryable<T> FindAllBy(Expression<Func<T, bool>> expression) =>
            _context.Set<T>().Where(expression).AsNoTracking();

        public void Add(T entity) =>
            _context.Set<T>().Add(entity);

        public async Task AddAsync(T entity) =>
            await _context.Set<T>().AddAsync(entity);

        public void Update(T entity) =>
           _context.Set<T>().Update(entity);

        public void Save() =>
            _context.SaveChanges();

        public async Task SaveAsync() =>
            await _context.SaveChangesAsync();


        public void Delete(T entity) =>
            _context.Set<T>().Remove(entity);


        // Relational / Joins Need to be called in multiple Classes.

        public IEnumerable<CuratorRole> GetCuratorRolesByEmployee(int employeeId) =>
            _context.EmployeeRoles.Where(er => er.EmployeeId == employeeId).Include(er => er.CuratorRole).Select(er => er.CuratorRole).AsEnumerable();
        public IEnumerable<int> GetCuratorRoleIdsByEmployee(int employeeId) =>
            _context.EmployeeRoles.Where(er => er.EmployeeId == employeeId).Select(er => er.CuratorRoleId).AsEnumerable();
        public IEnumerable<Employee> GetEmployeesByCuratorRole(int curatorRoleId) =>
            _context.EmployeeRoles.Where(er => er.CuratorRoleId == curatorRoleId).Include(er => er.Employee).Select(er => er.Employee).AsEnumerable();
        
        public IEnumerable<CuratorRole> GetCuratorRolesByExhibitSpace(int exhibitSpaceId) =>
            _context.CuratorSpaces.Where(cs => cs.ExhibitSpaceId == exhibitSpaceId).Include(cs => cs.CuratorRole).Select(cs => cs.CuratorRole).AsEnumerable();
        public IEnumerable<ExhibitSpace> GetExhibitSpacesByCuratorRole(int curatorRoleId) =>
            _context.CuratorSpaces.Where(cs => cs.CuratorRoleId == curatorRoleId).Include(cs => cs.ExhibitSpace).Select(cs => cs.ExhibitSpace).AsEnumerable();
        public IEnumerable<int> GetExhibitSpaceIdsByCuratorRole(int curatorRoleId) =>
            _context.CuratorSpaces.Where(cs => cs.CuratorRoleId == curatorRoleId).Select(cs => cs.ExhibitSpaceId).AsEnumerable();

        public IEnumerable<Exhibit> GetExhibitsByExhibitSpace(int exhibitSpaceId) =>
            _context.Exhibits.Where(ex => ex.ExhibitSpaceId == exhibitSpaceId).AsEnumerable();
        public ExhibitSpace GetExhibitSpaceByExhibit(int exhibitId) =>
            _context.Exhibits.Where(ex => ex.ExhibitId == exhibitId).Include(ex => ex.ExhibitSpace).Select(ex => ex.ExhibitSpace).FirstOrDefault();
        public int GetExhibitSpaceIdByExhibit(int exhibitId) =>
            _context.Exhibits.Where(ex => ex.ExhibitId == exhibitId).Select(ex => ex.ExhibitSpaceId).FirstOrDefault();

        public IEnumerable<ItemInstance> GetItemInstanceByExhibit(int exhibitId) =>
            _context.ExhibitItemInstances.Where(eii => eii.ExhibitId == exhibitId).Include(eii => eii.ItemInstance).Select(eii => eii.ItemInstance).AsEnumerable();
        public IEnumerable<Exhibit> GetExhibitsByItemInstance(int itemInstanceId) =>
            _context.ExhibitItemInstances.Where(eii => eii.ItemInstanceId == itemInstanceId).Include(eii => eii.Exhibit).Select(eii => eii.Exhibit).AsEnumerable();

        public IEnumerable<ItemInstance> GetItemInstanceByStorage(int storageId) =>
            _context.StorageItemInstances.Where(sii => sii.StorageId == storageId).Include(sii => sii.ItemInstance).Select(sii => sii.ItemInstance).AsEnumerable();
        public IEnumerable<Storage> GetStoragesByItemInstance(int itemInstanceId) =>
            _context.StorageItemInstances.Where(sii => sii.ItemInstanceId == itemInstanceId).Include(sii => sii.Storage).Select(sii => sii.Storage).AsEnumerable();





    }
}

using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> FindAll();
        IQueryable<T> FindAllBy(Expression<Func<T, bool>> expression);
        void Add(T entity);
        Task AddAsync(T entity);
        void Update(T entity);
        void Save();
        Task SaveAsync();
        void Delete(T entity);

        // From Join Tables
        IEnumerable<CuratorRole> GetCuratorRolesByEmployee(int employeeId);
        IEnumerable<int> GetCuratorRoleIdsByEmployee(int employeeId);
        IEnumerable<Employee> GetEmployeesByCuratorRole(int curatorRoleId);
        IEnumerable<CuratorRole> GetCuratorRolesByExhibitSpace(int exhibitSpaceId);
        IEnumerable<ExhibitSpace> GetExhibitSpacesByCuratorRole(int curatorRoleId);
        IEnumerable<int> GetExhibitSpaceIdsByCuratorRole(int curatorRoleId);
        IEnumerable<Exhibit> GetExhibitsByExhibitSpace(int exhibitSpaceId);
        ExhibitSpace GetExhibitSpaceByExhibit(int exhibitId);
        int GetExhibitSpaceIdByExhibit(int exhibitId);
        IEnumerable<ItemInstance> GetItemInstanceByExhibit(int exhibitId);
        IEnumerable<Exhibit> GetExhibitsByItemInstance(int itemInstanceId);
        IEnumerable<ItemInstance> GetItemInstanceByStorage(int storageId);
        IEnumerable<Storage> GetStoragesByItemInstance(int itemInstanceId);

    }
}

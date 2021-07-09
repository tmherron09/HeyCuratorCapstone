using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public interface IItemInstanceRepository : IRepositoryBase<ItemInstance>
    {
        Task<ItemInstance> GetItemInstanceBase(int itemInstanceId);
        Task<ItemInstance> GetItemInstanceWithStorages(int itemInstanceId);
        Task<ItemInstance> GetItemInstanceWithExhibits(int itemInstanceId);
        Task<ItemInstance> GetItemInstanceWithStoragesAndExhibits(int itemInstanceId);
        Task<IEnumerable<ItemInstance>> GetAllItemInstanceBase();
        Task<IEnumerable<ItemInstance>> GetAllItemInstanceBaseWithStorages();
        Task<IEnumerable<ItemInstance>> GetAllItemInstanceBaseWithExhibits();
        Task<IEnumerable<ItemInstance>> GetAllItemInstanceBaseWithStoragesAndExhibits();

        


    }
}

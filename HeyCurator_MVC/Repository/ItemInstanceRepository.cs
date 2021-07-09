using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class ItemInstanceRepository : RepositoryBase<ItemInstance>, IItemInstanceRepository
    {


        public ItemInstanceRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<IEnumerable<ItemInstance>> GetAllItemInstanceBase()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInstance>> GetAllItemInstanceBaseWithExhibits()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInstance>> GetAllItemInstanceBaseWithStorages()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ItemInstance>> GetAllItemInstanceBaseWithStoragesAndExhibits()
        {
            throw new NotImplementedException();
        }

        public Task<ItemInstance> GetItemInstanceBase(int itemInstanceId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemInstance> GetItemInstanceWithExhibits(int itemInstanceId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemInstance> GetItemInstanceWithStorages(int itemInstanceId)
        {
            throw new NotImplementedException();
        }

        public Task<ItemInstance> GetItemInstanceWithStoragesAndExhibits(int itemInstanceId)
        {
            throw new NotImplementedException();
        }
    }
}

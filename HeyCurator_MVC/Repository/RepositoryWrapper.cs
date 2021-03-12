using HeyCurator_MVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly ApplicationDbContext _context;

        private IEmployeeRepository _employee;
        private ICuratorRoleRepository _curatorRole;
        private IExhibitSpaceRepository _exhibitSpace;
        private IExhibitRepository _exhibit;
        private IItemRepository _item;
        private IItemInstanceRepository _itemInstance;
        private IInventoryControlModelRepository _inventoryControlModel;
        private IStorageRepository _storageSpace;
        private IRecordRepository _updateRecord;

        public RepositoryWrapper(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEmployeeRepository Employee
        {
            get
            {
                if (_employee == null)
                {
                    _employee = new EmployeeRepository(_context);
                }
                return _employee;
            }
        }
        public ICuratorRoleRepository CuratorRole
        {
            get
            {
                if (_curatorRole == null)
                {
                    _curatorRole = new CuratorRoleRepository(_context);
                }
                return _curatorRole;
            }
        }
        public IItemRepository Item
        {
            get
            {
                if (_item == null)
                {
                    _item = new ItemRepository(_context);
                }
                return _item;
            }
        }
        public IExhibitRepository Exhibit
        {
            get
            {
                if (_exhibit == null)
                {
                    _exhibit = new ExhibitRepository(_context);
                }
                return _exhibit;
            }
        }
        public IExhibitSpaceRepository ExhibitSpace
        {
            get
            {
                if (_exhibitSpace == null)
                {
                    _exhibitSpace = new ExhibitSpaceRepository(_context);
                }
                return _exhibitSpace;
            }
        }
        public IStorageRepository Storage
        {
            get
            {
                if (_storageSpace == null)
                {
                    _storageSpace = new StorageRepository(_context);
                }
                return _storageSpace;
            }
        }
        public IRecordRepository Record
        {
            get
            {
                if (_updateRecord == null)
                {
                    _updateRecord = new RecordRepository(_context);
                }
                return _updateRecord;
            }
        }
        public IItemInstanceRepository ItemInstance
        {
            get
            {
                if (_itemInstance == null)
                {
                    _itemInstance = new ItemInstanceRepository(_context);
                }
                return _itemInstance;
            }
        }
        public IInventoryControlModelRepository InventoryControlModel
        {
            get
            {
                if (_inventoryControlModel == null)
                {
                    _inventoryControlModel = new InventoryControlModelRepository(_context);
                }
                return _inventoryControlModel;
            }
        }



    }
}

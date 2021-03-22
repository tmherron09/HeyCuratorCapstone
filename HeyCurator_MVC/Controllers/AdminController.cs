using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HeyCurator_MVC.Data;
using HeyCurator_MVC.Hubs;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.Repository;
using HeyCurator_MVC.Services;
using HeyCurator_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace HeyCurator_MVC.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext _context;
        private ItemDateService _dateService;
        private DataAccessService _data;
        private ItemCountService _itemService;
        private object dbLock;
        private IHubContext<ChatHub> _hub;
        private readonly IRepositoryWrapper _repo;

        public AdminController(ApplicationDbContext context, ItemDateService dateService, DataAccessService data, ItemCountService itemService, IHubContext<ChatHub> hub, IRepositoryWrapper repo)
        {
            _context = context;
            _dateService = dateService;
            _data = data;
            _itemService = itemService;
            dbLock = new object();
            _hub = hub;
            _repo = repo;
        }


        public IActionResult Index()
        {



            return View();
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            
            // Present Model Requires Employee To Register Themselves with Admin Secrets Code.
            // Only For Demo/Testing.


            return View();
        }

        [HttpGet]
        public IActionResult CreateCuratorRole()
        {

            CreateCuratorRoleViewModel curatorViewModel = new CreateCuratorRoleViewModel();

            return View(curatorViewModel);
        }

        [HttpPost]
        public IActionResult CreateCuratorRole(CreateCuratorRoleViewModel viewModel)
        {
            if(!ModelState.IsValid)
            {
                
                return View();
            }
            _context.CuratorRoles.Add(viewModel.Curator);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to create role.");
            }

            if (viewModel.InitialEmployeeId != -1)
            { 
                EmployeeRoles empRole = new EmployeeRoles()
                {
                    EmployeeId = viewModel.InitialEmployeeId,
                    CuratorRoleId = viewModel.Curator.CuratorRoleId
                };
                _context.EmployeeRoles.Add(empRole);
                try
                {
                    lock (dbLock)
                    {
                        _context.SaveChanges();
                    }
                }
                catch
                {
                    throw new Exception("Unable to Employee/Curator Role Join.");
                }
            }
            DelayedClientAnnounce("PopCustomToast", $"Curator Role Update", $"{viewModel.Curator.NameOfRole} has been created by {User.Identity.Name}.", "yellow", "fa-bell");

            return View("Index");
        }


        [HttpGet]
        public IActionResult CreateExhibitSpace()
        {

            CreateExhibitSpaceViewModel exhibitSpaceViewModel = new CreateExhibitSpaceViewModel();

            return View(exhibitSpaceViewModel);
        }

        [HttpPost]
        public IActionResult CreateExhibitSpace(CreateExhibitSpaceViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                
                return View();
            }
            _context.ExhibitSpaces.Add(viewModel.ExhibitSpace);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Exhibit Space.");
            }
            CuratorSpace curSpace = new CuratorSpace()
            {
                CuratorRoleId = viewModel.InitialCuratorRoleId,
                ExhibitSpaceId = viewModel.ExhibitSpace.ExhibitSpaceId
            };
            _context.CuratorSpaces.Add(curSpace);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Exhibit Space/Curator Role Join.");
            }

            DelayedClientAnnounce("PopCustomToast", $"Exhibit Space Update", $"{viewModel.ExhibitSpace.ExhibitSpaceName} has been created by {User.Identity.Name}.", "yellow", "fa-bell");

            return View("Index");
        }

        [HttpGet]
        public IActionResult CreateExhibit()
        {

            CreateExhibitViewModel exhibitViewModel = new CreateExhibitViewModel();

            return View(exhibitViewModel);
        }

        [HttpPost]
        public IActionResult CreateExhibit(CreateExhibitViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            viewModel.Exhibit.ExhibitSpaceId = viewModel.AssignedExhibitSpaceId;
            

            _context.Exhibits.Add(viewModel.Exhibit);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Exhibit Space.");
            }


            DelayedClientAnnounce("PopCustomToast", $"Exhibit Update ", $"{viewModel.Exhibit.Name} has been created by {User.Identity.Name}.", "yellow", "fa-bell");

            return View("Index");
        }


        [HttpGet]
        public IActionResult CreateItem()
        {
            Item item = new Item();
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Items.Add(item);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Create Item Type.");
            }
            //_hub.Clients.All.SendAsync("PopCustomToast", $"Item Type Update ", $"{item.Name} has been created by ${User.Identity.Name}.", "yellow", "fa-bell");
            
            DelayedClientAnnounce("PopCustomToast", $"Item Type Update ", $"{item.Name} has been created by {User.Identity.Name}.", "yellow", "fa-bell");

            return View("Index");
        }

        [HttpGet]
        public IActionResult CreateItemInstance()
        {
            CreateIteminstanceViewModel itemInstance = new CreateIteminstanceViewModel();
            return View(itemInstance);
        }

        [HttpPost]
        public IActionResult CreateItemInstance(CreateIteminstanceViewModel itemInstanceViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.ItemInstances.Add(itemInstanceViewModel.ItemInstance);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Create Item Instance.");
            }
            itemInstanceViewModel.InventoryControlModel.ItemInstanceId = itemInstanceViewModel.ItemInstance.Id;
            _context.InventoryControlModels.Add(itemInstanceViewModel.InventoryControlModel);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Create Inventory Control Model.");
            }
            DelayedClientAnnounce("PopCustomToast", $"Item Instance Update ", $"{itemInstanceViewModel.ItemInstance.ItemInstanceName} has been created by {User.Identity.Name}.", "yellow", "fa-bell");

            return View("Index");
        }

        [HttpGet]
        public IActionResult CreateStorage()
        {
            Storage storage = new Storage();
            return View(storage);
        }

        [HttpPost]
        public IActionResult CreateStorage(Storage storage)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _context.Storages.Add(storage);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Create Storage.");
            }
            DelayedClientAnnounce("PopCustomToast", $"Storage  Update ", $"{storage.Name} has been created by {User.Identity.Name}.", "yellow", "fa-bell");

            return View("Index");
        }

        [HttpGet]
        public IActionResult EmpAssignCurRol()
        {

            List<Employee> employees = _repo.Employee.FindAll().ToList();

            return View(employees);
        }

        [HttpGet]
        public PartialViewResult EmpAssignCurRolPartial(int id)
        {
            EmpAssignCurRolViewModel model = new EmpAssignCurRolViewModel();
            model.EmployeeId = id;
            model.EmployeeName = _repo.Employee.EmployeeNameById(id);
            model.CuratorRoles = _repo.CuratorRole.FindAll().ToList();

            model.AlreadyAssigned = _repo.Employee.GetCuratorRoleIds(id);

            var partial = new PartialViewResult
            {
                ViewName = "_EmpAssignCurRolPartial",
                ViewData = new ViewDataDictionary<EmpAssignCurRolViewModel>(ViewData, model)
            };

            return partial;
        }

        [HttpPost]
        public IActionResult EmpAssignCurRol(EmpAssignCurRolViewModel viewModel)
        {
            //Check if valid, ModelState will false negative
            if( viewModel.EmployeeId <= 0)
            {
                // pass error
                return View();
            }

            // Null would Presumably represent all Curator Roles being removed from an employee.
            if(viewModel.ChoosenCuratorRoles == null)
            {
                viewModel.ChoosenCuratorRoles = new List<int>();
            }

            // TODO: ViewModel not catching list on post
            List<int> alreadyAssigned = _repo.Employee.GetCuratorRoleIds(viewModel.EmployeeId);
            
            foreach(var curRole in alreadyAssigned)
            {
                if(!viewModel.ChoosenCuratorRoles.Contains(curRole))
                {
                    EmployeeRoles empRol = _context.EmployeeRoles.Where(er => er.CuratorRoleId == curRole && er.EmployeeId == viewModel.EmployeeId).FirstOrDefault();
                    _context.EmployeeRoles.Remove(empRol);
                }
                else
                {
                    viewModel.ChoosenCuratorRoles.Remove(curRole);
                }
            }
            foreach(int id in viewModel.ChoosenCuratorRoles)
            {
                EmployeeRoles addEmpRol = new EmployeeRoles
                {
                    EmployeeId = viewModel.EmployeeId,
                    CuratorRoleId = id
                };
                _context.EmployeeRoles.Add(addEmpRol);
            }
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Process Assignments.");
            }

            DelayedClientAnnounce("PopCustomToast", $"Employee  Update ", $"{viewModel.EmployeeName} has had its Curator Roles updated.", "yellow", "fa-bell");

            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult CurRolAssignExhibitSpace()
        {
            List<CuratorRole> curatorRoles = _repo.CuratorRole.FindAll().ToList();
            return View(curatorRoles);
        }

        [HttpGet]
        public PartialViewResult CurRolAssignExhibitSpacePartial(int id)
        {
            CurRolAssignExhibitSpaceViewModel model = new CurRolAssignExhibitSpaceViewModel();
            model.CuratorRoleId = id;
            model.CuratorRoleName = _repo.CuratorRole.CuratorRoleNameById(id);
            model.ExhibitSpaces = _repo.ExhibitSpace.FindAll().ToList();

            model.AlreadyAssigned = _repo.CuratorRole.GetExhibitSpaceIds(id);

            var partial = new PartialViewResult
            {
                ViewName = "_CurRolAssignExhibitSpacePartial",
                ViewData = new ViewDataDictionary<CurRolAssignExhibitSpaceViewModel>(ViewData, model)
            };

            return partial;
        }

        [HttpPost]
        public IActionResult CurRolAssignExhibitSpace(CurRolAssignExhibitSpaceViewModel viewModel)
        {
            //Check if valid, ModelState will false negative
            if (viewModel.CuratorRoleId <= 0)
            {
                // pass error
                return View();
            }

            // Null would Presumably represent all Curator Roles being removed from an employee.
            if (viewModel.ChoosenExhibitSpaces == null)
            {
                viewModel.ChoosenExhibitSpaces = new List<int>();
            }

            // TODO: ViewModel not catching list on post
            List<int> alreadyAssigned = _repo.CuratorRole.GetExhibitSpaceIds(viewModel.CuratorRoleId);

            foreach (var exhibitSpaceId in alreadyAssigned)
            {
                if (!viewModel.ChoosenExhibitSpaces.Contains(exhibitSpaceId))
                {
                    CuratorSpace curatorSpace = _context.CuratorSpaces.Where(cs => cs.ExhibitSpaceId == exhibitSpaceId && cs.CuratorRoleId == viewModel.CuratorRoleId).FirstOrDefault();
                    _context.CuratorSpaces.Remove(curatorSpace);
                }
                else
                {
                    viewModel.ChoosenExhibitSpaces.Remove(exhibitSpaceId);
                }
            }
            foreach (int id in viewModel.ChoosenExhibitSpaces)
            {

                CuratorSpace addCuratorSpace = new CuratorSpace
                {
                    CuratorRoleId = viewModel.CuratorRoleId,
                    ExhibitSpaceId = id
                };
                _context.CuratorSpaces.Add(addCuratorSpace);
            }
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Process Assignments.");
            }
            DelayedClientAnnounce("PopCustomToast", $"Curator Role  Update ", $"{viewModel.CuratorRoleName} has had its Exhibit Spaces updated.", "yellow", "fa-bell");

            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult ExhibitAssignExhibitSpace()
        {
            List<Exhibit> exhibits = _repo.Exhibit.FindAll().ToList();
            return View(exhibits);
        }

        [HttpGet]
        public PartialViewResult ExhibitAssignExhibitSpacePartial(int id)
        {
            ExhibitAssignExhibitSpaceViewModel viewModel = new ExhibitAssignExhibitSpaceViewModel();
            viewModel.ExhibitId = id;
            viewModel.ExhibitName = _repo.Exhibit.ExhibitNameById(id);
            viewModel.ExhibitSpaces = _repo.ExhibitSpace.FindAll().ToList();
            viewModel.AlreadyAssigned = _repo.Exhibit.GetExhibitSpaceIdByExhibit(id);

            var partial = new PartialViewResult
            {
                ViewName = "_ExhibitAssignExhibitSpacePartial",
                ViewData = new ViewDataDictionary<ExhibitAssignExhibitSpaceViewModel>(ViewData, viewModel)
            };

            return partial;

        }

        [HttpPost]
        public IActionResult ExhibitAssignExhibitSpace(ExhibitAssignExhibitSpaceViewModel viewModel)
        {
            //Check if valid, ModelState will false negative
            if (viewModel.ExhibitId <= 0)
            {
                // pass error
                return View();
            }

            Exhibit exhibitToUpdate = _repo.Exhibit.FindAllBy(ex => ex.ExhibitId == viewModel.ExhibitId).FirstOrDefault();
            exhibitToUpdate.ExhibitSpaceId = viewModel.ChoosenExhibitSpace;
            _context.Exhibits.Update(exhibitToUpdate);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to Process Assignment.");
            }
            DelayedClientAnnounce("PopCustomToast", $"Exhibit  Update ", $"{viewModel.ExhibitName} has had its Exhibit Space updated.", "yellow", "fa-bell");

            return RedirectToAction("Index");

        }



        public async Task DelayedClientAnnounce(string type, string label, string message, string color, string icon)
        {
            await Task.Delay(5000);
            await _hub.Clients.All.SendAsync(type, label, message, color, icon);
        }
        


    }
}

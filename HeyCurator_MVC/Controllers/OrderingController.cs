using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Controllers
{
    [Authorize]
    public class OrderingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private EmployeeService _employeeService;
        private object dbLock;

        public OrderingController(ApplicationDbContext context, EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
            dbLock = new object();
        }

        // GET: Ordering
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PurchaserNotifications.Include(p => p.Employee).Include(p => p.Item);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Ordering/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaserNotification = await _context.PurchaserNotifications
                .Include(p => p.Employee)
                .Include(p => p.Item)
                .FirstOrDefaultAsync(m => m.PurchaserNotificationId == id);
            if (purchaserNotification == null)
            {
                return NotFound();
            }

            return View(purchaserNotification);
        }


        public IActionResult Create()
        {
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Name");


            return View();
        }


        [HttpPost]
        public IActionResult Create([Bind("ItemId,AmountRequested,OrderUrgency,CuratorNote")] PurchaserNotification purchaserNotification)
        {
            if (!ModelState.IsValid)
            {

                return RedirectToAction(nameof(Index));
            }
            var username = HttpContext.Session.GetString("username");
            Item item = _context.Items.Where(i => i.ItemId == purchaserNotification.ItemId).FirstOrDefault();
            purchaserNotification.CurrentStock = item.RecordedStorageAmount;
            purchaserNotification.EmployeeId = _employeeService.GetCurrentlyLoggedInEmployee().EmployeeId;
            purchaserNotification.TimeStamp = DateTime.Now;

            _context.PurchaserNotifications.Add(purchaserNotification);

            try
            {
                _context.SaveChanges();
            }
            catch
            {
                throw new Exception("Unable to create purchase request.");
            }

            _context.Entry(purchaserNotification).GetDatabaseValues();

            return View("Details", purchaserNotification);
        }












        // GET: Ordering/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaserNotification = await _context.PurchaserNotifications
                .Include(p => p.Employee)
                .Include(p => p.Item)
                .FirstOrDefaultAsync(m => m.PurchaserNotificationId == id);


            if (purchaserNotification == null)
            {
                return NotFound();
            }

            return View(purchaserNotification);
        }

        // POST: Ordering/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PurchaserNotificationId,ItemId,EmployeeId,TimeStamp,CurrentStock,AmountRequested,OrderUrgency,CuratorNote,PurchaserNote,OrderRefId,IsFullFilled")] PurchaserNotification purchaserNotification)
        {
            if (id != purchaserNotification.PurchaserNotificationId)
            {
                return NotFound();
            }

            purchaserNotification.TimeStamp = _context.PurchaserNotifications.Where(n => n.PurchaserNotificationId == purchaserNotification.PurchaserNotificationId).Select(p => p.TimeStamp).FirstOrDefault();
            purchaserNotification.CuratorNote = _context.PurchaserNotifications.Where(n => n.PurchaserNotificationId == purchaserNotification.PurchaserNotificationId).Select(p => p.CuratorNote).FirstOrDefault();


            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(purchaserNotification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PurchaserNotificationExists(purchaserNotification.PurchaserNotificationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "EmployeeId", "FirstName", purchaserNotification.EmployeeId);
            ViewData["ItemId"] = new SelectList(_context.Items, "ItemId", "Name", purchaserNotification.ItemId);
            return View(purchaserNotification);
        }

        // GET: Ordering/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var purchaserNotification = await _context.PurchaserNotifications
                .Include(p => p.Employee)
                .Include(p => p.Item)
                .FirstOrDefaultAsync(m => m.PurchaserNotificationId == id);
            if (purchaserNotification == null)
            {
                return NotFound();
            }

            return View(purchaserNotification);
        }

        // POST: Ordering/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var purchaserNotification = await _context.PurchaserNotifications.FindAsync(id);
            _context.PurchaserNotifications.Remove(purchaserNotification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PurchaserNotificationExists(int id)
        {
            return _context.PurchaserNotifications.Any(e => e.PurchaserNotificationId == id);
        }
    }
}

using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.Services;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;

namespace HeyCurator_MVC.MessageService
{
    public class HeyCuratorMailService
    {
        private ApplicationDbContext _context;
        private EmployeeService _employeeService;

        public HeyCuratorMailService(ApplicationDbContext context, EmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }

        public List<HeyCuratorMail> GetMail()
        {
            List<HeyCuratorMail> EmployeeMail = new List<HeyCuratorMail>();

            Employee employee = _employeeService.GetCurrentlyLoggedInEmployee();

            return _context.HeyCuratorMails.Where(m => m.SenderId == employee.EmployeeId && m.RecipientId == employee.EmployeeId).ToList();
        }

        public List<HeyCuratorMail> GetMail(IdentityUser User)
        {
            List<HeyCuratorMail> EmployeeMail = new List<HeyCuratorMail>();
            Employee employee = _employeeService.GetCurrentlyLoggedInEmployee(User);
            return _context.HeyCuratorMails.Where(m => m.SenderId == employee.EmployeeId && m.RecipientId == employee.EmployeeId).ToList();
        }

        public EmployeeMailbox GetMailBox()
        {
            Employee employee = _employeeService.GetCurrentlyLoggedInEmployee();
            EmployeeMailbox mailbox = new EmployeeMailbox();
            var employeeMail = GetMailBoxAll(employee);
            mailbox.UnreadMail = GetUnreadMail(employeeMail, employee);
            mailbox.ReadMail = GetReadMail(employeeMail, employee);
            mailbox.SentMail = GetSentMail(employeeMail, employee);
            return mailbox;
        }
        public IEnumerable<HeyCuratorMail> GetMailBoxAll(Employee employee) =>
            _context.HeyCuratorMails.Where(m => m.SenderId == employee.EmployeeId && m.RecipientId == employee.EmployeeId).AsEnumerable();


        public List<HeyCuratorMail> GetUnreadMail(IEnumerable<HeyCuratorMail> Mail, Employee employee) =>
            Mail.Where(m => m.RecipientId == employee.EmployeeId && !m.HasBeenRead && !m.RecipientDeleted).ToList();

        public List<HeyCuratorMail> GetReadMail(IEnumerable<HeyCuratorMail> Mail, Employee employee) =>
            Mail.Where(m => m.RecipientId == employee.EmployeeId && m.HasBeenRead && !m.RecipientDeleted).ToList();

        public List<HeyCuratorMail> GetSentMail(IEnumerable<HeyCuratorMail> Mail, Employee employee) =>
            Mail.Where(m => m.SenderId == employee.EmployeeId && !m.SenderDeleted).ToList();

        public bool HasUnreadMail()
        {
            Employee employee = _employeeService.GetCurrentlyLoggedInEmployee();
            return _context.HeyCuratorMails.Any(e => e.RecipientId == employee.EmployeeId && !e.HasBeenRead);
        }
        public int CountOfUnreadMail()
        {
            Employee employee = _employeeService.GetCurrentlyLoggedInEmployee();
            return _context.HeyCuratorMails.Where(e => e.RecipientId == employee.EmployeeId && !e.HasBeenRead).Count();
        }

    }
}

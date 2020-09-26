using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyCurator_MVC.MessageService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HeyCurator_MVC.Controllers
{
    [Authorize]
    public class InboxController : Controller
    {
        private HeyCuratorMailService _mail;
        public InboxController(HeyCuratorMailService mail)
        {
            _mail = mail;
        }


        public IActionResult Index()
        {
            EmployeeMailbox mailbox = _mail.GetMailBox();

            return View(mailbox);
        }

        public PartialViewResult UnreadMail(List<HeyCuratorMail> heyCuratorMails)
        {

            return null;
        }

        public PartialViewResult ReadMail(List<HeyCuratorMail> heyCuratorMails)
        {
            return null;
        }

        public PartialViewResult ComposeMail(HeyCuratorMail mail)
        {
            if(mail == null || mail.RecipientId == 0)
            {
                // ViewBag["HasRecipient"] = 0
                //Return Partial with choose recipient.
            }
            else
            {
                // ViewBag["HasRecipient"] = 1
                //Return Partial with preset Recipient.
            }


            return null;
        }


        public PartialViewResult ReadMail(HeyCuratorMail mail)
        {
            if (mail == null || mail.HeyCuratorMailId == 0)
            {

            }
            return null;

        }


    }
}

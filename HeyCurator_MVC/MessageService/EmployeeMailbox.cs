using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.MessageService
{
    public class EmployeeMailbox
    {

        public List<HeyCuratorMail> UnreadMail { get; set; }
        public List<HeyCuratorMail> ReadMail { get; set; }
        public List<HeyCuratorMail> SentMail { get; set; }
        public List<HeyCuratorMail> DeletedMail { get; set; }

        public EmployeeMailbox()
        {

        }


    }
}

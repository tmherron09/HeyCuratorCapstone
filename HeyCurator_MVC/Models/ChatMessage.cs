using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Models
{
    public class ChatMessage
    {
        public int ChatMessageId { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public DateTime Date { get; set; }
    }
}

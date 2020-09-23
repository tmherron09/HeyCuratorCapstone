using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.MessageService
{
    public class HeyCuratorMail
    {
        [Key]
        public int HeyCuratorMailId { get; set; }

        
        
        public int? SenderId { get; set; }
        [ForeignKey("SenderId")]
        public Employee Sender { get; set; }
        
        public int? RecipientId { get; set; }
        [ForeignKey("RecipientId")]
        public Employee Recipient { get; set; }


        [Required]
        [DisplayName("Message Title")]
        public string Title { get; set; }


        [Required]
        [DisplayName("Message Content")]
        public string MessageContent { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{h:mm:ss tt, M/d}")]
        public DateTime DateMessageSent { get; set; }

        public bool HasBeenRead { get; set; }

        // Essenitially moves to trash for both parties.
        // Currently not HeyCurator mail is deleted, regular maintenance will delete trashcan
        // messages or stored for HR reasons.
        public bool SenderDeleted { get; set; }
        public bool RecipientDeleted { get; set; }
    }
}

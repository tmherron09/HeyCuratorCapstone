using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.UserState
{


    /// <summary>
    /// Temporary Class/ Entry to store User State, what messages have been seen and which have not.
    /// </summary>
    public class UserState
    {
        [Key]
        public string UserId { get; set; }

        public DateTime LastTimeReadHeyCuratorMail { get; set; }
        public DateTime LastTimeAQRead { get; set; }
        public Guid LastChatRead { get; set; }

    }
}

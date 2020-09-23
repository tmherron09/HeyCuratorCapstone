using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.HostedServices
{
    public class ICBEventTrigger
    {
        public event Func<Task> ItemExpiratioNotice;

        public void UpdatedPendingItems()
        {

            this.ItemExpiratioNotice?.Invoke();
        }

    }
}

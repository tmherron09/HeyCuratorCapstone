using HeyCurator_MVC.Services;
using HeyCurator_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.ViewComponents
{
    public class ItemsViewComponent : ViewComponent
    {
        private DatabaseListService _data;
        public ItemsViewComponent(DatabaseListService data)
        {
            _data = data;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = await _data.GetAllItemsAsync();
            return View(items);
        }

    }
}

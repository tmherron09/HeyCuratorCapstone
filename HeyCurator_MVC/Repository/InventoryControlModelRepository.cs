﻿using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public class InventoryControlModelRepository : RepositoryBase<InventoryControlModel>, IInventoryControlModelRepository
    {


        public InventoryControlModelRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}

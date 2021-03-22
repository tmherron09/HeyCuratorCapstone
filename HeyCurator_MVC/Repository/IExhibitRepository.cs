using HeyCurator_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Repository
{
    public interface IExhibitRepository : IRepositoryBase<Exhibit>
    {
        string ExhibitNameById(int id);


    }
}

﻿using HeyCurator_MVC.Data;
using HeyCurator_MVC.Models;
using HeyCurator_MVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeyCurator_MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ApplicationDbContext _context;

        private DataAccessService _data;
        public SearchController(ApplicationDbContext context, DataAccessService dataService)
        {
            _context = context;
            _data = dataService;
        }


        #region Item Search

        [HttpGet("item")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems()
        {
            return await _context.Items.ToListAsync();
        }

        //// GET: api/SearchApi/5
        //[HttpGet("item/{input}")]
        //public async Task<ActionResult<List<Item>>> FindItem(string input)
        //{
        //    var items = await _context.Items.Where(i => i.Name.Contains(input)).ToListAsync();
        //    if (items == null)
        //    {
        //        return NotFound();
        //    }
        //    return items;
        //}

        [HttpGet("itemResult/{id}")]
        public async Task<ActionResult<SearchResult>> FindResultItem(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item == null)
            {
                return new SearchResult();
            }

            SearchResult result = CreateSearchResult(item);

            return result;
        }

        [HttpGet("itemResults/{input}")]
        public async Task<ActionResult<List<SearchResult>>> FindResultItems(string input = "")
        {
            var items = await _context.Items.Where(i => i.Name.Contains(input)).ToListAsync();
            if (items == null)
            {
                var list = new List<SearchResult>();
                list.Add(new SearchResult());
                return list;
            }
            List<SearchResult> results = new List<SearchResult>();

            foreach (var item in items)
            {
                var result = CreateSearchResult(item);
                results.Add(result);
            }
            return results;
        }

        #endregion


        #region Exhibit Search


        [HttpGet("exhibit")]
        public async Task<ActionResult<IEnumerable<Exhibit>>> GetExhibits()
        {
            return await _context.Exhibits.ToListAsync();
        }


        [HttpGet("exhibitResults/{input}")]
        public async Task<ActionResult<List<SearchResult>>> FindResultExhibits(string input = "")
        {
            var exhibits = await _context.Exhibits.Where(i => i.Name.Contains(input)).ToListAsync();
            if (exhibits == null)
            {
                var list = new List<SearchResult>();
                list.Add(new SearchResult());
                return list;
            }
            List<SearchResult> results = new List<SearchResult>();
            foreach (var exhibit in exhibits)
            {
                var result = CreateSearchResult(exhibit);
                results.Add(result);
            }
            return results;
        }


        #endregion


        #region Exhibit Space Search

        [HttpGet("exhibitSpaceResults/{input}")]
        public async Task<ActionResult<List<SearchResult>>> FindResultExhibitSpaces(string input = "")
        {
            var exhibits = await _context.ExhibitSpaces.Where(i => i.ExhibitSpaceName.Contains(input)).ToListAsync();
            if (exhibits == null)
            {
                var list = new List<SearchResult>();
                list.Add(new SearchResult());
                return list;
            }
            List<SearchResult> results = new List<SearchResult>();
            foreach (var exhibitSpace in exhibits)
            {
                var result = CreateSearchResult(exhibitSpace);
                results.Add(result);
            }
            return results;
        }



        #endregion


        #region Curator Space Search

        [HttpGet("curatorSpaceResults/{input}")]
        public async Task<ActionResult<List<SearchResult>>> FindResultCuratorSpaces(string input = "")
        {
            var curatorSpaces = await _context.CuratorSpaces.Where(i => i.Name.Contains(input)).ToListAsync();
            if (curatorSpaces == null)
            {
                var list = new List<SearchResult>();
                list.Add(new SearchResult());
                return list;
            }
            List<SearchResult> results = new List<SearchResult>();
            foreach (var curatorSpace in curatorSpaces)
            {
                var result = CreateSearchResult(curatorSpace);
                results.Add(result);
            }
            return results;
        }




        #endregion


        #region Curator Roles


        [HttpGet("curatorRoleResults/{input}")]
        public async Task<ActionResult<List<SearchResult>>> FindResultCuratorRoles(string input = "")
        {
            var curatorRoles = await _context.CuratorRoles.Where(i => i.NameOfRole.Contains(input)).ToListAsync();
            if (curatorRoles == null)
            {
                var list = new List<SearchResult>();
                list.Add(new SearchResult());
                return list;
            }
            List<SearchResult> results = new List<SearchResult>();

            foreach (var curatorRole in curatorRoles)
            {
                var result = CreateSearchResult(curatorRole);
                results.Add(result);
            }

            return results;
        }


        #endregion



        #region Storage Search

        [HttpGet("storageResults/{input}")]
        public async Task<ActionResult<List<SearchResult>>> FindResultStorage(string input = "")
        {
            var storages = await _context.Storages.Where(i => i.Name.Contains(input)).ToListAsync();
            if (storages == null)
            {
                var list = new List<SearchResult>();
                list.Add(new SearchResult());
                return list;
            }
            List<SearchResult> results = new List<SearchResult>();
            foreach (var storage in storages)
            {
                var result = CreateSearchResult(storage);
                results.Add(result);
            }
            return results;
        }



        #endregion

        #region Employee Search


        [HttpGet("employeeResults/{input}")]
        public async Task<ActionResult<List<SearchResult>>> FindResultEmployee(string input = "")
        {
            var employees = await _context.Employees.Where(i => i.FirstName.Contains(input) || i.LastName.Contains(input)).ToListAsync();
            if (employees == null)
            {
                var list = new List<SearchResult>();
                list.Add(new SearchResult());
                return list;
            }
            List<SearchResult> results = new List<SearchResult>();
            foreach (var employee in employees)
            {
                var result = CreateSearchResult(employee);
                results.Add(result);
            }
            return results;
        }


        #endregion


        #region General Search



        // General Search All

        /// <summary>
        /// Search all items by Name. Then combines into one SearchResult struct Alphabetically
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpGet("results/{input}")]
        public ActionResult<List<SearchResult>> FindResults(string input = "")
        {
            var items = _context.Items.Where(i => i.Name.Contains(input)).AsEnumerable();
            var exhibits = _context.Exhibits.Where(i => i.Name.Contains(input)).AsEnumerable();
            var exhibitSpaces = _context.ExhibitSpaces.Where(i => i.ExhibitSpaceName.Contains(input)).AsEnumerable();
            var curatorSpaces = _context.CuratorSpaces.Where(i => i.Name.Contains(input)).AsEnumerable();
            var employees = _context.Employees.Where(i => i.FirstName.Contains(input) || i.LastName.Contains(input)).AsEnumerable();
            var storages = _context.Storages.Where(i => i.Name.Contains(input)).AsEnumerable();
            var curatorRoles = _context.CuratorRoles.Where(i => i.NameOfRole.Contains(input)).AsEnumerable();

            IEnumerable<SearchResult> unorderedResult = new List<SearchResult>();
            if (items != null || items.Count() != 0)
            {
                foreach (var item in items)
                {
                    var result = CreateSearchResult(item);
                    unorderedResult.Append(result);
                }
            }
            if (exhibits != null || exhibits.Count() != 0)
            {
                foreach (var exhibit in exhibits)
                {
                    var result = CreateSearchResult(exhibit);
                    unorderedResult.Append(result);
                }
            }
            if (exhibitSpaces != null || exhibitSpaces.Count() != 0)
            {
                foreach (var exhibitSpace in exhibitSpaces)
                {
                    var result = CreateSearchResult(exhibitSpace);
                    unorderedResult.Append(result);
                }
            }
            if (curatorSpaces != null || curatorSpaces.Count() != 0)
            {
                foreach (var curatorSpace in curatorSpaces)
                {
                    var result = CreateSearchResult(curatorSpace);
                    unorderedResult.Append(result);
                }
            }
            if (employees != null || employees.Count() != 0)
            {
                foreach (var employee in employees)
                {
                    var result = CreateSearchResult(employee);
                    unorderedResult.Append(result);
                }
            }
            if (storages != null || storages.Count() != 0)
            {
                foreach (var storage in storages)
                {
                    var result = CreateSearchResult(storage);
                    unorderedResult.Append(result);
                }
            }
            if (curatorRoles != null || curatorRoles.Count() != 0)
            {
                foreach (var role in curatorRoles)
                {
                    var result = CreateSearchResult(role);
                    unorderedResult.Append(result);
                }
            }

            List<SearchResult> results = unorderedResult.OrderBy(r => r.Name).ToList();

            return results;
        }



        #endregion

        #region Search Result Constructors

        private SearchResult CreateSearchResult(Item item)
        {
            var result = new SearchResult
            {
                Name = item.Name,
                Type = "Item",
                Id = item.ItemId
            };
            return result;
        }
        private SearchResult CreateSearchResult(Exhibit exhibit)
        {
            var result = new SearchResult
            {
                Name = exhibit.Name,
                Type = "Exhibit",
                Id = exhibit.ExhibitId
            };
            return result;
        }
        private SearchResult CreateSearchResult(ExhibitSpace exhibitSpace)
        {
            var result = new SearchResult
            {
                Name = exhibitSpace.ExhibitSpaceName,
                Type = "Exhibit Space",
                Id = exhibitSpace.ExhibitSpaceId
            };
            return result;
        }
        private SearchResult CreateSearchResult(CuratorSpace curatorSpace)
        {
            var result = new SearchResult
            {
                Name = curatorSpace.Name,
                Type = "Curator Space",
                Id = curatorSpace.CuratorSpaceId
            };
            return result;
        }
        private SearchResult CreateSearchResult(Employee employee)
        {
            var result = new SearchResult
            {
                Name = $"{employee.FirstName} {employee.LastName[0]}.",
                Type = "Employee",
                Id = employee.EmployeeId
            };
            return result;
        }
        private SearchResult CreateSearchResult(Storage storage)
        {
            var result = new SearchResult
            {
                Name = storage.Name,
                Type = "Storage",
                Id = storage.StorageId
            };
            return result;
        }
        private SearchResult CreateSearchResult(CuratorRole curatorRole)
        {
            var result = new SearchResult
            {
                Name = role.NameOfRole,
                Type = "Curator Role",
                Id = role.CuratorRoleId
            };
            return result;
        }


        #endregion


    }

    public struct SearchResult
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }

    }


}

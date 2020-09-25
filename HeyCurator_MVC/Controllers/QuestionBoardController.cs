using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HeyCurator_MVC.AnonymousQuestionBoard;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using HeyCurator_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using HeyCurator_MVC.ViewModels;

namespace HeyCurator_MVC.Controllers
{
    [Authorize]
    public class QuestionBoardController : Controller
    {
        private UserManager<IdentityUser> _userManager;
        private ApplicationDbContext _context;
        private object dbLock;
        public QuestionBoardController(UserManager<IdentityUser> userManager, ApplicationDbContext contex)
        {
            _userManager = userManager;
            _context = contex;
            dbLock = new object();
        }

        /// <summary>
        /// Entry Page, reminder that while these are anonymous to other patreons, all questions, comments, and other actions are recorded into the database. These records are accessibly by the Admin/HR to prevent harassment or at their discretion.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Board()
        {
            IEnumerable<AnonymousQuestion> questions;
            if (_context.AnonymousComments.Any())
            {
                questions = _context.AnonymousQuestions.OrderByDescending(q => q.TimePosted)
                    .Take(20)
                    .Include(q => q.AnonymousComments)
                    .AsEnumerable();
            }
            else
            {
                questions = _context.AnonymousQuestions.AsEnumerable(); 
            }

            return View(questions);
        }


        public IActionResult AskQuestion(AnonymousQuestion askedQuestion)
        {
            var userdId = _userManager.GetUserId(User);
            if (userdId == null || userdId.Length == 0)
            {
                throw new Exception("Unable to process Authentification.");
                return RedirectToAction("Index", "Home");
            }
            askedQuestion.UserId = userdId;
            askedQuestion.TimePosted = DateTime.Now;
            _context.AnonymousQuestions.Add(askedQuestion);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to record questions.");
            }


            return RedirectToAction("Board");

        }



        public PartialViewResult AddComment(Guid id)
        {
            AnonymousComment comment = new AnonymousComment();
            comment.AnonymousQuestionId = id;



            var partial = new PartialViewResult
            {
                ViewName = "_AddCommentPartial",
                ViewData = new ViewDataDictionary<AnonymousComment>(ViewData, comment)
            };

            return partial;
        }

        public IActionResult ReplyComment(AnonymousComment comment)
        {
            comment.UserId = _userManager.GetUserId(User);
            comment.TimeStamp = DateTime.Now;

            _context.AnonymousComments.Add(comment);
            try
            {
                lock (dbLock)
                {
                    _context.SaveChanges();
                }
            }
            catch
            {
                throw new Exception("Unable to record comment.");
            }


            return RedirectToAction("Board");
        }


    }
}

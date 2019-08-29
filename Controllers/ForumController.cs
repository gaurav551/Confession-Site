using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NepConfess.Data;
using NepConfess.Models;

namespace NepConfess.Controllers
{
    public class ForumController : Controller
    {
        private readonly UserManager<IdentityUser> _u;
        private readonly ApplicationDbContext _context;
        public ForumController(ApplicationDbContext context, UserManager<IdentityUser> u)
        {
            _u = u;
            _context =context;
        }

        public IActionResult Index()
        {
            return View(_context.QForums.ToList());
        }
        [Authorize]
        public IActionResult Ask()
        {
            return View();
        }
         public IActionResult AskQuestion(QForum q)
        {
            q.UserName = _u.GetUserName(HttpContext.User);
            _context.QForums.Add(q);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Question(int id)
        {
            var q = _context.QForums.FirstOrDefault(x=>x.Id==id);
            ViewBag.answer = _context.AForums.Where(x=>x.QForumId==id).ToList();
           ViewBag.a =  ViewBag.answer.Count;
            
            return View(q);
        }
        [Authorize]
        public IActionResult Answer(int Qforumid, string answer,AForum ans)
            {
                ans.Answer = answer;
                ans.QForumId = Qforumid;
                ans.UserName = _u.GetUserName(HttpContext.User);
                ans.Votes = 0;
                _context.AForums.Add(ans);
                _context.SaveChanges();
                 return RedirectToAction(nameof(Question), new {id = Qforumid} );
            }
        
    }
}
using System;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NepConfess.Data;
using NepConfess.Models;
using NepConfess.Repository;

namespace NepConfess.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
        public ProfileController(ApplicationDbContext context, UserManager<IdentityUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        public IActionResult New()
        {
            var b = _usermanager.GetUserId(HttpContext.User);
            if (_context.Profiles.Any(x => x.UserId == b))
            {
                return NoContent();
            }
            else
            {
                return View();
            }
        }

        public async Task<IActionResult> NewProfile(Profile p)
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {

                    var file = Image;
                    var uploads = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/userimages");

                    if (file.Length > 0)
                    {
                        var fileName = ContentDispositionHeaderValue.Parse
                            (file.ContentDisposition).FileName.Trim('"');

                        System.Console.WriteLine(fileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            p.ImageUrl = file.FileName;
                        }


                    }
                }
            }

            p.UserId = _usermanager.GetUserId(HttpContext.User);
            p.UserName = _usermanager.GetUserName(HttpContext.User);
            _context.Profiles.Add(p);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public IActionResult Index()
        {
            var userid = _usermanager.GetUserId(HttpContext.User);
            var s = _context.Profiles.FirstOrDefault(x => x.UserId == userid);
            return View(s);
        }
        public IActionResult NewE()
        {
            return View();

        }
        public IActionResult AuthorProfile(string userid)
        {
            //    string useridoffollow = _usermanager.GetUserId(HttpContext.User);

            //       if(_context.Followers.Any(x=>x.UserId.Equals(useridoffollow)))
            //       {
            //           ViewData["isfollow"] = "Following";
            //       }
            //       else
            //       {
            //            ViewData["isfollow"] = "Follow";
            //       }
            var followerUserId = _usermanager.GetUserId(HttpContext.User);

            if (_context.Followers.Any(x => x.UserId.Equals(followerUserId) && x.FollowId.Equals(userid)))
            {


                TempData["c"]= "Following";

            }
            else
            {

                TempData["c"]= "Follow";
            }
            var u = _context.Profiles.FirstOrDefault(x => x.UserId.Equals(userid));
            return View(u);
        }
        public IActionResult AddEmployee(EmpModel obj)
        {
            _context.EmpModels.Add(obj);
            _context.SaveChanges();
            return View();
        }
        public IActionResult Members()
        {
            return View(_context.Profiles.ToList());
        }
        [HttpGet]
        public IActionResult Follow(string id, string name)
        {
            
            var follower = new Follower();

            follower.UserId = _usermanager.GetUserId(HttpContext.User);
            var followerUserId = _usermanager.GetUserId(HttpContext.User);
            follower.UserName = _usermanager.GetUserName(HttpContext.User);
            follower.FollowId = id;
            follower.FollowerName = name;



            if (_context.Followers.Any(x => x.UserId.Equals(followerUserId) && x.FollowId.Equals(id)))
            {


                return Content("Already followed");

            }
            else
            {

                _context.Followers.Add(follower);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(AuthorProfile), new { userid = id });
        }

        public IActionResult Followers(string id)
        {


            return View(_context.Followers.Where(x => x.FollowId.Equals(id)).ToList());
        }

    }
}
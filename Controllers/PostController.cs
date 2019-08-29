using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NepConfess.Data;
using NepConfess.Models;
using ClientNotifications;
using static ClientNotifications.Helpers.NotificationHelper;

namespace NepConfess.Controllers
{
    public class PostController : Controller
    {
       
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _usermanager;
     //   private static IClientNotification clientNotification;

        public PostController(
        ApplicationDbContext context, 
        UserManager<IdentityUser> usermanager)
       // : base(clientNotification)
        {
            _context = context;
            _usermanager = usermanager;
           
           
        
        }
        
        public IActionResult Index()
        {
            var s = _context.Posts.ToList();

            if (s.Count >= 1)
            {
                ViewBag.one = s.OrderByDescending(x => x.Id).Take(1).Single();
            }
            ViewBag.two = s.OrderByDescending(x => x.Id).Take(3).Skip(1).ToList();
            var posts = _context.Posts.OrderByDescending(x => x.Id).Skip(3).ToList();




            return View(posts);
        }

    [Authorize]
        public IActionResult New()
        {
            return View();
        }
        public IActionResult NewPost(Post P, string description2, bool IsChecked)
        {
            P.Description = description2;
            P.UserId = _usermanager.GetUserId(HttpContext.User);

            Request?.Form?.Keys.FirstOrDefault(k => k.Equals(IsChecked));
            if (IsChecked == true)
            {
                P.Author = "Anonymous";
            }
            else
            {
                P.Author = _usermanager.GetUserName(HttpContext.User);
            }
            _context.Posts.Add(P);
            _context.SaveChanges();
         //  Notify("Post has been updated", NotificationType.success, null); 
            return RedirectToAction(nameof(Index));

        }

        public IActionResult Details(int id)
        {
            var detail1 = _context.Posts.FirstOrDefault(x => x.Id == id);

            var userid = detail1.UserId;

            var user = _context.Profiles.FirstOrDefault(x => x.UserId == userid);
            if (detail1.IsChecked == true)
            {
                ViewBag.userpic="Anonymous.jpg";
                ViewBag.displayname="Anonymous";
                ViewBag.bio = "";
            }
            else if (user != null)
            {
                ViewBag.userpic = user.ImageUrl;
                ViewBag.displayname = user.DisplayName;
                ViewBag.bio = user.Bio;
                ViewBag.postbyauthor = _context.Posts.Where(x => x.UserId == userid).Take(3);
            }



            var detail = _context.Posts.FirstOrDefault(x => x.Id == id);
            // var dname = from p in _context.Posts
            //             join c in _context.Profiles on p.UserId equals c.UserId
            //             select c.DisplayName.ToList();
            ViewBag.comments = _context.Comments.Where(x => x.PostId == id).ToList();
            var s = _context.PostViewCounts.FirstOrDefault(x => x.PostId == id);
            var likes = _context.PostLikes.FirstOrDefault(x => x.PostId == id);
            if (likes != null)
            {

                ViewBag.likes = likes.Like;
            }
            if (s != null)
            {
                ViewBag.postcount = s.Count;
            }
            AddCount(id);
            return View(detail);
        }
        public void AddCount(int postId)
        {
            if (_context.PostViewCounts.Any(x => x.PostId == postId))
            {
                var postCount = _context.PostViewCounts.FirstOrDefault(x => x.PostId == postId);
                postCount.Count += 1;
                _context.PostViewCounts.Update(postCount);
            }
            else
            {
                var pc = new PostViewCount { PostId = postId, Count = 1 };
                _context.PostViewCounts.Add(pc);
            }
            _context.SaveChanges();
        }
        [Authorize]
        public IActionResult NewComment(int postId, string commenttext, Comment c)
        {

          
            c.PostId = postId;
            c.CommentText = commenttext;
            c.CommentBy = _usermanager.GetUserName(HttpContext.User);
            // var userid = _usermanager.GetUserId(HttpContext.User);
            // var displayname = _context.Profiles.FirstOrDefault(x=>x.UserId==userid);
            // if(_context.Profiles.Any(x=>x.UserId==userid))
            // {
            // c.ProfileDisplayName = displayname.DisplayName;
            // }
            if(c.CommentText!=null)
            {
            _context.Comments.Add(c);
            _context.SaveChanges();
             return RedirectToAction(nameof(Details), new { id = postId });
            }
            else
            {
              
                return NoContent();
            }
          
           
        }
        public IActionResult Like(int id)
        {
            if (_context.PostLikes.Any(x => x.PostId == id))
            {
                var postCount = _context.PostLikes.FirstOrDefault(x => x.PostId == id);
                postCount.Like += 1;
                _context.PostLikes.Update(postCount);
            }
            else
            {
                var pc = new PostLike { PostId = id, Like = 1 };
                _context.PostLikes.Add(pc);
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Details), new { Id = id });
        }
        public IActionResult MyPosts()

        {

            var currentid = _usermanager.GetUserId(HttpContext.User);
            var posts = _context.Posts.Where(x => x.UserId == currentid).ToList();

            return View(posts);
        }
        public IActionResult DeleteComment(int id)
        {
           var s = _context.Comments.FirstOrDefault(x=>x.Id==id);
            var Pid = s.PostId;
            var postid = _context.Posts.FirstOrDefault(x=>x.Id==Pid);
            var fff= postid.Author;
            var loggedin = _usermanager.GetUserName(HttpContext.User); 
           if (!s.CommentBy.Equals(loggedin) && !fff.Equals(loggedin))  
                return NoContent();

           _context.Comments.Remove(s);
           _context.SaveChanges();
          
           return RedirectToAction(nameof(Details), new {Id = Pid});
        }


    }
}
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NepConfess.Data;
using NepConfess.Models;

namespace NepConfess.Controllers
{
    

    public class GroupsController : Controller
    {
    private readonly ApplicationDbContext _context;
   private readonly UserManager<IdentityUser> _usermanager;

        public GroupsController(ApplicationDbContext context, UserManager<IdentityUser> usermanager )
    {
        _context = context;
        _usermanager = usermanager;
    }
    
        public IActionResult Index()
        {
            return View(_context.Groups.ToList());
        }
         public async Task<IActionResult> CreateGroup(Group p)
        {
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
            
                      
                    var file = Image;
                    var uploads = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/groupimages");

                   
                        var fileName = ContentDispositionHeaderValue.Parse
                            (file.ContentDisposition).FileName.Trim('"');

                        System.Console.WriteLine(fileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            p.ImageUrl = file.FileName;
                        }
            }

                    
           
            p.UserId = _usermanager.GetUserId(HttpContext.User);
           
            _context.Groups.Add(p);
            await _context.SaveChangesAsync();
           
            return RedirectToAction ("Index");
        }
        public IActionResult NewGroup()
        {
            return View();
        }
         public IActionResult ExploreMore(int id)
        {
            var group = _context.Groups.FirstOrDefault(x=>x.Id==id);
            ViewBag.groupposts = _context.GroupPosts.Where(x=>x.GroupId==id).ToList();
            return View(group);
            
        }
       public IActionResult NewGroupPost(int id)
       {
           ViewBag.groupid = id;
           return View();
       }
       [HttpPost]
        public IActionResult CreateGroupPost(GroupPost gp, int groupId)
       {
           
           gp.GroupId = groupId;
           gp.UserName = _usermanager.GetUserName(HttpContext.User);
           _context.GroupPosts.Add(gp);
           _context.SaveChanges();
          
           return RedirectToAction(nameof(ExploreMore), new {id = groupId});
       }
       public IActionResult Details(int id)
       {
           return View((_context.GroupPosts.FirstOrDefault(x=>x.Id==id)));
       }

    }
}
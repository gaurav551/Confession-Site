using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NepConfess.Models;


namespace NepConfess.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    public DbSet<Post> Posts {get;set;}
    public DbSet<Profile> Profiles {get;set;}
    public DbSet<Comment> Comments {get;set;}
    public DbSet<PostViewCount> PostViewCounts { get; set; }
    public DbSet<PostLike> PostLikes { get; set; }
    public DbSet<EmpModel> EmpModels { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupPost> GroupPosts { get; set; }
    public DbSet<QForum> QForums { get; set; }
    public DbSet<AForum> AForums { get; set; }
    public DbSet<Follower> Followers { get; set; }
    }
}

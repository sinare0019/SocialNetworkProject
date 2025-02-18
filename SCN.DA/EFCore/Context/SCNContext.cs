using Microsoft.EntityFrameworkCore;
using SCN.Common.Helpers;
using SCN.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCN.DA.EFCore.Context
{
    public class SCNContext : DbContext
    {
        public SCNContext(DbContextOptions<SCNContext> options) : base(options)
        {
        }
        public DbSet<User> Users { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Reaction> Reactions { set; get; }
        public DbSet<PostComment> PostComments { set; get; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


         //   var passHash = "123456".HashPassword();
            modelBuilder.Entity<User>().HasData(
            new User { Id=-1, Name = "سینا", LastName = "رضائی", Email = "Sina@gmail.com", UserName = "sina", Password = "123456" });

            modelBuilder.Entity<PostComment>()
                .HasKey(pc => new { pc.Post_Id, pc.Comment_Id });

            modelBuilder.Entity<PostComment>()
                .HasOne(pc => pc.Post)
                .WithMany(p => p.PostComments)
                .HasForeignKey(pc => pc.Post_Id)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<PostComment>()
                    .HasOne(pc => pc.Comment)
                    .WithMany(c => c.PostComments)
                    .HasForeignKey(pc => pc.Comment_Id)
            .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<Reaction>()
     .HasOne(r => r.Post)
     .WithMany(p => p.Reactions)
     .HasForeignKey(r => r.Post_Id)
     .OnDelete(DeleteBehavior.NoAction);

        }
    }
}

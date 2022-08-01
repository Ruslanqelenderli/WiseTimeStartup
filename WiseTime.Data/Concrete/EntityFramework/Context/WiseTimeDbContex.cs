using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseTime.Entity.Entities;
using WiseTime.Entity.Entities.Manage;

namespace WiseTime.Data.Concrete.EntityFramework.Context
{
    public class WiseTimeDbContext:IdentityDbContext<User,Role,int>
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                connectionString: @"Server=DESKTOP-2A4NBF1;Database=WiseTimeDatabase;Trusted_Connection=True;Connect Timeout=40;MultipleActiveResultSets=True;"
                );
            
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //}



        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<AnswerComment> AnswerComments { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

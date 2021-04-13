using BlazorBlogProject.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBlogProject.Server.Data
{
    public class DbContextClass : DbContext
    {
        public DbContextClass(DbContextOptions<DbContextClass> options) : base(options) { }

        public DbSet<EIGENAAR> EIGENAAR { get; set; }
    }
}

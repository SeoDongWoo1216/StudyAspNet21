using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using _210420_MyPortpolio.Models;

namespace _210420_MyPortpolio.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Board> Boards { get; set; }
    }
}

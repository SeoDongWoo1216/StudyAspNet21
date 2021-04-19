using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _210419_TodoListWebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)   // 이게 있어야 DB랑 연계됨
        {

        }

        public DbSet<Todo> Todos {get; set;}
    }
}

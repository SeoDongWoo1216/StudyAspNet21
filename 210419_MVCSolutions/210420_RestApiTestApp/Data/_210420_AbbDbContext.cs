using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using _210420_RestApiTestApp.Models;

namespace _210420_RestApiTestApp.Data
{
    public class _210420_AbbDbContext : DbContext
    {
        public _210420_AbbDbContext (DbContextOptions<_210420_AbbDbContext> options)
            : base(options)
        {
        }

        public DbSet<Todo> Todos { get; set; }
    }
}

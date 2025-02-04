using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ppr_Entity.Entity;

namespace Ppr_Entity.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) {

        }

        public DbSet<User> Users {get; set;}
    }
}
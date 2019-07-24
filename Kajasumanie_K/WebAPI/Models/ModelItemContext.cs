using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Models
{
    public class ModelItemContext : DbContext
    {
        public ModelItemContext(DbContextOptions<ModelItemContext> options)
            : base(options)
        {
        }

        public DbSet<ModelItem> ModelItemsData { get; set; }

        public DbSet<User> User { get; set; }
    }
}

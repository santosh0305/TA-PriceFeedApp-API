using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UNITOFWORK_AND_REPOSITORY_PATTERN
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet Authors { get; set; }
        public virtual DbSet Books { get; set; }
        public MyDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
    }
}

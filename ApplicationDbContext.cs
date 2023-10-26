using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpfwdb
{
    public class ApplicationDbContext:DbContext
    {
        //Create a db set for each table you want
        public DbSet <Semesters> Semesters { get; set; }
        public DbSet <Modules> Modules { get; set; }
        public DbSet <User> Users { get; set; }
    }
}

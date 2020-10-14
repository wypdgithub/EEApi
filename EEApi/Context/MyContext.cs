using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EEApi.Model;

namespace EEApi.Context
{
    public class MyContext:DbContext
    {
        public MyContext() { }
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }
        public DbSet<Emp> emps { get; set; }
        public DbSet<Course> courses { get; set; }
    }
}

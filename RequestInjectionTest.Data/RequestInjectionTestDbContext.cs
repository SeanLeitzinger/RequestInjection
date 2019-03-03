using Microsoft.EntityFrameworkCore;
using RequestInjectionTest.Data.Models;

namespace RequestInjectionTest.Data
{
    public class RequestInjectionTestDbContext : DbContext
    {
        public DbSet<ChildClass1> ChildClass1 { get; set; }
        public DbSet<ChildClass2> ChildClass2 { get; set; }
        public DbSet<TestModel> TestModel { get; set; }
    }
}

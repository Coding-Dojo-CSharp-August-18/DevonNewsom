using Microsoft.EntityFrameworkCore;

namespace LoginRegEF.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<MyUser> users {get;set;}
        public DbSet<Blog> blogs {get;set;}
        public DbSet<Vote> votes {get;set;}
    }
}
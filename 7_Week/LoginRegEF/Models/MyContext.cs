using Microsoft.EntityFrameworkCore;

namespace LoginRegEF.Models
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions options) : base(options) {}
        public DbSet<MyUser> Users {get;set;}
    }
}
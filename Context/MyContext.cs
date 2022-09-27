using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> dbContext) : base(dbContext)
        {

        }

        public DbSet<Karyawan> Karyawan { get; set; }
        public DbSet<JenisCuti> JenisCuti { get; set; }
        public DbSet<Cuti> Cuti { get; set; }
    }
}

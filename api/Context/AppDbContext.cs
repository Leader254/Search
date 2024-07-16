using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<CreatePartDTO> PartsSerial { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using VinDecoderSalvageApi.Entities;

namespace VinDecoderSalvageApi.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<OTP> OTPs { get; set; }
    }
}

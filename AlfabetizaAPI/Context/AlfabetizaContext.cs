using AlfabetizaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlfabetizaAPI.Context
{
    public class AlfabetizaContext : DbContext
    {
        public AlfabetizaContext(DbContextOptions<AlfabetizaContext> options) : base(options)
        { }

        public DbSet<User> User { get; set; }
        public DbSet<Community> Community { get; set; }
        public DbSet<UserCommunity> UserCommunity { get; set; }
    }
}

using AlfabetizaAPI.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AlfabetizaAPI.Context
{
    public class AlfabetizaContext : DbContext
    {
        public AlfabetizaContext(DbContextOptions<AlfabetizaContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}

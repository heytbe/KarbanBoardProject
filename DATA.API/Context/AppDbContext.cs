using Entity.API.Models.Identity;
using Entity.API.Models.KarbanModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.API.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }
        public DbSet<BoardLists> BoardLists { get; set; }
        public DbSet<BoardUsers> BoardUsers { get; set; }
        public DbSet<ListAddition> ListAdditions { get; set; }
        public DbSet<ListCard> ListCards { get; set; }
        public DbSet<ListTicket> ListTickets { get; set; }
        public DbSet<UserRefreshToken> userRefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

    }
}

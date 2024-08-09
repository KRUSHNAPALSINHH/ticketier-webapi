using Microsoft.EntityFrameworkCore;
using ticketier_webapi.Core.Entities;

namespace ticketier_webapi.Core.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Ticket>Tickets { get; set; }
    }
}

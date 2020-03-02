using BMS.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BMS.DAL.EntityFrameworkCore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookOutboundForm> BookOutboundForm { get; set; }
        public virtual DbSet<BookReturnRecord> BookReturnRecord { get; set; }
        public virtual DbSet<LibraryEntryForm> LibraryEntryForm { get; set; }
    }
}
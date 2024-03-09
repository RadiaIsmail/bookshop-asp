using Bookshopemployee.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookshopemployee.data
{
    public class dbcontext:DbContext
    {
        public dbcontext(DbContextOptions<DbContext> options) : base(options) 
        { 
        }
        public DbSet<employee> employees { get; set; }
    }
}

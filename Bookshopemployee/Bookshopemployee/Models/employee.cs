using Microsoft.EntityFrameworkCore;

namespace Bookshopemployee.Models
{
    public class dbcontext : DbContext
    {
        public dbcontext(DbContextOptions<DbContext> options) : base(options)
        {
        }
        public DbSet<employee> employees { get; set; }
    }
    public class employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string LastName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public string country { get; set; }
        public DateTime DateOfbrith { get; set; }
        public string Department { get; set; }
    }
}

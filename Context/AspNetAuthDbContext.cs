using AspNetAuth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AspNetAuth.Context
{
    public class AspNetAuthDbContext: IdentityDbContext
    {
        public AspNetAuthDbContext(DbContextOptions options): base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

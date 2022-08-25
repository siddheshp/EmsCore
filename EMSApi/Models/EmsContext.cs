using EmsModelLibrary;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EMSApi.Models
{
    public class EmsContext : DbContext
    {
        public EmsContext([NotNullAttribute] 
            DbContextOptions options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users { get; set; } 
    }
}

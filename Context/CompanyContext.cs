using EFCore2.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.OracleClient;

namespace EFCore2.Context
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options) { }

        public DbSet<Dept> Depts { get; set; }
        public DbSet<Emp> Emps { get; set; }
    }
}

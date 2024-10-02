using System.Reflection.Emit;
using Cafe.Domain.Features.Employees;
using Cafe.Domain.Features.User;
using Cafe.Infrastructure.Configuration.EntityTypeConfiguration;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Cafe.Infrastructure
{
    public class RawaanDBContext : IdentityDbContext<RawaanUser>
    {
        public RawaanDBContext(DbContextOptions<RawaanDBContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /// ********* Employee **********
             builder.HasSequence<int>("EmployeeSequence", schema: "dbo")
                    .StartsAt(1)
                    .IncrementsBy(1);
            new EmployeesEntityConfiguration(false).Configure(builder.Entity<EmployeeEntity>());
            /// ********* Employee **********
            
            base.OnModelCreating(builder);
        }

        public DbSet<EmployeeEntity> Employees { get; set; }
    }
}